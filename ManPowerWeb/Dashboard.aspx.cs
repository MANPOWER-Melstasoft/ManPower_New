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
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                if (!IsPostBack)
                {
                    BindCardData();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void BindCardData()
        {
            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            List<SystemUser> systemUserList = systemUserController.GetAllSystemUser(true, false, false);
            if (Session["UserTypeId"].ToString() == "1")
            {
                lblNumberOfEmp.Text = systemUserList.Count.ToString();
            }
            if (Session["UserTypeId"].ToString() == "2")
            {
                SystemUser systemUser = systemUserController.GetSystemUser(Convert.ToInt32(Session["UserId"]), true, false, false);
                List<SystemUser> systemUserListFilter = systemUserList.Where(x => x._DepartmentUnitPositions.ParentId == systemUser._DepartmentUnitPositions.DepartmentUnitId).ToList();
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


    }
}