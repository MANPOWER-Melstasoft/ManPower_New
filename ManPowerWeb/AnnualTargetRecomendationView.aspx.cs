using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class AnnualTargetRecomendationView : System.Web.UI.Page
    {
        int ProgramTargetId;

        List<ProgramTarget> programTargetsList = new List<ProgramTarget>();
        List<ProgramTarget> myList = new List<ProgramTarget>();
        List<ProgramType> listProgramType = new List<ProgramType>();
        List<Possitions> PositionList = new List<Possitions>();
        List<Program> program = new List<Program>();
        List<DepartmentUnitPositions> listUser = new List<DepartmentUnitPositions>();
        List<VoteAllocation> voteAllocationList = new List<VoteAllocation>();
        List<DepartmentUnit> listDistrict = new List<DepartmentUnit>();
        List<DepartmentUnit> listDSDivision = new List<DepartmentUnit>();

        protected void Page_Load(object sender, EventArgs e)
        {

            ProgramTypeController programTypeController = ControllerFactory.CreateProgramTypeController();
            listProgramType = programTypeController.GetAllProgramType(false);
            ddlProgramType.DataSource = listProgramType;
            ddlProgramType.DataTextField = "ProgramTypeName";
            ddlProgramType.DataValueField = "ProgramTypeId";
            ddlProgramType.DataBind();

            DepartmentUnitTypeController _DepartmentUnitTypeController = ControllerFactory.CreateDepartmentUnitTypeController();
            listDistrict = _DepartmentUnitTypeController.GetDepartmentUnitType(2, true)._DepartmentUnit;
            listDSDivision = _DepartmentUnitTypeController.GetDepartmentUnitType(3, true)._DepartmentUnit;

            ddlDistrict.DataSource = listDistrict;
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataValueField = "DepartmentUnitId";
            ddlDistrict.DataBind();

            ddlDSDivision.DataSource = listDSDivision;
            ddlDSDivision.DataTextField = "Name";
            ddlDSDivision.DataValueField = "DepartmentUnitId";
            ddlDSDivision.DataBind();


            PossitionsController possitionsController = ControllerFactory.CreatePossitionsController();
            PositionList = possitionsController.GetAllPossitions(false, false);
            ddlPosition.DataSource = PositionList;
            ddlPosition.DataTextField = "PositionName";
            ddlPosition.DataValueField = "PossitionId";
            ddlPosition.DataBind();

            bindData();
            int status = Convert.ToInt32(Request.QueryString["Status"]);
            if (status == 1)
            {
                btnAccept.Visible = true;
                btnModalReject.Visible = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            Response.Redirect("AnnualTargetRecomendation.aspx");

        }
        private void bindData()
        {
            ProgramTargetId = Convert.ToInt32(Request.QueryString["ProgramTargetId"]);

            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            programTargetsList = programTargetController.GetAllProgramTarget(true, true, true, true);



            ProgramController programController = ControllerFactory.CreateProgramController();
            program = programController.GetAllProgram(false, false);
            ddlProgram.DataSource = program;
            ddlProgram.DataTextField = "ProgramName";
            ddlProgram.DataValueField = "ProgramId";
            ddlProgram.DataBind();

            VoteAllocationController voteAllocationController = ControllerFactory.CreateVoteAllocationController();

            voteAllocationList = voteAllocationController.GetAllVoteAllocation(false);




            foreach (var i in programTargetsList.Where(u => u.ProgramTargetId == ProgramTargetId))
            {
                myList.Add(i);
            }

            DepartmentUnitPositionsController departmentUnitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
            DepartmentUnitPositions departmentUnitPositions = departmentUnitPositionsController.GetDepartmentUnitPositions(myList[0]._ProgramAssignee[0].DepartmentUnitPossitionsId, false, false, true, true, true);

            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            // SystemUser systemUser = systemUserController.GetSystemUser(myList[0]._ProgramAssignee[0].ProgramAssigneeId,true, false, false);

            voteAllocationList = voteAllocationList.Where(x => x.Id == Convert.ToInt32(myList[0].VoteNumber)).ToList();

            lblofficer.Text = departmentUnitPositions._SystemUser.Name;
            ddlYear.SelectedValue = Convert.ToString(myList[0].TargetYear);
            ddlMonth.Text = myList[0].TargetMonth.ToString();
            txtDescription.Text = myList[0].Description;
            txtVote.Text = voteAllocationList[0].VoteNumber;
            ddlMonth.Text = myList[0].TargetMonth.ToString();
            txtInstructions.Text = myList[0].Instractions.ToString();
            txtOutcome.Text = myList[0].Outcome.ToString();
            txtFinancialCount.Text = myList[0].EstimatedAmount.ToString();
            txtOutput.Text = myList[0].Output.ToString();
            txtPhysicalCount.Text = myList[0].NoOfProjects.ToString();
            ddlProgramType.SelectedValue = myList[0].ProgramTypeId.ToString();
            ddlProgram.SelectedValue = myList[0].ProgramId.ToString();
            txtStratDate.Text = myList[0].StartDate.ToString("yyyy-MM-dd");
            txtEndDate.Text = myList[0].EndDate.ToString("yyyy-MM-dd");

            ddlDistrict.SelectedValue = departmentUnitPositions._DepartmentUnit.ParentId.ToString();
            ddlDSDivision.SelectedValue = departmentUnitPositions._DepartmentUnit.DepartmentUnitId.ToString();
            ddlPosition.SelectedValue = departmentUnitPositions.PossitionsId.ToString();


        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            int TargetResponse = programTargetController.UpdateProgramTargetApproval(ProgramTargetId, 2, "");

            if (TargetResponse != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Added Succesfully!', 'success');window.setTimeout(function(){window.location='AnnualTargetRecomendation.aspx'},2500);", true);


            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);
            }




        }


        protected void btnReject_Click1(object sender, EventArgs e)
        {
            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            int TargetResponse = programTargetController.UpdateProgramTargetApproval(ProgramTargetId, 3, txtrejectReason.Text);

            if (TargetResponse != 0)
            {

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Rejected Succesfully!', 'success');window.setTimeout(function(){window.location='AnnualTargetRecomendation.aspx'},2500);", true);

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);
            }


        }
    }
}