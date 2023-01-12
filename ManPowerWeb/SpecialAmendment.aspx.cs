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
    public partial class SpecialAmendment : System.Web.UI.Page
    {
        private string selectedYear;

        private string monthName;

        List<TaskAllocationDetail> taskallocationDetailList1 = new List<TaskAllocationDetail>();

        List<TaskAllocation> taskAllocationList;

        TaskAllocation taskAllocation = new TaskAllocation();
        public string Year { get { return selectedYear; } }
        public string Month { get { return monthName; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataSource();
        }

        public void BindDataSource()
        {
            int positionId = Convert.ToInt32(Session["DepUnitPositionId"]);

            TaskAllocationController allocation = ControllerFactory.CreateTaskAllocationController();

            taskAllocationList = allocation.GetAllTaskAllocation(false, false, false, false);

            int taskAllocationId = 0;

            foreach (var i in taskAllocationList)
            {
                if (i.DepartmetUnitPossitionsId == positionId && i.StatusId == 2)
                {
                    taskAllocationId = i.TaskAllocationId;
                }
            }

            TaskAllocationDetailController taskAllocationDetail = ControllerFactory.CreateTaskAllocationDetailController();

            taskallocationDetailList1 = taskAllocationDetail.GetAllTaskAllocationDetailByTaskAllocationId(taskAllocationId);

            DME21GridView.DataSource = taskallocationDetailList1;
            DME21GridView.DataBind();

            selectedYear = taskallocationDetailList1[0].StartTime.Year.ToString();
            monthName = taskallocationDetailList1[0].StartTime.Date.ToString("MMMM");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            string url = "specialAmendmentRender.aspx?" + "date=" + taskallocationDetailList1[rowIndex].StartTime.ToString("yyyy-MM-dd") + "&taskAllocationDetailId=" + taskallocationDetailList1[rowIndex].TaskAllocationDetailId;
            Response.Redirect(url);
        }

        protected void btnApproval_Click(object sender, EventArgs e)
        {
            int positionId = Convert.ToInt32(Session["DepUnitPositionId"]);

            TaskAllocationController allocation = ControllerFactory.CreateTaskAllocationController();

            taskAllocationList = allocation.GetAllTaskAllocation(false, false, false, false);

            int taskAllocationId = 0;

            int depId = Convert.ToInt32(Session["DepUnitPositionId"]);

            foreach (var i in taskAllocationList)
            {
                if (i.DepartmetUnitPossitionsId == positionId && i.StatusId == 2 && i.TaskYearMonth.Year == Convert.ToInt32(selectedYear))
                {
                    taskAllocationId = i.TaskAllocationId;
                }
            }

            taskAllocation = allocation.GetTaskAllocation(taskAllocationId, false, false);

            taskAllocation.TaskAllocationId = taskAllocationId;
            taskAllocation.StatusId = 1;
            taskAllocation.DME21RecommendedBy1 = Convert.ToInt32(Session["DepUnitParentId"]);

            int value = allocation.UpdateTaskAllocation(taskAllocation);

            string url = "dme21.aspx";
            Response.Redirect(url);
        }
    }
}