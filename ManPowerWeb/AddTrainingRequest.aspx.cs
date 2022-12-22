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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEmployNO();
                BindProgram();
            }
        }

        public void BindEmployNO()
        {
            EmploymentDetailsController employeeDetailController = ControllerFactory.CreateEmploymentDetailsController();

            employeeDetailList = employeeDetailController.GetAllEmploymentDetails();

            ddlEmployNo.DataSource = employeeDetailList;
            ddlEmployNo.DataValueField = "EmpID";
            ddlEmployNo.DataTextField = "EmpNumber";
            ddlEmployNo.DataBind();

        }

        public void BindProgram()
        {
            ProgramController programControl = ControllerFactory.CreateProgramController();

            programList = programControl.GetAllProgram(false);

            ddlProgram.DataSource = programList;
            ddlProgram.DataValueField = "ProgramId";
            ddlProgram.DataTextField = "ProgramName";
            ddlProgram.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //TrainingRequest.Employee_Id = Convert.ToInt32(ddlEmployNo.SelectedValue);
            TrainingRequest.Employee_Id = 4;
            TrainingRequest.ProgramDate = Convert.ToDateTime(txtDate.Value);
            TrainingRequest.ProgramId = Convert.ToInt32(ddlProgram.SelectedValue);
            TrainingRequest.RequestedDate = DateTime.Now;
            TrainingRequest.RequestedUserID = 4;
            TrainingRequest.ApprovedBy = 4;
            TrainingRequest.ApprovedDate = DateTime.Now;
            TrainingRequest.StatusID = 1;
            TrainingRequest.TrainingCategory = ddlTrainingCategory.SelectedItem.Text;
            TrainingRequest.Institute = txtInstitute.Text;
            TrainingRequest.Content = txtContent.Text;
            TrainingRequest.DocUpload = "";

            TrainingRequestController trainingRequestController = ControllerFactory.CreateTrainingRequestController();

            trainingRequestController.AddRequest(TrainingRequest);
        }
    }
}