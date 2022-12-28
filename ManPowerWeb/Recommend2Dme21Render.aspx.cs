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
    public partial class Recommend2Dme21Render : System.Web.UI.Page
    {
        List<TaskAllocationDetail> taskAllocationDetailList;
        public int taskAllocationID;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataSource();
        }

        public void BindDataSource()
        {
            taskAllocationID = Convert.ToInt32(Request.QueryString["taskAllocationID"]);

            TaskAllocationDetailController taskAllocationDetail = ControllerFactory.CreateTaskAllocationDetailController();

            taskAllocationDetailList = taskAllocationDetail.GetAllTaskAllocationDetailByTaskAllocationId(taskAllocationID);

            gvDME21Recommend2.DataSource = taskAllocationDetailList;
            gvDME21Recommend2.DataBind();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            TaskAllocationController allocation = ControllerFactory.CreateTaskAllocationController();

            TaskAllocation taskAllocation = new TaskAllocation();

            taskAllocation = allocation.GetTaskAllocation(taskAllocationID, false, false);

            taskAllocation.TaskAllocationId = taskAllocationID;
            taskAllocation.DME21ApprovedBy = 4;
            taskAllocation.StatusId = 2010;

            int value = allocation.UpdateTaskAllocation(taskAllocation);
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            TaskAllocationController allocation = ControllerFactory.CreateTaskAllocationController();

            TaskAllocation taskAllocation = new TaskAllocation();

            taskAllocation = allocation.GetTaskAllocation(taskAllocationID, false, false);

            taskAllocation.TaskAllocationId = taskAllocationID;
            taskAllocation.StatusId = 7;

            int value = allocation.UpdateTaskAllocation(taskAllocation);
        }
    }
}