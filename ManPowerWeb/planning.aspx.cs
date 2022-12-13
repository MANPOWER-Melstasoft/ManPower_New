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
        List<ProgramAssignee> programTargetsStates = new List<ProgramAssignee>();
        List<ProgramPlan> programPlansList = new List<ProgramPlan>();
        List<ProgramAssignee> programAssignees = new List<ProgramAssignee>();
        List<ProgramAssignee> programAssigneesFilter = new List<ProgramAssignee>();
        List<ProgramAssignee> filterWithMonthYear = new List<ProgramAssignee>();
        int systemUserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                bindGrid(false);

            }

        }



        private void bindGrid(bool ifSearch)
        {
            int completedCount = 0;

            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            programTargets = programTargetController.GetAllProgramTargetWithPlan();

            DepartmentUnitPositionsController departmentUnitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();

            ProgramAssigneeController programAssigneeController = ControllerFactory.CreateProgramAssigneeController();
            programAssignees = programAssigneeController.GetProgramAssignee();

            systemUserId = 3;
            programAssigneesFilter = programAssignees.Where(u => u._DepartmentUnitPositions.SystemUserId == systemUserId).ToList();
            //&& u._ProgramTarget.TargetMonth.ToString() == ddlYear.SelectedValue && u._ProgramTarget.TargetMonth.ToString() == ddlMonth.SelectedValue

            //systemUserId = departmentUnitPositionsController.departmentUnitPositionsWIthSystemUser();




            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            programPlansList = programPlanController.GetAllProgramPlan();
            filterWithMonthYear = programAssigneesFilter.Where(u => u._ProgramTarget.TargetMonth.ToString() == ddlMonth.SelectedValue && u._ProgramTarget.TargetYear.ToString() == ddlYear.SelectedValue).ToList();
            txtTargetCount.Text = filterWithMonthYear.Count.ToString();



            ViewState["programTargetsStates"] = programAssigneesFilter;
            if (ifSearch == true)
            {
                gvAnnaualPlan.DataSource = filterWithMonthYear;
            }
            else
            {
                gvAnnaualPlan.DataSource = programAssigneesFilter;
                txtTargetCount.Text = "";
            }


            gvAnnaualPlan.DataBind();
            gvAnnaualPlan.Columns[1].Visible = false;







        }

        protected void btnAddPlan_Click(object sender, EventArgs e)
        {

            programTargetsStates = (List<ProgramAssignee>)(ViewState["programTargetsStates"]);
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
            programPlan.ProgramName = programTargetsStates[rowIndex]._ProgramTarget.Description;
            programPlan.Coordinater = "";


            programPlanController.SaveProgramPlan(programPlan);

            Response.Redirect(Request.RawUrl);



        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            GridViewRow Gv2Row = (GridViewRow)((LinkButton)sender).NamingContainer;
            GridView Childgrid = (GridView)(Gv2Row.Parent.Parent);
            GridViewRow Gv1Row = (GridViewRow)(Childgrid.NamingContainer);
            rowIndex = Gv1Row.RowIndex;
            int pagesize = gvAnnaualPlan.PageSize;
            int pageindex = gvAnnaualPlan.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;

            var PrTargetId = int.Parse(gvAnnaualPlan.Rows[rowIndex].Cells[1].Text);
            var prName = gvAnnaualPlan.Rows[rowIndex].Cells[2].Text;

            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            programPlansList = programPlanController.GetAllProgramPlan();

            programPlansList = programPlansList.Where(x => x.ProgramTargetId == PrTargetId).ToList();


            Response.Redirect("planningEdit.aspx?ProgramTargetId=" + PrTargetId + "&ProgramName=" + prName);
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindGrid(true);
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            bindGrid(false);
        }





        //protected void gvPlanDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Edit")
        //    {
        //        GridViewRow Gv2Row = (GridViewRow)((LinkButton)sender).NamingContainer;
        //        GridView Childgrid = (GridView)(Gv2Row.Parent.Parent);
        //        GridViewRow Gv1Row = (GridViewRow)(Childgrid.NamingContainer);
        //        int b = Gv1Row.RowIndex;
        //    }
        //}
    }
}