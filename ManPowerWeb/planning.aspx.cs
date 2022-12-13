using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease.Css.Extensions;

namespace ManPowerWeb
{
    public partial class planning : System.Web.UI.Page
    {
        List<ProjectStatus> projectStatuses = new List<ProjectStatus>();
        List<ProgramTarget> programTargets = new List<ProgramTarget>();
        List<ProgramTarget> programTargetsStates = new List<ProgramTarget>();
        List<ProgramPlan> programPlansList = new List<ProgramPlan>();
        List<ProgramAssignee> programAssignees = new List<ProgramAssignee>();
        List<ProgramAssignee> programAssigneesFilter = new List<ProgramAssignee>();
        int systemUserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                bindDataSource();
                bindGrid();
            }

        }

        private void bindDataSource()
        {
            ProjectStatusController projectStatusController = ControllerFactory.CreateProjectStatusController();
            projectStatuses = projectStatusController.GetAllProjectStatus(true);
            ddlSearch.DataSource = projectStatuses;
            ddlSearch.DataValueField = "ProjectStatusId";
            ddlSearch.DataTextField = "ProjectStatusName";
            ddlSearch.DataBind();
        }

        private void bindGrid()
        {
            int completedCount = 0;
            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            programTargets = programTargetController.GetAllProgramTargetWithPlan();

            DepartmentUnitPositionsController departmentUnitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();

            ProgramAssigneeController programAssigneeController = ControllerFactory.CreateProgramAssigneeController();
            programAssignees = programAssigneeController.GetProgramAssignee();

            systemUserId = 3;
            programAssigneesFilter = programAssignees.Where(u => u._DepartmentUnitPositions.SystemUserId == systemUserId).ToList();

            //systemUserId = departmentUnitPositionsController.departmentUnitPositionsWIthSystemUser();




            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            programPlansList = programPlanController.GetAllProgramPlan();

            ViewState["programTargetsStates"] = programAssigneesFilter;
            gvAnnaualPlan.DataSource = programAssigneesFilter;
            gvAnnaualPlan.DataBind();

            txtAnnualPlanCount.Text = programTargets.Count.ToString();
            txtProgramPlanCount.Text = programPlansList.Count.ToString();

            foreach (ProgramPlan plan in programPlansList.Where(x => x.ProjectStatusId == 4))
            {

                completedCount++;
            }

            txtCompletedCount.Text = completedCount.ToString();
            txtNotProgramCount.Text = (programTargets.Count - programPlansList.Count).ToString();




        }

        protected void btnAddPlan_Click(object sender, EventArgs e)
        {

            programTargetsStates = (List<ProgramTarget>)(ViewState["programTargetsStates"]);
            ProgramPlan programPlan = new ProgramPlan();
            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            programPlan.Date = DateTime.Now;
            programPlan.ProjectStatusId = 1;
            programPlan.ProgramName = "";
            programPlan.FinancialSource = "";
            programPlan.ProgramCategoryId = 1;
            programPlan.Location = "";
            programPlan.Outcome = 0;
            programPlan.Output = 0;
            programPlan.ActualOutput = 0;
            programPlan.IsApproved = 0;
            programPlan.ApprovedBy = "";
            programPlan.ApprovedDate = DateTime.Now;
            programPlan.TotalEstimatedAmount = 0;
            programPlan.ApprovedAmount = 0;
            programPlan.ActualAmount = 0;
            programPlan.MaleCount = 0;
            programPlan.FemaleCount = 0;
            programPlan.Remark = "";
            programPlan.ProgramTargetId = programTargetsStates[rowIndex].ProgramTargetId;
            programPlan.ProgramName = programTargetsStates[rowIndex].Description;
            programPlan.Coordinater = "";


            programPlanController.SaveProgramPlan(programPlan);



        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = gvAnnaualPlan.PageSize;
            int pageindex = gvAnnaualPlan.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;

            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            programTargets = programTargetController.GetAllProgramTargetWithPlan();

            Response.Redirect("planningEdit.aspx?ProgramTargetId=" + programTargets[rowIndex].ProgramTargetId.ToString() + "&ProgramName=" + programTargets[rowIndex].Description);
        }



        protected void gvAnnualPlan_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvPlanDetails = e.Row.FindControl("gvPlanDetails") as GridView;
                ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
                programTargets = programTargetController.GetAllProgramTargetWithPlan();
                gvPlanDetails.DataSource = programTargets;
                gvPlanDetails.DataBind();
            }
        }

        protected void gvAnnaualPlan_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            programPlansList = programPlanController.GetAllProgramPlan();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string programTargetID = gvAnnaualPlan.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvPlanDetails = e.Row.FindControl("gvPlanDetails") as GridView;
                gvPlanDetails.DataSource = programPlansList.Where(x => x.ProgramTargetId.ToString() == programTargetID);
                gvPlanDetails.DataBind();

            }
        }
    }
}