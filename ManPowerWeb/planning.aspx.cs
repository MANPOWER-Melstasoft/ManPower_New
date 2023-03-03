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
using System.Globalization;

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

                int year = DateTime.Now.Year;
                for (int i = year - 10; i <= year + 5; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    ddlYear.Items.Add(li);
                }
                bindGrid(false);

            }

        }



        private void bindGrid(bool ifSearch)
        {

            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            programTargets = programTargetController.GetAllProgramTargetWithPlan();

            DepartmentUnitPositionsController departmentUnitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();

            ProgramAssigneeController programAssigneeController = ControllerFactory.CreateProgramAssigneeController();
            programAssignees = programAssigneeController.GetProgramAssignee();

            systemUserId = Convert.ToInt32(Session["UserId"]);


            programAssigneesFilter = programAssignees.Where(u => u._DepartmentUnitPositions.SystemUserId == systemUserId && u._ProgramTarget.IsRecommended == 2).ToList();
            //&& u._ProgramTarget.TargetMonth.ToString() == ddlYear.SelectedValue && u._ProgramTarget.TargetMonth.ToString() == ddlMonth.SelectedValue

            //systemUserId = departmentUnitPositionsController.departmentUnitPositionsWIthSystemUser();




            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            programPlansList = programPlanController.GetAllProgramPlan();
            filterWithMonthYear = programAssigneesFilter.Where(u => (u._ProgramTarget.TargetMonth.ToString() == ddlMonth.SelectedValue || u._ProgramTarget.StartDate.Month.ToString() == ddlMonth.SelectedValue) && u._ProgramTarget.TargetYear.ToString() == ddlYear.SelectedValue).ToList();




            if (ifSearch == true)
            {
                gvAnnaualPlan.DataSource = filterWithMonthYear;
                ViewState["programTargetsStates"] = filterWithMonthYear;
            }
            else
            {
                gvAnnaualPlan.DataSource = programAssigneesFilter;
                ViewState["programTargetsStates"] = programAssigneesFilter;
            }


            gvAnnaualPlan.DataBind();
            gvAnnaualPlan.Columns[1].Visible = false;
            gvAnnaualPlan.Columns[7].Visible = false;

        }

        protected void btnAddPlan_Click(object sender, EventArgs e)
        {

            programTargetsStates = (List<ProgramAssignee>)(ViewState["programTargetsStates"]);
            ProgramPlan programPlan = new ProgramPlan();
            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();


            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = gvAnnaualPlan.PageSize;
            int pageindex = gvAnnaualPlan.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;

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


            int rowindexChild = Gv2Row.RowIndex;

            int pagesize = gvAnnaualPlan.PageSize;
            int pageindex = gvAnnaualPlan.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;


            var PrTargetId = int.Parse(gvAnnaualPlan.Rows[rowIndex].Cells[1].Text);
            var prName = gvAnnaualPlan.Rows[rowIndex].Cells[2].Text;

            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            programPlansList = programPlanController.GetAllProgramPlan();

            programPlansList = programPlansList.Where(x => x.ProgramTargetId == PrTargetId).ToList();


            Response.Redirect("planningEdit.aspx?ProgramTargetId=" + PrTargetId + "&ProgramplanId=" + programPlansList[rowindexChild].ProgramPlanId);

        }


        protected void gvAnnaualPlan_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            programPlansList = programPlanController.GetAllProgramPlan();


            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                string programTargetID = gvAnnaualPlan.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvPlanDetails = e.Row.FindControl("gvPlanDetails") as GridView;

                LinkButton button = (LinkButton)e.Row.FindControl("btnAddPlan");

                Label lbl = e.Row.FindControl("lblPlannedCount") as Label;


                programPlansList = programPlansList.Where(x => x.ProgramTargetId.ToString() == programTargetID).ToList();

                ViewState["programPlansListCount"] = programPlansList.Count();


                lbl.Text = programPlansList.Count.ToString();
                gvPlanDetails.DataSource = programPlansList;
                gvPlanDetails.DataBind();
                if (lbl.Text != "" && e.Row.Cells[8].Text != "")
                {

                    if (Convert.ToInt32(lbl.Text) < Convert.ToInt32(e.Row.Cells[9].Text))
                    {
                        button.Enabled = true;

                    }
                    else
                    {
                        button.Enabled = false;

                    }
                }




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

        protected void btnView_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            GridViewRow Gv2Row = (GridViewRow)((LinkButton)sender).NamingContainer;
            GridView Childgrid = (GridView)(Gv2Row.Parent.Parent);
            GridViewRow Gv1Row = (GridViewRow)(Childgrid.NamingContainer);
            rowIndex = Gv1Row.RowIndex;


            int rowindexChild = Gv2Row.RowIndex;

            int pagesize = gvAnnaualPlan.PageSize;
            int pageindex = gvAnnaualPlan.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;


            var PrTargetId = int.Parse(gvAnnaualPlan.Rows[rowIndex].Cells[1].Text);
            var prName = gvAnnaualPlan.Rows[rowIndex].Cells[2].Text;

            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            programPlansList = programPlanController.GetAllProgramPlan();

            programPlansList = programPlansList.Where(x => x.ProgramTargetId == PrTargetId).ToList();


            Response.Redirect("planningEdit.aspx?ProgramTargetId=" + PrTargetId + "&ProgramplanId=" + programPlansList[rowindexChild].ProgramPlanId);
        }

        protected void btnEnterProgramDetails_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            GridViewRow Gv2Row = (GridViewRow)((LinkButton)sender).NamingContainer;
            GridView Childgrid = (GridView)(Gv2Row.Parent.Parent);
            GridViewRow Gv1Row = (GridViewRow)(Childgrid.NamingContainer);
            rowIndex = Gv1Row.RowIndex;


            int rowindexChild = Gv2Row.RowIndex;

            int pagesize = gvAnnaualPlan.PageSize;
            int pageindex = gvAnnaualPlan.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;


            var PrTargetId = int.Parse(gvAnnaualPlan.Rows[rowIndex].Cells[1].Text);
            var prName = gvAnnaualPlan.Rows[rowIndex].Cells[2].Text;

            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            programPlansList = programPlanController.GetAllProgramPlan();

            programPlansList = programPlansList.Where(x => x.ProgramTargetId == PrTargetId).ToList();


            Response.Redirect("planningEdit.aspx?ProgramTargetId=" + PrTargetId + "&ProgramplanId=" + programPlansList[rowindexChild].ProgramPlanId);
        }

        protected void gvPlanDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell cell = e.Row.Cells[0];
                string cellValue = cell.Text;

                if (Convert.ToDateTime(e.Row.Cells[2].Text) < DateTime.Now)
                {
                    LinkButton childEditButton = (LinkButton)e.Row.FindControl("btnEdit");
                    childEditButton.Text = "Enter Program Details";
                }
            }
        }





    }

    //protected void gvPlanDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        LinkButton childEditButton = (LinkButton)e.Row.FindControl("btnEdit");

    //        if (e.Row.Cells[6].Text == "Complete")
    //        {
    //            childEditButton.Text = "View";
    //        }
    //        else
    //        {
    //            childEditButton.Text = "Edit";

    //        }

    //    }
    //}




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

    //   foreach (GridViewRow row in gvAnnaualPlan.Rows)
    //    {


    //        Label lbl1 = (Label)row.FindControl("lblPlannedCount");
    //lbl1.Text = ViewState["programPlansListCount"].ToString();
    //lbl1.Text = programPlansList.Count.ToString()};


}
