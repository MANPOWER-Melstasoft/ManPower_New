using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class DME22Rec2Render : System.Web.UI.Page
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

            gvDME22Rec2.DataSource = taskAllocationDetailList;
            gvDME22Rec2.DataBind();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            TaskAllocationController allocation = ControllerFactory.CreateTaskAllocationController();

            TaskAllocation taskAllocation = new TaskAllocation();

            taskAllocation = allocation.GetTaskAllocation(taskAllocationID, false, false);

            taskAllocation.TaskAllocationId = taskAllocationID;
            taskAllocation.StatusId = 8;
            taskAllocation.DME22_ApprovedBy = Convert.ToInt32(Session["DepUnitParentId"]);

            int value = allocation.UpdateTaskAllocation(taskAllocation);

            string url = "DME22Rec2.aspx";
            Response.Redirect(url);
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            TaskAllocationController allocation = ControllerFactory.CreateTaskAllocationController();

            TaskAllocation taskAllocation = new TaskAllocation();

            taskAllocation = allocation.GetTaskAllocation(taskAllocationID, false, false);

            taskAllocation.TaskAllocationId = taskAllocationID;
            taskAllocation.StatusId = 7;

            int value = allocation.UpdateTaskAllocation(taskAllocation);

            string url = "DME22Rec2.aspx";
            Response.Redirect(url);
        }

        protected void gvDME22Approve_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[4].Text == "1")
                {
                    e.Row.Cells[4].Text = "Completed";
                    e.Row.Cells[4].ForeColor = Color.Green;
                }
                else
                {
                    e.Row.Cells[4].Text = "Not completed";
                    e.Row.Cells[4].ForeColor = Color.Red;
                }
            }
        }
    }
}