using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class Dashboard : System.Web.UI.Page
    {

        List<ProgramTarget> programTargetsList = new List<ProgramTarget>();
        List<DepartmentUnitPositions> DepartmentUnitPositionsList = new List<DepartmentUnitPositions>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //----------------------To clear cache in browser ----------------

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();

            //----------------------END ----------------

            if (Session["UserId"] != null)
            {

                if (!IsPostBack)
                {

                    if (Convert.ToInt32(Session["UserTypeId"]) == 1 || Convert.ToInt32(Session["UserTypeId"]) == 2)
                    {
                        IsNotSubmitDMEParentGV();
                    }
                    if (Convert.ToInt32(Session["UserTypeId"]) == 3 && IsNotSubmitDME())
                    {
                        RaiseNotification();
                    }
                    BindCardData();
                    bindDialogbox();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected bool IsNotSubmitDME()
        {
            if (DateTime.Now.Day > 25)
            {
                int DepUnitPossiId = Convert.ToInt32(Session["DepUnitPositionId"]);
                TaskAllocationController taskAllocationController = ControllerFactory.CreateTaskAllocationController();
                List<TaskAllocation> taskAllocations = taskAllocationController.GetAllTaskAllocationByDepartmentUnitPositionId(DepUnitPossiId);

                List<TaskAllocation> taskAllocationsFinal = new List<TaskAllocation>();

                foreach (var item in taskAllocations)
                {
                    DateTime dateTime = item.TaskYearMonth;

                    DateTime currentDate = DateTime.Now;
                    DateTime nextMonth = currentDate.AddMonths(1);

                    //DateTime nextMonth = DateTime.Now;
                    //nextMonth.AddMonths(1);

                    if (dateTime.Year == DateTime.Today.Year && dateTime.Month == nextMonth.Month && item.StatusId != 0)
                    {
                        taskAllocationsFinal.Add(item);
                    }
                }

                if (taskAllocationsFinal.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        protected void IsNotSubmitDMEParentGV()
        {
            if (DateTime.Now.Day > 25)
            {
                SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
                List<SystemUser> systemUserList = systemUserController.GetAllSystemUser(true, false, false);
                List<SystemUser> systemUserListFilter = new List<SystemUser>();
                List<SystemUser> systemUserListFilterFinal = new List<SystemUser>();

                if (Session["UserTypeId"].ToString() == "1")
                {
                    systemUserList.RemoveAll(x => x.SystemUserId == Convert.ToInt32(Session["UserId"]));
                    systemUserList.RemoveAll(x => x.UserTypeId == 1);
                    systemUserList.RemoveAll(x => x.UserTypeId == 4);
                    systemUserList.RemoveAll(x => x.UserTypeId == 5);

                    systemUserListFilter = systemUserList.ToList();
                    systemUserListFilterFinal = systemUserList.ToList();
                }
                if (Session["UserTypeId"].ToString() == "2")
                {
                    SystemUser systemUser = systemUserController.GetSystemUser(Convert.ToInt32(Session["UserId"]), true, false, false);
                    systemUserListFilter = systemUserList.Where(x => x._DepartmentUnitPositions.ParentId == systemUser._DepartmentUnitPositions.DepartmetUnitPossitionsId).ToList();
                    systemUserListFilterFinal = systemUserListFilter.ToList();
                }



                foreach (var item in systemUserListFilter)
                {
                    int DepUnitPossiId = item._DepartmentUnitPositions.DepartmetUnitPossitionsId;
                    TaskAllocationController taskAllocationController = ControllerFactory.CreateTaskAllocationController();
                    List<TaskAllocation> taskAllocations = taskAllocationController.GetAllTaskAllocationByDepartmentUnitPositionId(DepUnitPossiId);

                    foreach (var itemTask in taskAllocations)
                    {
                        DateTime dateTime = itemTask.TaskYearMonth;

                        DateTime currentDate = DateTime.Now;
                        DateTime nextMonth = currentDate.AddMonths(1);

                        if (dateTime.Year == DateTime.Today.Year && dateTime.Month == nextMonth.Month && itemTask.StatusId != 0)
                        {
                            systemUserListFilterFinal.RemoveAll(x => x.SystemUserId == item.SystemUserId);
                        }

                    }
                }
                if (systemUserListFilterFinal.Count > 0)
                {
                    DME21Heading.Visible = true;
                }

                gvUser.DataSource = systemUserListFilterFinal;
                gvUser.DataBind();

            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUser.PageIndex = e.NewPageIndex;
            IsNotSubmitDMEParentGV();

        }
        protected void RaiseNotification()
        {
            if (Session["DME21Notifi"] == null)
            {
                Session["DME21Notifi"] = "1";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Alert!', 'You have to Submit DME 21 quickly!', 'warning');", true);
            }
        }

        protected void BindCardData()
        {
            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            List<SystemUser> systemUserList = systemUserController.GetAllSystemUser(true, false, false);
            if (Session["UserTypeId"].ToString() == "1")
            {
                systemUserList.RemoveAll(x => x.SystemUserId == Convert.ToInt32(Session["UserId"]));
                lblNumberOfEmp.Text = systemUserList.Count.ToString();
            }
            if (Session["UserTypeId"].ToString() == "2")
            {
                SystemUser systemUser = systemUserController.GetSystemUser(Convert.ToInt32(Session["UserId"]), true, false, false);
                List<SystemUser> systemUserListFilter = systemUserList.Where(x => x._DepartmentUnitPositions.ParentId == systemUser._DepartmentUnitPositions.DepartmetUnitPossitionsId).ToList();
                lblNumberOfEmp.Text = systemUserListFilter.Count.ToString();
            }


            VoteAllocationController voteAllocationController = ControllerFactory.CreateVoteAllocationController();
            List<VoteAllocation> voteAllocationList = voteAllocationController.GetAllVoteAllocation(false);
            float vCount = 0;
            foreach (var i in voteAllocationList)
            {
                if (i.Year.Year == DateTime.Today.Year)
                {
                    vCount += i.Amount;
                }
            }
            lblVoteAmount.Text = vCount.ToString("N");


            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            List<ProgramPlan> programPlanList = programPlanController.GetAllProgramPlan();
            //List<ProgramPlan> programPlanFilter = programPlanList.Where(x => x.Date.Year == DateTime.Today.Year).ToList();
            lblTotalProgramms.Text = programPlanList.Count.ToString();

            List<ProgramPlan> programPlanFilterUCTM = programPlanList.Where(x => x.Date.Year == DateTime.Today.Year && x.Date.Month == DateTime.Today.Month && x.ActualOutput == 0).ToList();
            lblUCTM.Text = programPlanFilterUCTM.Count.ToString();

            List<ProgramPlan> programPlanFilterCP = programPlanList.Where(x => x.ActualOutput != 0).ToList();
            lblCP.Text = programPlanFilterCP.Count.ToString();

            List<ProgramPlan> programPlanFilterTUCP = programPlanList.Where(x => x.Date.Year == DateTime.Today.Year && x.ActualOutput == 0).ToList();
            lblTUCP.Text = programPlanFilterTUCP.Count.ToString();


            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            List<ProgramTarget> programTargetsList = programTargetController.GetAllProgramTarget(false, false, false, false);
            int mCount = 0;
            foreach (var i in programTargetsList)
            {
                if (i.TargetMonth == DateTime.Today.Month)
                {
                    mCount++;
                }
            }
            lblThisMonthTarget.Text = mCount.ToString();

        }


        private void bindDialogbox()
        {
            int systemUserId = Convert.ToInt32(Session["UserId"]);

            DepartmentUnitPositionsList = ControllerFactory.CreateDepartmentUnitPositionsController().GetAllUsersBySystemUserId(systemUserId);

            int departmentUnitPositionId = DepartmentUnitPositionsList[0].DepartmetUnitPossitionsId;

            programTargetsList = ControllerFactory.CreateProgramTargetController().GetAllProgramTarget(false, false, true, false);

            programTargetsList = programTargetsList.Where(x => x.IsRecommended == 2 && x._ProgramAssignee[0].DepartmentUnitPossitionsId == departmentUnitPositionId && x._ProgramAssignee[0].Is_View == 0).ToList();
            lblNoOfNewPTarget.Text = programTargetsList.Count().ToString();
            programTargetsList = programTargetsList.OrderByDescending(x => x.RecommendedDate).ToList();
            gvProgramTargetNotification.DataSource = programTargetsList;
            gvProgramTargetNotification.DataBind();
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            bindDialogbox();
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = gvProgramTargetNotification.PageSize;
            int pageindex = gvProgramTargetNotification.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;


            ProgramAssigneeController programAssigneeController = ControllerFactory.CreateProgramAssigneeController();

            int id = programTargetsList[rowIndex]._ProgramAssignee[0].ProgramAssigneeId;

            programAssigneeController.UpdateProgramAssigneeIsView(id);

            Page.Response.Redirect(Page.Request.Url.ToString(), true);


        }

        protected void timer1_Tick(object sender, EventArgs e)
        {
            bindDialogbox();
        }
    }
}