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
        static List<ProgramTarget> programTargetsListForannulTargetSendToRecommendation = new List<ProgramTarget>();
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
                    if ((Convert.ToInt32(Session["UserTypeId"]) == 6 || Convert.ToInt32(Session["UserTypeId"]) == 7
                        || Convert.ToInt32(Session["UserTypeId"]) == 8 || Convert.ToInt32(Session["UserTypeId"]) == 9)
                        && IsNotSubmitDME())
                    {
                        RaiseNotification();
                    }
                    if (Convert.ToInt32(Session["UserTypeId"]) == 6 || Convert.ToInt32(Session["UserTypeId"]) == 7
                        || Convert.ToInt32(Session["UserTypeId"]) == 8 || Convert.ToInt32(Session["UserTypeId"]) == 9)
                    {
                        BindAnnualTarget();
                    }

                    BindCardData();
                    bindDialogbox();
                    annulTargetSendToRecommendationBind();
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
            BindAdminCardData();
            BindPlnUserCardData();
            BindPlnHeadCardData();
            BindDistrictHeadCardData();

            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            List<SystemUser> systemUserList = systemUserController.GetAllSystemUser(true, false, false);
            if (Session["UserTypeId"].ToString() == "1" || Session["UserTypeId"].ToString() == "2")
            {
                systemUserList.RemoveAll(x => x.SystemUserId == Convert.ToInt32(Session["UserId"]));
                lblNumberOfEmp.Text = systemUserList.Count.ToString();
            }
            else
            {
                SystemUser systemUser = systemUserController.GetSystemUser(Convert.ToInt32(Session["UserId"]), true, false, false);
                List<SystemUser> systemUserListFilter = systemUserList.Where(x => x._DepartmentUnitPositions.ParentId == systemUser._DepartmentUnitPositions.DepartmetUnitPossitionsId).ToList();
                lblNumberOfEmp.Text = systemUserListFilter.Count.ToString();
            }

            //---------------------------- Vote Allocation ----------------------------------------------------------
            //VoteAllocationController voteAllocationController = ControllerFactory.CreateVoteAllocationController();
            //List<VoteAllocation> voteAllocationList = voteAllocationController.GetAllVoteAllocation(false);
            //List<VoteAllocation> voteAllocationListFilter = new List<VoteAllocation>();
            //float vCount = 0;
            //foreach (var i in voteAllocationList)
            //{
            //    if (i.Year.Year == DateTime.Today.Year)
            //    {
            //        vCount += i.Amount;
            //        voteAllocationListFilter.Add(i);
            //    }
            //}
            //lblVoteAmount.Text = vCount.ToString("N");
            //gvVoteAllocation.DataSource = voteAllocationListFilter;
            //gvVoteAllocation.DataBind();


            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            List<ProgramPlan> programPlanList = programPlanController.GetAllProgramPlan();
            //List<ProgramPlan> programPlanFilter = programPlanList.Where(x => x.Date.Year == DateTime.Today.Year).ToList();

            //List<ProgramPlan> programPlanFilterUCTM = programPlanList.Where(x => x.Date.Year == DateTime.Today.Year && x.Date.Month == DateTime.Today.Month && x.ActualOutput == 0).ToList();
            //lblUCTM.Text = programPlanFilterUCTM.Count.ToString();

            //List<ProgramPlan> programPlanFilterCP = programPlanList.Where(x => x.ActualOutput != 0).ToList();
            //lblCP.Text = programPlanFilterCP.Count.ToString();

            //List<ProgramPlan> programPlanFilterTUCP = programPlanList.Where(x => x.Date.Year == DateTime.Today.Year && x.ActualOutput == 0).ToList();
            //lblTUCP.Text = programPlanFilterTUCP.Count.ToString();

            //------------------------------------- This month Target --------------------------------------------------------------
            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            List<ProgramTarget> programTargetsList = programTargetController.GetAllProgramTarget(false, false, true, true);
            List<ProgramTarget> programTargetsListFilter = new List<ProgramTarget>();
            List<ProgramTarget> programTargetsListFilterTotal = new List<ProgramTarget>();

            int flagProgrmTarget = 0;
            foreach (var i in programTargetsList)
            {
                flagProgrmTarget = 0;
                if (i.TargetMonth == DateTime.Today.Month || (i.StartDate <= DateTime.Now && i.EndDate >= DateTime.Now))
                {
                    if (Session["UserTypeId"].ToString() != "1")
                    {
                        foreach (var item in i._ProgramAssignee)
                        {
                            if (item.DepartmentUnitPossitionsId == Convert.ToInt32(Session["DepUnitPositionId"]))
                            {
                                flagProgrmTarget = 1;
                            }
                        }
                    }
                    if (Session["UserTypeId"].ToString() == "1")
                    {
                        flagProgrmTarget = 1;
                    }

                }
                if (flagProgrmTarget == 1)
                {
                    programTargetsListFilter.Add(i);
                }
            }

            //lblThisMonthTarget.Text = programTargetsListFilter.Count.ToString();
            //gvThisMonthTarget.DataSource = programTargetsListFilter;
            //gvThisMonthTarget.DataBind();

            foreach (var i in programTargetsList)
            {
                flagProgrmTarget = 0;
                if (Session["UserTypeId"].ToString() != "1")
                {
                    foreach (var item in i._ProgramAssignee)
                    {
                        if (item.DepartmentUnitPossitionsId == Convert.ToInt32(Session["DepUnitPositionId"]))
                        {
                            flagProgrmTarget = 1;
                        }
                    }
                }
                if (Session["UserTypeId"].ToString() == "1")
                {
                    flagProgrmTarget = 1;
                }
                if (flagProgrmTarget == 1)
                {
                    programTargetsListFilterTotal.Add(i);
                }
            }
            //lblTotalProgramms.Text = programTargetsListFilterTotal.Count.ToString();
            //gvTotalProgrms.DataSource = programTargetsListFilterTotal;
            //gvTotalProgrms.DataBind();

            //------------------ THIS MONTH UPCOMING PROGRAMS ---------------------------------------

            lblUCTM.Text = programTargetsListFilter.Count.ToString();
            gvthisMonthProgram.DataSource = programTargetsListFilter;
            gvthisMonthProgram.DataBind();


            //-------------------------- NO OF COMPLETED PROGRAMS ---------------------------------
            List<ProgramPlan> programPlanListComplete = new List<ProgramPlan>();
            List<ProgramTarget> programTargetsListComplete = new List<ProgramTarget>();
            foreach (var i in programTargetsList)
            {
                flagProgrmTarget = 0;
                foreach (var item in i._ProgramAssignee)
                {
                    if (item.DepartmentUnitPossitionsId == Convert.ToInt32(Session["DepUnitPositionId"]))
                    {
                        flagProgrmTarget = 1;
                    }
                }
                if (flagProgrmTarget == 1)
                {
                    programTargetsListComplete.Add(i);
                }
            }
            foreach (var item1 in programTargetsListComplete)
            {
                foreach (var item2 in item1._ProgramPlan)
                {
                    if (item2.ProjectStatusId == 4)
                    {
                        programPlanListComplete.Add(item2);
                    }
                }
            }

            lblCP.Text = programPlanListComplete.Count.ToString();
            gvCompletedProgrm.DataSource = programPlanListComplete;
            gvCompletedProgrm.DataBind();

            //--------------------- TOTAL UPCOMING PROGRAMS ---------------------------------------
            List<ProgramTarget> programTargetsListFilterTotalUpComming = new List<ProgramTarget>();
            foreach (var i in programTargetsList)
            {
                flagProgrmTarget = 0;
                if (i.TargetMonth >= DateTime.Today.Month || i.StartDate >= DateTime.Now)
                {
                    foreach (var item in i._ProgramAssignee)
                    {
                        if (item.DepartmentUnitPossitionsId == Convert.ToInt32(Session["DepUnitPositionId"]))
                        {
                            flagProgrmTarget = 1;
                        }
                    }
                }

                if (flagProgrmTarget == 1)
                {
                    programTargetsListFilterTotalUpComming.Add(i);
                }
            }

            lblTUCP.Text = programTargetsListFilterTotalUpComming.Count.ToString();
            gvTotalUpComingProgrm.DataSource = programTargetsListFilterTotalUpComming;
            gvTotalUpComingProgrm.DataBind();



            //--------------------- COMPLETED PROGRAMMS ---------------------------------------
            List<ProgramPlan> ProgramPlanlist = programPlanController.GetAllProgramPlan(false, false, true, false, false, false);

            ProgramAssigneeController programAssigneeController = ControllerFactory.CreateProgramAssigneeController();
            List<ProgramAssignee> asignee = programAssigneeController.GetAllProgramAssignee(false, true, false);

            List<ProgramPlan> ProgramPlanlistFinal = new List<ProgramPlan>();
            foreach (var asigne in asignee.Where(x => x.DepartmentUnitPossitionsId == Convert.ToInt32(Session["DepUnitPositionId"])))
            {
                foreach (var plans in ProgramPlanlist.Where(x => x.ProjectStatusId == 4 && x.ProgramTargetId == asigne.ProgramTargetId))
                {
                    ProgramPlanlistFinal.Add(plans);
                }
            }
            lblCompletedProgrm.Text = ProgramPlanlistFinal.Count().ToString();

        }

        protected void BindAdminCardData()
        {
            //--------------------- VEHICLE MAINTAINCE ---------------------------------------
            VehicleMaintenanceController vehicleMaintenanceController = ControllerFactory.CreateVehicleMaintenanceController();
            List<VehicleMeintenance> vehicleMeintenances = vehicleMaintenanceController.GetAllVehicleMeintenance();
            vehicleMeintenances = vehicleMeintenances.Where(x => x.IsApproved == 2).ToList();
            lblAppVehicle.Text = vehicleMeintenances.Count.ToString();
            gvVehicleMain.DataSource = vehicleMeintenances;
            gvVehicleMain.DataBind();

            //--------------------- APPROVE LEAVES ---------------------------------------
            StaffLeaveController staffLeaveController = ControllerFactory.CreateStaffLeaveControllerImpl();
            List<StaffLeave> staffLeaves = staffLeaveController.getStaffLeaves(true);
            staffLeaves = staffLeaves.Where(x => x.ApprovedBy != 0 && x.ApprovedBy != -1).ToList();
            lblAppLeave.Text = staffLeaves.Count.ToString();
            gvAppLeave.DataSource = staffLeaves;
            gvAppLeave.DataBind();

            //--------------------- TRAINING REQUEST ---------------------------------------
            TrainingRequestsController trainingRequestControllerImpl = ControllerFactory.CreateTrainingRequestsController();
            List<TrainingRequests> trainingRequests = trainingRequestControllerImpl.GetAllTrainingRequests();
            trainingRequests = trainingRequests.Where(x => x.ProjectStatusId == 1008).ToList();
            lblAppTrain.Text = trainingRequests.Count.ToString();
            gvTraininReq.DataSource = trainingRequests;
            gvTraininReq.DataBind();

            //--------------------- APPROVED RESIGNATIONS ---------------------------------------
            TransfersRetirementResignationMainController transfersRetirementResignationMainController = ControllerFactory.CreateTransfersRetirementResignationMainController();
            List<TransfersRetirementResignationMain> transfersRetirementResignationMains = transfersRetirementResignationMainController.GetAllTransfersRetirementResignation(false);
            transfersRetirementResignationMains = transfersRetirementResignationMains.Where(x => x.RequestTypeId == 2).ToList();
            lblAppResign.Text = transfersRetirementResignationMains.Count.ToString();
            gvAppResign.DataSource = transfersRetirementResignationMains;
            gvAppResign.DataBind();

        }

        protected void BindPlnUserCardData()
        {
            //--------------------- DME21 ---------------------------------------
            int positionID = Convert.ToInt32(Session["DepUnitPositionId"]);
            TaskAllocationController taskAllocationController = ControllerFactory.CreateTaskAllocationController();
            List<TaskAllocation> taskAllocations = taskAllocationController.GetRecommend1TaskAllocation(positionID);
            lblrec1DME21.Text = taskAllocations.Count.ToString();

            //--------------------- DME22 ---------------------------------------
            List<TaskAllocation> taskAllocationList22Final = new List<TaskAllocation>();
            List<TaskAllocation> taskAllocationList1 = taskAllocationController.GetAllTaskAllocation(false, true, false, false);

            foreach (var item in taskAllocationList1)
            {
                if (item.DME22Rec1By == positionID && item.StatusId == 2011)
                {
                    taskAllocationList22Final.Add(item);
                }
            }
            lblrec1DME22.Text = taskAllocationList22Final.Count.ToString();


            //--------------------- TRAINING REQUEST ---------------------------------------
            TrainingRequestsController trainingRequestControllerImpl = ControllerFactory.CreateTrainingRequestsController();
            List<TrainingRequests> trainingRequests = trainingRequestControllerImpl.GetAllTrainingRequests();
            trainingRequests = trainingRequests.Where(x => x.ProjectStatusId == 1008).ToList();
            lblAppTrain.Text = trainingRequests.Count.ToString();
            gvTraininReq.DataSource = trainingRequests;
            gvTraininReq.DataBind();

        }

        protected void BindPlnHeadCardData()
        {
            //--------------------- DME21 ---------------------------------------
            int positionID = Convert.ToInt32(Session["DepUnitPositionId"]);
            TaskAllocationController taskAllocationController = ControllerFactory.CreateTaskAllocationController();
            List<TaskAllocation> taskAllocations = taskAllocationController.GetTaskAllocationDme21Approve(positionID);
            lblApproveDme21.Text = taskAllocations.Count.ToString();

            //--------------------- DME22 ---------------------------------------
            List<TaskAllocation> taskAllocationList22Final = taskAllocationController.GetTaskAllocationDme22Approve(positionID);
            lblApproveDme22.Text = taskAllocationList22Final.Count.ToString();
        }

        protected void BindDistrictHeadCardData()
        {
            //--------------------- DME21 ---------------------------------------
            int positionID = Convert.ToInt32(Session["DepUnitPositionId"]);
            TaskAllocationController taskAllocationController = ControllerFactory.CreateTaskAllocationController();
            List<TaskAllocation> taskAllocations = taskAllocationController.GetRecommend2TaskAllocation(positionID);
            lblRec2Dme21.Text = taskAllocations.Count.ToString();

            //--------------------- DME22 ---------------------------------------
            List<TaskAllocation> taskAllocationList22 = taskAllocationController.GetAllTaskAllocation(false, true, false, false);
            List<TaskAllocation> taskAllocationList22Final = new List<TaskAllocation>();
            foreach (var item in taskAllocationList22)
            {
                if (item.DME22Rec1By == positionID && item.StatusId == 2012)
                {
                    taskAllocationList22Final.Add(item);
                }
            }
            lblRec2Dme22.Text = taskAllocationList22Final.Count.ToString();
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
            annulTargetSendToRecommendationBind();
        }

        private void BindAnnualTarget()
        {
            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            List<ProgramTarget> programTargetsList = programTargetController.GetAllProgramTarget(false, false, true, true);
            List<ProgramTarget> programTargetsListFilter = new List<ProgramTarget>();

            int flagProgrmTarget = 0;
            foreach (var i in programTargetsList)
            {
                flagProgrmTarget = 0;
                if (i.TargetYear == DateTime.Today.Year)
                {
                    foreach (var item in i._ProgramAssignee)
                    {
                        if (item.DepartmentUnitPossitionsId == Convert.ToInt32(Session["DepUnitPositionId"]))
                        {
                            flagProgrmTarget = 1;
                        }
                    }

                }
                if (flagProgrmTarget == 1)
                {
                    programTargetsListFilter.Add(i);
                }
            }

            gvAnnualTarget.DataSource = programTargetsListFilter;
            gvAnnualTarget.DataBind();
        }

        protected void gvAnnualTarget_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAnnualTarget.PageIndex = e.NewPageIndex;
            BindAnnualTarget();
        }

        //------------------------Send To Recommendation------------------------------------
        private void annulTargetSendToRecommendationBind()
        {
            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            programTargetsListForannulTargetSendToRecommendation = programTargetController.GetAllProgramTarget(false, false, false, false);
            programTargetsListForannulTargetSendToRecommendation = programTargetsListForannulTargetSendToRecommendation.Where(x => x.IsView == 0 && x.IsRecommended == 2 && x.CreatedBy == Convert.ToInt32(Session["UserId"])).ToList();
            if (programTargetsListForannulTargetSendToRecommendation.Count > 0)
            {
                lblAnnualTargetRecommendationApproval.Text = programTargetsListForannulTargetSendToRecommendation.Count.ToString();

            }
            else
            {
                lblAnnualTargetRecommendationApproval.Text = "N/A";

            }
            gvAnnualTargetSendToRecommendation.DataSource = programTargetsListForannulTargetSendToRecommendation;
            gvAnnualTargetSendToRecommendation.DataBind();

        }

        protected void btn_View_Annual_Target_Recommendation_Click(object sender, EventArgs e)
        {
            annulTargetSendToRecommendationBind();
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = gvProgramTargetNotification.PageSize;
            int pageindex = gvProgramTargetNotification.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;

            int programTargetId = programTargetsListForannulTargetSendToRecommendation[rowIndex].ProgramTargetId;


            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();

            programTargetController.UpdateIsView(programTargetId);

            Page.Response.Redirect(Page.Request.Url.ToString(), true);


        }
    }
}