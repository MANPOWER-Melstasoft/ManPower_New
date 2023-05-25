using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
	public partial class TrainingRequestReport : System.Web.UI.Page
	{
		List<TrainingRequests> trainingRequestsList = new List<TrainingRequests>();
		List<TrainingRequests> filterList = new List<TrainingRequests>();
		public int UserID;
		protected void Page_Load(object sender, EventArgs e)
		{
			this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
			UserID = Convert.ToInt32(Session["DepUnitPositionId"]);

			BindDataSource();


			if (!IsPostBack)
			{
				BindDdlStatus();
			}
		}

		public void BindDataSource()
		{
			TrainingRequestsController trainingRequestsController = ControllerFactory.CreateTrainingRequestsController();
			trainingRequestsList = trainingRequestsController.GetAllTrainingRequestsWithDetail();

			trainingRequestsList = trainingRequestsList.Where(x => x.Is_Active == 1).ToList();

			filterList = trainingRequestsList;

			// Reverse the filterList before binding it to the GridView
			filterList.Reverse();

			gvTrainingRequestReport.DataSource = filterList;
			gvTrainingRequestReport.DataBind();
		}

		private void BindDdlStatus()
		{

			ddlStatus.Items.Insert(0, new ListItem("All", ""));

			ddlStatus.Items.Insert(1, new ListItem("Pending", "1"));
			ddlStatus.Items.Insert(2, new ListItem("Approved", "1008"));
			ddlStatus.Items.Insert(3, new ListItem("Hold", "3"));
			ddlStatus.Items.Insert(4, new ListItem("Reject", "7"));
		}

		/*protected void btnView_Click(object sender, EventArgs e)
		{
			int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
			int pagesize = gvTrainingRequestReport.PageSize;
			int pageindex = gvTrainingRequestReport.PageIndex;
			rowIndex = (pagesize * pageindex) + rowIndex;
			Response.Redirect("ApprovedTrainingView.aspx?Id=" + filterList[rowIndex].TrainingRequestsId);
		}*/

		public override void VerifyRenderingInServerForm(Control control)
		{

		}
		protected void btnExportExcel_Click(object sender, EventArgs e)
		{
			// update filterList based on selected status
			/*gvTrainingRequestReport.Columns[7].Visible = false;*/
			if (ddlStatus.SelectedValue == "1")
			{
				filterList = trainingRequestsList.Where(a => a.ProjectStatusId == 1).ToList();
			}
			else if (ddlStatus.SelectedValue == "1008")
			{
				filterList = trainingRequestsList.Where(a => a.ProjectStatusId == 1008).ToList();
			}
			else if (ddlStatus.SelectedValue == "3")
			{
				filterList = trainingRequestsList.Where(a => a.ProjectStatusId == 3).ToList();
			}
			else if (ddlStatus.SelectedValue == "7")
			{
				filterList = trainingRequestsList.Where(a => a.ProjectStatusId == 7).ToList();
			}
			else
			{
				filterList = trainingRequestsList;
			}

			// Reverse the filterList before binding it to the GridView
			filterList.Reverse();

			gvTrainingRequestReport.DataSource = filterList;
			gvTrainingRequestReport.DataBind();


			Response.Clear();
			Response.Buffer = true;
			Response.ClearContent();
			Response.ClearHeaders();
			Response.Charset = "";
			string FileName = "Training Request Report" + DateTime.Now + ".xls";
			StringWriter strwritter = new StringWriter();
			HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.ContentType = "application/vnd.ms-excel";
			Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
			gvTrainingRequestReport.GridLines = GridLines.Both;
			//tblTaSummary.HeaderStyle.Font.Bold = true;
			gvTrainingRequestReport.RenderControl(htmltextwrtter);
			Response.Write(strwritter.ToString());
			Response.End();
		}

		protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ddlStatus.SelectedValue == "1")
			{
				filterList = trainingRequestsList.Where(a => a.ProjectStatusId == 1).ToList();
			}
			else if (ddlStatus.SelectedValue == "1008")
			{
				filterList = trainingRequestsList.Where(a => a.ProjectStatusId == 1008).ToList();
			}
			else if (ddlStatus.SelectedValue == "3")
			{
				filterList = trainingRequestsList.Where(a => a.ProjectStatusId == 3).ToList();
			}
			else if (ddlStatus.SelectedValue == "7")
			{
				filterList = trainingRequestsList.Where(a => a.ProjectStatusId == 7).ToList();
			}
			else
			{
				filterList = trainingRequestsList;
			}

			gvTrainingRequestReport.DataSource = filterList;
			gvTrainingRequestReport.DataBind();
		}
	}
}