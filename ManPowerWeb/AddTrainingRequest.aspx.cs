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
        List<Program> programList = new List<Program>();
        List<EmploymentDetails> employeeDetailList = new List<EmploymentDetails>();
        Training_Request TrainingRequest = new Training_Request();

        public int trainingRequestId;

        public string fileName;

        protected void Page_Load(object sender, EventArgs e)
        {
            trainingRequestId = Convert.ToInt32(Request.QueryString["TrainingRequestId"]);

            if (!IsPostBack)
            {
                BindEmployNO();
                BindProgram();

                if (trainingRequestId != 0)
                {
                    BindDataToUpdate();
                }
            }
        }

        public void BindEmployNO()
        {
            EmploymentDetailsController employeeDetailController = ControllerFactory.CreateEmploymentDetailsController();

            employeeDetailList = employeeDetailController.GetAllEmploymentDetails();


            ddlEmployNo.DataSource = employeeDetailList;
            ddlEmployNo.DataValueField = "EmpID";
            ddlEmployNo.DataTextField = "EmpID";
            ddlEmployNo.DataBind();

        }

        public void BindProgram()
        {
            ProgramController programControl = ControllerFactory.CreateProgramController();

            programList = programControl.GetAllProgram(false, false);

            ddlProgram.DataSource = programList;
            ddlProgram.DataValueField = "ProgramId";
            ddlProgram.DataTextField = "ProgramName";
            ddlProgram.DataBind();
        }

        public void BindDataToUpdate()
        {
            TrainingRequestController trainingRequestController = ControllerFactory.CreateTrainingRequestController();

            TrainingRequest = trainingRequestController.GetTraining_Request(trainingRequestId);

            ddlEmployNo.SelectedValue = TrainingRequest.Employee_Id.ToString();
            txtDate.Value = TrainingRequest.ProgramDate.ToString("yyyy-MM-dd");
            //string date = TrainingRequest.ProgramDate.ToString("dd. MM. yyyy");
            //txtDate.Value = date;
            ddlProgram.SelectedValue = TrainingRequest.ProgramId.ToString();
            ddlTrainingCategory.SelectedItem.Text = TrainingRequest.TrainingCategory;
            txtInstitute.Text = TrainingRequest.Institute;
            txtContent.Text = TrainingRequest.Content;
            fileName = TrainingRequest.DocUpload;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (trainingRequestId != 0)
            {
                TrainingRequest.TrainingRequestId = trainingRequestId;
                TrainingRequest.Employee_Id = Convert.ToInt32(ddlEmployNo.SelectedValue);
                TrainingRequest.ProgramDate = Convert.ToDateTime(txtDate.Value);
                TrainingRequest.ProgramId = Convert.ToInt32(ddlProgram.SelectedValue);
                TrainingRequest.RequestedDate = DateTime.Now;
                TrainingRequest.RequestedUserID = Convert.ToInt32(Session["DepUnitPositionId"]);
                TrainingRequest.ApprovedBy = Convert.ToInt32(Session["DepUnitParentId"]);
                TrainingRequest.ApprovedDate = DateTime.Now;
                TrainingRequest.StatusID = 1;
                TrainingRequest.TrainingCategory = ddlTrainingCategory.SelectedItem.Text;
                TrainingRequest.Institute = txtInstitute.Text;
                TrainingRequest.Content = txtContent.Text;

                if (FileUploader.HasFile)
                {
                    HttpPostedFile uploadFile = Request.Files[0];

                    uploadFile.SaveAs(Server.MapPath("~/Document/") + uploadFile.FileName);

                    fileName = uploadFile.FileName;
                }

                TrainingRequest.DocUpload = fileName;

                TrainingRequestController trainingRequestController = ControllerFactory.CreateTrainingRequestController();

                trainingRequestController.UpdateTrainingRequest(TrainingRequest);

            }

            else
            {
                TrainingRequest.Employee_Id = Convert.ToInt32(ddlEmployNo.SelectedValue);
                TrainingRequest.ProgramDate = Convert.ToDateTime(txtDate.Value);
                TrainingRequest.ProgramId = Convert.ToInt32(ddlProgram.SelectedValue);
                TrainingRequest.RequestedDate = DateTime.Now;
                TrainingRequest.RequestedUserID = Convert.ToInt32(Session["DepUnitPositionId"]);
                TrainingRequest.ApprovedBy = Convert.ToInt32(Session["DepUnitParentId"]);
                TrainingRequest.ApprovedDate = DateTime.Now;
                TrainingRequest.StatusID = 1;
                TrainingRequest.TrainingCategory = ddlTrainingCategory.SelectedItem.Text;
                TrainingRequest.Institute = txtInstitute.Text;
                TrainingRequest.Content = txtContent.Text;

                if (FileUploader.HasFile)
                {
                    HttpPostedFile uploadFile = Request.Files[0];

                    uploadFile.SaveAs(Server.MapPath("~/Document/") + uploadFile.FileName);

                    fileName = uploadFile.FileName;
                }

                else
                {
                    fileName = "";
                }

                TrainingRequest.DocUpload = fileName;

                TrainingRequestController trainingRequestController = ControllerFactory.CreateTrainingRequestController();

                trainingRequestController.AddRequest(TrainingRequest);
            }

            string url = "requesttraining.aspx";
            Response.Redirect(url);
        }
    }
}