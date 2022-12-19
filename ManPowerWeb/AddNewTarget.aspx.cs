using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ManPowerWeb
{
    public partial class AddNewTarget : System.Web.UI.Page
    {

        List<ProgramTarget> searchTarget = new List<ProgramTarget>();

        List<DepartmentUnit> listDistrict = new List<DepartmentUnit>();
        List<DepartmentUnit> listDSDivision = new List<DepartmentUnit>();
        List<Designation> listDesignation = new List<Designation>();
        List<ProgramType> listProgramType = new List<ProgramType>();
        List<DepartmentUnitPositions> listUser = new List<DepartmentUnitPositions>();
        List<SystemUser> listUsers = new List<SystemUser>();
        List<SystemUser> listManagers = new List<SystemUser>();
        List<ProgramTarget> allTargets = new List<ProgramTarget>();
        List<Possitions> PositionList = new List<Possitions>();
        List<Program> program = new List<Program>();

        protected void Page_Load(object sender, EventArgs e)
        {


            DesignationController designationController = ControllerFactory.CreateDesignationController();
            listDesignation = designationController.GetAllDesignation(true, false);

            DepartmentUnitPositionsController unitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
            listUser = unitPositionsController.GetAllDepartmentUnitPositions(false, false, true, false, true);

            //ProgramController programController = ControllerFactory.CreateProgramController();
            //program = programController.GetAllProgram(false);

            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            allTargets = programTargetController.GetAllProgramTarget(false, false, false, false);





            //diloagBox.Visible = false;

            if (!IsPostBack)
            {
                BindDataSource();
                //hideDSDivision();
                bindOficerRecomendation();
                bindDSDivision();
                hideDSDivision();
                bindProgram();

            }

        }

        private void BindDataSource()
        {
            DepartmentUnitTypeController _DepartmentUnitTypeController = ControllerFactory.CreateDepartmentUnitTypeController();
            listDistrict = _DepartmentUnitTypeController.GetDepartmentUnitType(2, true)._DepartmentUnit;
            listDSDivision = _DepartmentUnitTypeController.GetDepartmentUnitType(3, true)._DepartmentUnit;

            ddlDistrict.DataSource = listDistrict;
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataValueField = "DepartmentUnitId";
            ddlDistrict.DataBind();




            PossitionsController possitionsController = ControllerFactory.CreatePossitionsController();
            PositionList = possitionsController.GetAllPossitions(false);
            ddlPosition.DataSource = PositionList;
            ddlPosition.DataTextField = "PositionName";
            ddlPosition.DataValueField = "PossitionId";
            ddlPosition.DataBind();

            ProgramTypeController programTypeController = ControllerFactory.CreateProgramTypeController();
            listProgramType = programTypeController.GetAllProgramType(false);
            ddlProgramType.DataSource = listProgramType;
            ddlProgramType.DataTextField = "ProgramTypeName";
            ddlProgramType.DataValueField = "ProgramTypeId";
            ddlProgramType.DataBind();

            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            listUsers = systemUserController.GetAllSystemUser(true, false, false);

            DepartmentUnitPositionsController unitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
            listUser = unitPositionsController.GetAllDepartmentUnitPositions(false, false, true, false, true);

            List<SystemUser> listSystemUseer = new List<SystemUser>();
            foreach (var item in listUser)
            {
                listSystemUseer.Add(item._SystemUser);
            }

            ddlOfficer.DataSource = listSystemUseer;
            ddlOfficer.DataValueField = "SystemUserId";
            ddlOfficer.DataTextField = "Name";
            ddlOfficer.DataBind();

        }



        private void bindProgram()
        {
            ProgramController programController = ControllerFactory.CreateProgramController();
            program = programController.GetAllProgram(false);
            if (ddlProgramType.SelectedValue != "")
            {
                ddlProgram.DataSource = program.Where(u => u.ProgramType.ToString() == ddlProgramType.SelectedValue);
                ddlProgram.DataTextField = "ProgramName";
                ddlProgram.DataValueField = "ProgramId";
                ddlProgram.DataBind();
            }
            else
            {
                ddlProgram.Items.Clear();
            }

        }

        protected void ddlProgramType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindProgram();
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDSDivision();
        }
        private void bindDSDivision()
        {
            DepartmentUnitTypeController _DepartmentUnitTypeController = ControllerFactory.CreateDepartmentUnitTypeController();
            listDSDivision = _DepartmentUnitTypeController.GetDepartmentUnitType(3, true)._DepartmentUnit;

            if (ddlDistrict.SelectedValue != "")
            {
                ddlDSDivision.DataSource = listDSDivision.Where(u => u.ParentId.ToString() == ddlDistrict.SelectedValue);
                ddlDSDivision.DataTextField = "Name";
                ddlDSDivision.DataValueField = "DepartmentUnitId";
                ddlDSDivision.DataBind();
            }
            else
            {
                ddlDSDivision.Items.Clear();
            }
        }

        private void bindOficerRecomendation()
        {
            List<SystemUser> listOficerRecomendation = new List<SystemUser>();
            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            listOficerRecomendation = systemUserController.GetAllSystemUser(false, false, false);

            ddlOficerRecomended.DataSource = listOficerRecomendation.Where(u => u.UserTypeId == 2 && u.UserTypeId != Convert.ToInt32(Session["UserId"]));
            ddlOficerRecomended.DataTextField = "Name";
            ddlOficerRecomended.DataValueField = "SystemUserId";
            ddlOficerRecomended.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            ProgramTarget programTarget = new ProgramTarget();
            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            ProgramAssigneeController programAssigneeController = ControllerFactory.CreateProgramAssigneeController();

            programTarget.ProgramTypeId = Convert.ToInt32(ddlProgramType.SelectedValue);
            programTarget.ProgramId = Convert.ToInt32(ddlProgram.SelectedValue);

            programTarget.Title = ddlProgram.SelectedItem.Text;
            programTarget.Description = txtDescription.Text;
            programTarget.Instractions = txtInstructions.Text;
            programTarget.VoteNumber = txtVote.Text;
            programTarget.NoOfProjects = Convert.ToInt32(txtPhysicalCount.Text);
            programTarget.EstimatedAmount = (float)Convert.ToDouble(txtFinancialCount.Text);
            programTarget.TargetYear = Convert.ToInt32(ddlYear.SelectedValue);
            programTarget.TargetMonth = Convert.ToInt32(ddlMonth.SelectedValue);
            programTarget.Output = Convert.ToInt32(txtOutput.Text);
            programTarget.Outcome = Convert.ToInt32(txtOutcome.Text);
            programTarget.CreatedBy = Convert.ToInt32(Session["UserId"]);



            programTarget.IsRecommended = 0;
            programTarget.RecommendedBy = 0;
            programTarget.RecommendedDate = DateTime.Now;
            programTarget.StartDate = DateTime.Now;
            programTarget.EndDate = DateTime.Now;
            programTarget.Remarks = txtRemarks.Text;


            int TargetResponse = programTargetController.SaveProgramTarget(programTarget);
            ViewState["TargetResponseState"] = TargetResponse.ToString();
            //


            if (TargetResponse != 0)
            {
                ProgramAssignee programAssignee = new ProgramAssignee();
                ProgramAssigneeController programAssigneeController1 = ControllerFactory.CreateProgramAssigneeController();
                programAssignee.DesignationId = 1;
                programAssignee.ProgramTargetId = TargetResponse;

                programAssignee.DepartmentUnitPossitionsId = 5; // must change 

                programAssigneeController1.SaveProgramAssignee(programAssignee);

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Added Succesfully');", true);
                btnSendToReccomendation.Enabled = true;

            }
            else
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Something went wrong');", true);

            }




        }

        protected void rbTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            hideDSDivision();
        }

        private void hideDSDivision()
        {
            if (rbTarget.SelectedValue == "1")
            {
                hideDiv.Visible = false;
            }
            else
            {
                hideDiv.Visible = true;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            int TargetResponseBtn = Convert.ToInt32(ViewState["TargetResponseState"]);

            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            int selectedOficerRecomendation = Convert.ToInt32(ddlOficerRecomended.SelectedValue);


            foreach (var prop in allTargets.Where(u => u.IsRecommended == 0 && u.ProgramTargetId == TargetResponseBtn))
            {
                programTargetController.UpdateProgramTargetApprovalRecomended(TargetResponseBtn, selectedOficerRecomendation, 1);

            }
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sent Sucessfully');", true);
            pnlDialogBox.Visible = false;
        }

        protected void btnCancelDialog_Click(object sender, EventArgs e)
        {
            pnlDialogBox.Visible = false;
        }

        protected void btnSendToReccomendation_Click(object sender, EventArgs e)
        {
            pnlDialogBox.Visible = true;
        }
    }
}