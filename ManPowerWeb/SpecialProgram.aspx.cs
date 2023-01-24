using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class SpecialProgram : System.Web.UI.Page
    {
        List<TaskAllocation> taskAllocationList;
        int taskAllocationId = 0;
        TaskAllocationDetail taskAllocationDetail = new TaskAllocationDetail();
        protected void Page_Load(object sender, EventArgs e)
        {
            int positionId = Convert.ToInt32(Session["DepUnitPositionId"]);

            TaskAllocationController allocation = ControllerFactory.CreateTaskAllocationController();

            taskAllocationList = allocation.GetAllTaskAllocation(false, false, false, false);

            foreach (var i in taskAllocationList)
            {
                if (i.DepartmetUnitPossitionsId == positionId && i.StatusId == 2)
                {
                    taskAllocationId = i.TaskAllocationId;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TaskAllocationDetailController allocationDetailController = ControllerFactory.CreateTaskAllocationDetailController();

            taskAllocationDetail.TaskTypeId = 4;
            taskAllocationDetail.TaskAllocationId = taskAllocationId;
            taskAllocationDetail.TaskDescription = txtDescription.Text;
            taskAllocationDetail.WorkLocation = txtLocation.Text;
            taskAllocationDetail.Isconmpleated = 0;
            taskAllocationDetail.NotCompleatedReason = "";
            taskAllocationDetail.StartTime = Convert.ToDateTime(txtDate.Text);
            taskAllocationDetail.EndTime = DateTime.Today;
            taskAllocationDetail.TaskRemarks = "";
            taskAllocationDetail.TaskAmendments = "";

            int taskAlocationDetailId = allocationDetailController.SaveTaskAllocationDetail(taskAllocationDetail);

            string url = "dme21front.aspx";
            Response.Redirect(url);
        }
    }
}