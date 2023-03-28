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
    public partial class AddTrainingRequest : System.Web.UI.Page
    {

        public int trainingMainId;
        public int depId;
        public string fileName;
        public TrainingMain trainingMain = new TrainingMain();

        TrainingMainController trainingMainController = ControllerFactory.CreateTrainingMainController();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            trainingMainId = Convert.ToInt32(Request.QueryString["TrainingMainId"]);
            depId = Convert.ToInt32(Session["DepUnitPositionId"]);

            if (!IsPostBack)
            {
                if (trainingMainId > 0)
                {
                    BindDataToUpdate();
                }
            }
        }

        public void BindDataToUpdate()
        {
            List<TrainingMain> trainingMainList = trainingMainController.GetAllTrainingMain();

            trainingMain = trainingMainList.Where(x => x.TrainingMainId == trainingMainId).Single();

            txtStartDate.Value = trainingMain.Start_Date.ToString("yyyy-MM-dd");
            txtEndDate.Value = trainingMain.End_date.ToString("yyyy-MM-dd");
            txtTitle.Text = trainingMain.Title;
            txtDescription.Text = trainingMain.Content;
            txtCount.Text = trainingMain.Member_Count.ToString();

            btnSave.Text = "Update";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Update")
            {
                List<TrainingMain> trainingMainList = trainingMainController.GetAllTrainingMain();

                trainingMain = trainingMainList.Where(x => x.TrainingMainId == trainingMainId).Single();

                trainingMain.Start_Date = Convert.ToDateTime(txtStartDate.Value);
                trainingMain.End_date = Convert.ToDateTime(txtEndDate.Value);
                trainingMain.Title = txtTitle.Text;
                trainingMain.Content = txtDescription.Text;
                trainingMain.Member_Count = Convert.ToInt32(txtCount.Text);

                if (trainingMain.Start_Date >= DateTime.Now && trainingMain.End_date >= trainingMain.Start_Date)
                {
                    if (FileUploader.HasFile)
                    {
                        HttpPostedFile uploadFile = Request.Files[0];

                        uploadFile.SaveAs(Server.MapPath("~/SystemDocuments/TrainingImages/") + uploadFile.FileName);

                        fileName = uploadFile.FileName;

                        trainingMain.Post_img = fileName;
                    }

                    trainingMainController.Update(trainingMain);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Updated Succesfully!', 'success');window.setTimeout(function(){window.location='AddTrainingFront.aspx'},2500);", true);

                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Failed!', 'Please Enter a Valid Date!', 'error');", true);
                }


            }

            else
            {
                if (Convert.ToDateTime(txtStartDate.Value) > DateTime.Now && Convert.ToDateTime(txtEndDate.Value) >= Convert.ToDateTime(txtStartDate.Value))
                {


                    trainingMain.Created_Date = DateTime.Now;
                    trainingMain.Start_Date = Convert.ToDateTime(txtStartDate.Value);
                    trainingMain.End_date = Convert.ToDateTime(txtEndDate.Value);
                    trainingMain.Title = txtTitle.Text;
                    trainingMain.Content = txtDescription.Text;
                    trainingMain.Created_User = depId;
                    trainingMain.Member_Count = Convert.ToInt32(txtCount.Text);

                    if (FileUploader.HasFile)
                    {
                        HttpPostedFile uploadFile = Request.Files[0];

                        uploadFile.SaveAs(Server.MapPath("~/SystemDocuments/TrainingImages/") + uploadFile.FileName);

                        fileName = uploadFile.FileName;
                    }

                    trainingMain.Post_img = fileName;

                    trainingMainController.Save(trainingMain);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Updated Succesfully!', 'success');window.setTimeout(function(){window.location='AddTrainingFront.aspx'},2500);", true);

                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Failed!', 'Please Enter a Valid Date!', 'error');", true);
                }

            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string Url = "AddtrainingFront.aspx";
            Response.Redirect(Url);
        }
    }
}