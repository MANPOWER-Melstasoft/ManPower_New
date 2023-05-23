using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
	public partial class ApprovedTrainingView : System.Web.UI.Page
	{
		static int Id;
		static TrainingRequests approvedtrainingObj = new TrainingRequests();
		static ApprovedTrainingRequestDocuments atrdObj = new ApprovedTrainingRequestDocuments();
		static List<ApprovedTrainingRequestDocuments> mainList;


		protected void Page_Load(object sender, EventArgs e)
		{
			this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

			gvTrainingDocuments.Visible = false;
			Literal8.Visible = false;
			btnSubmit.Visible = false;
			Uploader.Visible = false;
			Literal9.Visible = false;

			if (!IsPostBack)
			{
				if (Request.QueryString["Id"] != null)
				{
					Id = Convert.ToInt32(Request.QueryString["Id"]);
					BindData();
				}
				else
				{
					Response.Redirect("404.aspx");
				}

			}

		}

		private void BindData()
		{
			mainList = null;
			ApprovedTrainingRequestDocumentsController atrdController = ControllerFactory.CreateApprovedTrainingRequestDocumentsController();
			List<ApprovedTrainingRequestDocuments> mainListIn = atrdController.GetAllApprovedTrainingRequestDocuments(false);
			mainList = new List<ApprovedTrainingRequestDocuments>();
			atrdObj = atrdController.GetApprovedTrainingRequestDocuments();

			TrainingRequestsController trainingRequestsController = ControllerFactory.CreateTrainingRequestsController();
			approvedtrainingObj = trainingRequestsController.GetTrainingRequests(Id);

			foreach (var item in mainListIn)
			{
				if (item.ApprovedTrainingRequestId == approvedtrainingObj.TrainingRequestsId)
				{
					mainList.Add(item);
				}
			}

			lblTrainingRequestsId.Text = approvedtrainingObj.TrainingRequestsId.ToString();
			lblTrainingMainId.Text = approvedtrainingObj.TrainingMainId.ToString();
			lblTitle.Text = approvedtrainingObj.Trainingmain.Title;
			lblStartDate.Text = approvedtrainingObj.Trainingmain.Start_Date.ToString("dd-MM-yyyy");
			lblEnddate.Text = approvedtrainingObj.Trainingmain.End_date.ToString("dd-MM-yyyy");
			lblAcceptedBy.Text = approvedtrainingObj.Accepted_User.ToString();
			lblAcceptedDate.Text = approvedtrainingObj.Accepted_Date.ToString("dd-MM-yyyy");

			if (mainList.Count != 0)
			{
				gvTrainingDocuments.DataSource = mainList;
				gvTrainingDocuments.DataBind();
				Literal8.Visible = true;
				gvTrainingDocuments.Visible = true;
			}
			else
			{
				Literal9.Visible = true;
				btnSubmit.Visible = true;
				Uploader.Visible = true;
			}


		}
		protected void btnBack_Click(object sender, EventArgs e)
		{
			Response.Redirect("UserTrainingReport.aspx");
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			if (mainList.Count == 0)
			{
				int output = 0;
				TrainingRequests trainingRequests = new TrainingRequests();

				trainingRequests.TrainingRequestsId = int.Parse(lblTrainingRequestsId.Text);
				trainingRequests.TrainingMainId = int.Parse(lblTrainingMainId.Text);

				List<string> DocList = new List<string>();

				if (Uploader.HasFile)
				{
					HttpFileCollection uploadFiles = Request.Files;
					for (int i = 0; i < uploadFiles.Count; i++)
					{
						HttpPostedFile uploadFile = uploadFiles[i];
						if (uploadFile.ContentLength > 0)
						{
							uploadFile.SaveAs(Server.MapPath("~/SystemDocuments/TrainingCertificates/") + uploadFile.FileName);
							DocList.Add(uploadFile.FileName);
						}
					}
				}
				TrainingRequestsController trainingRequestsController = ControllerFactory.CreateTrainingRequestsController();
				output = trainingRequestsController.updateTraining(trainingRequests, DocList);
				if (output == 1)
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Record Added Succesfully!', 'success');window.setTimeout(function(){window.location='UserTrainingReport.aspx'},2500);", true);
				}
				else
				{
					ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Record Added Fail!', 'error');", true);
				}
			}
		}
	}
}