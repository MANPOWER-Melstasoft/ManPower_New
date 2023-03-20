using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        List<VoteAllocation> voteAllocationList = new List<VoteAllocation>();

        protected void Page_Load(object sender, EventArgs e)
        {

            DesignationController designationController = ControllerFactory.CreateDesignationController();
            listDesignation = designationController.GetAllDesignation(false, true, false);

            DepartmentUnitPositionsController unitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
            listUser = unitPositionsController.GetAllDepartmentUnitPositions(false, false, true, false, true);

            //ProgramController programController = ControllerFactory.CreateProgramController();
            //program = programController.GetAllProgram(false);

            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            allTargets = programTargetController.GetAllProgramTarget(false, false, false, false);


            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            //diloagBox.Visible = false;

            if (!IsPostBack)
            {
                BindDataSource();
                //hideDSDivision();

                bindDSDivision();
                bindProgram();
                bindOfficerList();

                bindOficerRecomendation();
                int year = DateTime.Now.Year;
                for (int i = year; i <= year + 5; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    ddlYear.Items.Add(li);
                }
                //ddlYear.Items.FindByText(year.ToString()).Selected = true;
                ddlYear.Items.Insert(0, new ListItem("Select Year", ""));

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
            ddlDistrict.Items.Insert(0, new ListItem("Select District", ""));






            PossitionsController possitionsController = ControllerFactory.CreatePossitionsController();
            PositionList = possitionsController.GetAllPossitions(false, false);
            ddlPosition.DataSource = PositionList;
            ddlPosition.DataTextField = "PositionName";
            ddlPosition.DataValueField = "PossitionId";
            ddlPosition.DataBind();
            ddlPosition.Items.Insert(0, new ListItem("Select Position", ""));


            ProgramTypeController programTypeController = ControllerFactory.CreateProgramTypeController();
            listProgramType = programTypeController.GetAllProgramType(false);
            ddlProgramType.DataSource = listProgramType;
            ddlProgramType.DataTextField = "ProgramTypeName";
            ddlProgramType.DataValueField = "ProgramTypeId";

            ddlProgramType.DataBind();
            ddlProgramType.Items.Insert(0, new ListItem("Select Program Type", ""));


            //SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            //listUsers = systemUserController.GetAllSystemUser(true, false, false);



        }

        private void bindOfficerList()
        {
            DepartmentUnitPositionsController unitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
            listUser = unitPositionsController.GetAllDepartmentUnitPositions(false, false, true, false, true);

            OfficerListController officerListController = ControllerFactory.CreateOfficerListController();

            List<OfficerList> listSystemUseerOfficer = new List<OfficerList>();
            listSystemUseerOfficer = officerListController.getOfficerList();
            listSystemUseerOfficer = listSystemUseerOfficer.Where(x => x.UserTypeId == 6 || x.UserTypeId == 7 || x.UserTypeId == 8 || x.UserTypeId == 9).ToList();

            if (ddlPosition.SelectedValue != "")
            {
                if (rbTarget.SelectedValue == "1" && ddlDistrict.SelectedValue != "")
                {
                    ddlOfficer.DataSource = listSystemUseerOfficer.Where(u => u.ParentId == 1 && u.DepartmentUnitId == int.Parse(ddlDistrict.SelectedValue) && u.PossitionId == int.Parse(ddlPosition.SelectedValue) && u.SystemUserId != Convert.ToInt32(Session["UserId"]));

                }
                else if (rbTarget.SelectedValue == "2" && ddlDSDivision.SelectedValue != "" && ddlDistrict.SelectedValue != "")
                {
                    ddlOfficer.DataSource = listSystemUseerOfficer.Where(u => u.ParentId == int.Parse(ddlDistrict.SelectedValue) && u.PossitionId == int.Parse(ddlPosition.SelectedValue) && u.DepartmentUnitId == int.Parse(ddlDSDivision.SelectedValue) && u.SystemUserId != Convert.ToInt32(Session["UserId"]));
                }
                else
                {
                    ddlOfficer.Items.Clear();

                }

            }

            else
            {
                if (rbTarget.SelectedValue == "1" && ddlDistrict.SelectedValue != "")
                {
                    ddlOfficer.DataSource = listSystemUseerOfficer.Where(u => u.ParentId == 1 && u.DepartmentUnitId == int.Parse(ddlDistrict.SelectedValue) && u.SystemUserId != Convert.ToInt32(Session["UserId"]));

                }
                else if (rbTarget.SelectedValue == "2" && ddlDistrict.SelectedValue != "" && ddlDSDivision.SelectedValue != "")
                {

                    ddlOfficer.DataSource = listSystemUseerOfficer.Where(u => u.ParentId == int.Parse(ddlDistrict.SelectedValue) && u.DepartmentUnitId == int.Parse(ddlDSDivision.SelectedValue) && u.SystemUserId != Convert.ToInt32(Session["UserId"]));

                }
                else
                {
                    ddlOfficer.Items.Clear();
                }


            }



            ddlOfficer.DataValueField = "SystemUserId";
            ddlOfficer.DataTextField = "Name";
            ddlOfficer.DataBind();
            ddlOfficer.Items.Insert(0, new ListItem("Select Officer", ""));

        }
        private void bindProgram()
        {
            ProgramController programController = ControllerFactory.CreateProgramController();
            program = programController.GetAllProgram(true, false, false);
            if (ddlProgramType.SelectedValue != "")
            {
                ddlProgram.DataSource = program.Where(u => u.ProgramType.ToString() == ddlProgramType.SelectedValue);
                ddlProgram.DataTextField = "ProgramName";
                ddlProgram.DataValueField = "ProgramId";

                ddlProgram.DataBind();
                ddlProgram.Items.Insert(0, new ListItem("Select Program ", ""));

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
            if (rbTarget.SelectedValue == "2")
            {
                bindDSDivision();
            }
            else
            {
                bindOfficerList();
            }
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
                ddlDSDivision.Items.Insert(0, new ListItem("Select Division", ""));

            }
            else
            {
                ddlDSDivision.Items.Clear();
            }

        }

        private void bindVote(string year)
        {
            VoteAllocationController voteAllocationController = ControllerFactory.CreateVoteAllocationController();

            voteAllocationList = voteAllocationController.GetAllVoteAllocation(false);
            ddlVote.DataSource = voteAllocationList.Where(x => Convert.ToDateTime(x.Year).Year.ToString() == year);
            ddlVote.DataTextField = "VoteNumber";
            ddlVote.DataValueField = "Id";
            ddlVote.DataBind();
            ddlVote.Items.Insert(0, new ListItem("Select Vote", ""));
        }

        private void bindMonth()
        {
            ddlMonth.Enabled = true;
            var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            for (int i = 0; i < months.Length - 1; i++)
            {
                ddlMonth.Items.Add(new ListItem(months[i], (i + 1).ToString()));
            }
            ddlMonth.Items.Insert(0, new ListItem("Select Month", ""));
        }

        private void bindOficerRecomendation()
        {
            List<SystemUser> listOficerRecomendation = new List<SystemUser>();
            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            listOficerRecomendation = systemUserController.GetAllSystemUser(true, false, false);



            if (ddlOfficer.SelectedValue != "")
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                int selectedOfficerid = Convert.ToInt32(ViewState["SelectedOfficer"]);
                //ddlOficerRecomended.DataSource = listOficerRecomendation.Where(u => u.UserTypeId == 2 && u.SystemUserId != userId && u.SystemUserId != selectedOfficerid);
                ddlOficerRecomended.DataSource = listOficerRecomendation.Where(u => u._DepartmentUnitPositions.DepartmetUnitPossitionsId == Convert.ToInt32(Session["DepUnitParentId"]));

                ddlOficerRecomended.DataTextField = "Name";
                ddlOficerRecomended.DataValueField = "SystemUserId";
                ddlOficerRecomended.DataBind();
            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            ProgramTarget programTarget = new ProgramTarget();
            ProgramAssignee programAssignee = new ProgramAssignee();

            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            ProgramAssigneeController programAssigneeController = ControllerFactory.CreateProgramAssigneeController();

            List<DepartmentUnitPositions> getdepartmentUnitPositionsIdList = new List<DepartmentUnitPositions>();
            DepartmentUnitPositionsController departmentUnitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();

            ViewState["SelectedOfficer"] = ddlOfficer.SelectedValue;
            getdepartmentUnitPositionsIdList = departmentUnitPositionsController.GetAllDepartmentUnitPositions(Convert.ToInt32(ddlOfficer.SelectedValue));

            programTarget.ProgramTypeId = Convert.ToInt32(ddlProgramType.SelectedValue);
            programTarget.ProgramId = Convert.ToInt32(ddlProgram.SelectedValue);

            programTarget.Title = ddlProgram.SelectedItem.Text;
            programTarget.Description = txtDescription.Text;
            programTarget.Instractions = txtInstructions.Text;
            programTarget.VoteNumber = ddlVote.SelectedValue;

            if (ddlProgram.SelectedValue == "7" || ddlProgram.SelectedValue == "8" || ddlProgram.SelectedValue == "9"
               || ddlProgram.SelectedValue == "10" || ddlProgram.SelectedValue == "11" || ddlProgram.SelectedValue == "12")
            {
                programTarget.NoOfProjects = 1;
                programTarget.BeneficiaryCount = Convert.ToInt32(txtBeneCount.Text);
            }
            else
            {
                programTarget.NoOfProjects = Convert.ToInt32(txtPhysicalCount.Text);
                programTarget.BeneficiaryCount = 0;
            }

            programTarget.EstimatedAmount = (float)Convert.ToDouble(txtFinancialCount.Text);
            programTarget.TargetYear = Convert.ToInt32(ddlYear.SelectedValue);
            programTarget.Period_Type = ddlType.SelectedValue;
            programTarget.Outcome_Description = txtOutcomeDes.Text;
            programTarget.Output_Description = txtOutputDes.Text;

            if (ddlMonth.SelectedValue == "")
            {
                programTarget.TargetMonth = 0;

            }
            else
            {
                programTarget.TargetMonth = Convert.ToInt32(ddlMonth.SelectedValue);

            }


            if (txtOutput.Text != "")
            {
                programTarget.Output = Convert.ToInt32(txtOutput.Text);
            }
            else
            {
                programTarget.Output = 0;

            }

            if (txtOutcome.Text != "")
            {
                programTarget.Outcome = Convert.ToInt32(txtOutcome.Text);

            }
            else
            {
                programTarget.Outcome = 0;

            }


            programTarget.CreatedBy = Convert.ToInt32(Session["UserId"]);



            programTarget.IsRecommended = 0;
            programTarget.RecommendedBy = 0;
            programTarget.RecommendedDate = DateTime.Now;
            programTarget.StartDate = Convert.ToDateTime(ddlStartDate.Text);
            programTarget.EndDate = Convert.ToDateTime(txtEndDate.Text);

            programTarget.Remarks = txtRemarks.Text;

            programAssignee.DesignationId = 1;  // 

            programAssignee.DepartmentUnitPossitionsId = getdepartmentUnitPositionsIdList[0].DepartmetUnitPossitionsId;


            int TargetResponse = programTargetController.SaveProgramTarget(programTarget, programAssignee);



            ViewState["TargetResponseState"] = TargetResponse.ToString();

            //


            if (TargetResponse != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success')", true);
                btnSendToRecommendation.Visible = true;
                btnSave.Visible = false;
                bindOficerRecomendation();

                //clear();

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);

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
                rowdistrict.Visible = true;
                hideDiv.Visible = false;
            }
            if (rbTarget.SelectedValue == "2")
            {
                rowdistrict.Visible = true;
                hideDiv.Visible = true;
            }
        }



        protected void btnCancelDialog_Click(object sender, EventArgs e)
        {
            // pnlDialogBox.Visible = false;
        }

        protected void btnSendToReccomendation_Click(object sender, EventArgs e)
        {
            //pnlDialogBox.Visible = true;
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlYear.SelectedIndex > 0)
            {
                bindVote(ddlYear.Text);
                bindStartDateEndDate();
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlYear.SelectedValue != "")
            {
                if (ddlType.SelectedValue == "6")
                {
                    ddlStartDate.Text = "";
                    txtEndDate.Text = "";
                    bindMonth();
                }
                else
                {

                    bindStartDateEndDate();
                    ddlMonth.Items.Clear();
                    ddlMonth.Enabled = false;

                }

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Warning!', 'Select a target year first!', 'warning')", true);

                ddlMonth.Items.Clear();
            }

        }

        private void bindStartDateEndDate()
        {
            if (ddlType.SelectedValue == "1")
            {
                ddlStartDate.Text = ddlYear.SelectedItem.Text + "-01-01";
                txtEndDate.Text = ddlYear.SelectedItem.Text + "-12-31";
                ddlMonth.Enabled = false;
            }
            else if (ddlType.SelectedValue == "2")
            {
                ddlStartDate.Text = ddlYear.SelectedItem.Text + "-01-01";
                txtEndDate.Text = ddlYear.SelectedItem.Text + "-03-30";
                ddlMonth.Enabled = false;

            }
            else if (ddlType.SelectedValue == "3")
            {
                ddlStartDate.Text = ddlYear.SelectedItem.Text + "-04-01";
                txtEndDate.Text = ddlYear.SelectedItem.Text + "-06-30";
                ddlMonth.Enabled = false;

            }
            else if (ddlType.SelectedValue == "4")
            {
                ddlStartDate.Text = ddlYear.SelectedItem.Text + "-07-01";
                txtEndDate.Text = ddlYear.SelectedItem.Text + "-09-30";
                ddlMonth.Enabled = false;

            }
            else if (ddlType.SelectedValue == "5")
            {
                ddlStartDate.Text = ddlYear.SelectedItem.Text + "-10-01";
                txtEndDate.Text = ddlYear.SelectedItem.Text + "-12-31";
                ddlMonth.Enabled = false;

            }
            else
            {
                ddlStartDate.Text = "";
                txtEndDate.Text = "";
                ddlMonth.Enabled = true;

            }

        }

        protected void ddlDSDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindOfficerList();
        }

        protected void btnSend_Click1(object sender, EventArgs e)
        {

            int TargetResponseBtn = Convert.ToInt32(ViewState["TargetResponseState"]);

            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            int selectedOficerRecomendation = Convert.ToInt32(ddlOficerRecomended.SelectedValue);


            foreach (var prop in allTargets.Where(u => u.IsRecommended == 0 && u.ProgramTargetId == TargetResponseBtn))
            {
                programTargetController.UpdateProgramTargetApprovalRecomended(TargetResponseBtn, selectedOficerRecomendation, 1);

            }

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Send Recommendation Succesfully!', 'success')", true);
            Response.Redirect(Request.RawUrl);
        }

        protected void ddlPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindOfficerList();
        }

        protected void clear()
        {
            ddlProgram.SelectedItem.Text = "";
            txtDescription.Text = "";
            txtInstructions.Text = "";
            ddlVote.SelectedValue = "";
            ddlDistrict.SelectedValue = "";
            ddlDSDivision.SelectedValue = "";
            txtFinancialCount.Text = null;
            txtEndDate.Text = null;
            ddlStartDate.Text = null;
            txtOutcome.Text = null;
            ddlPosition.SelectedValue = "";
            ddlYear.SelectedValue = "";
            ddlMonth.SelectedValue = "";
            txtPhysicalCount.Text = null;
            ddlProgramType.SelectedValue = "";
            ddlOfficer.SelectedValue = "";
            txtOutcome.Text = "";
            txtOutcomeDes.Text = "";
            txtOutput.Text = "";
            txtOutputDes.Text = "";
            txtRemarks.Text = "";
            rbTarget.ClearSelection();



        }



        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMonth.SelectedValue != "")
            {
                DateTime startOfMonth = new DateTime(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue), 1);
                DateTime endOfMonth = new DateTime(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue), DateTime.DaysInMonth(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue)));

                ddlStartDate.Text = startOfMonth.ToShortDateString();
                txtEndDate.Text = endOfMonth.ToShortDateString();
            }


        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnnualTarget.aspx");
        }
    }
}