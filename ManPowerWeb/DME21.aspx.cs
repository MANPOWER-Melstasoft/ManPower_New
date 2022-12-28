using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class DME21 : System.Web.UI.Page
    {
        private string selectedYear = DateTime.Now.AddMonths(1).ToString("yyyy");
        private int month = DateTime.Now.AddMonths(1).Month;
        public DateTime monthYear = DateTime.Now.AddMonths(1);
        private string monthName = DateTime.Now.AddMonths(1).ToString("MMMM");
        //List<TaskAllocationDetail> taskallocationDetailList = new List<TaskAllocationDetail>();
        List<TaskAllocationDetail> taskallocationDetailList1 = new List<TaskAllocationDetail>();

        List<TaskAllocation> taskAllocationList;

        TaskAllocation taskAllocation = new TaskAllocation();
        public string Year { get { return selectedYear; } }
        public string Month { get { return monthName; } }

        public int depId = 4;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataSource();
        }

        public void BindDataSource()
        {
            int positionId = 4;

            TaskAllocationDetailController taskAllocationDetail = ControllerFactory.CreateTaskAllocationDetailController();

            taskallocationDetailList1 = taskAllocationDetail.GetTaskAllocationDetail(positionId, monthYear);

            for (int i = 0; i < new DateTime(Convert.ToInt32(selectedYear), month, 01).AddMonths(1).AddDays(-1).Day; i++)
            {
                int flag = 0;

                foreach (var j in taskallocationDetailList1)
                {
                    if (j.StartTime == new DateTime(Convert.ToInt32(selectedYear), month, 01).AddDays(i).Date)
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    taskallocationDetailList1.Add(new TaskAllocationDetail() { StartTime = new DateTime(Convert.ToInt32(selectedYear), month, 01).AddDays(i).Date });
                }
                else
                {
                    continue;
                }
            }

            DME21GridView.DataSource = taskallocationDetailList1;
            DME21GridView.DataBind();

            foreach (GridViewRow row in DME21GridView.Rows)
            {
                if (row.Cells[1].Text == "&nbsp;")
                {
                    ((LinkButton)row.FindControl("btnAdd")).Enabled = true;
                    ((LinkButton)row.FindControl("btnEdit")).Enabled = false;
                    ((LinkButton)row.FindControl("btnEdit")).CssClass = "btn btn-outline-secondary disabled";
                }
                else
                {
                    ((LinkButton)row.FindControl("btnAdd")).Enabled = false;
                    ((LinkButton)row.FindControl("btnEdit")).Enabled = true;
                    ((LinkButton)row.FindControl("btnAdd")).CssClass = "btn btn-outline-secondary disabled";
                }
            }

            int flag1 = 0;

            foreach (var item in taskallocationDetailList1)
            {
                if (item.TaskTypeId == 0)
                {
                    flag1 = 1;
                }
                else
                {
                    continue;
                }
            }

            if (flag1 == 0)
            {
                btnApproval.Enabled = true;
                btnApproval.CssClass = "btn btn-outline-secondary";
            }
            else
            {
                btnApproval.Enabled = false;
                btnApproval.CssClass = "btn btn-outline-secondary disabled";
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            string url = "AddDME21.aspx?" + "date=" + taskallocationDetailList1[rowIndex].StartTime.ToString("yyyy-MM-dd") + "&taskAllocationDetailId=" + 0;
            Response.Redirect(url);
        }
        protected void DME21GridView_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
            DME21GridView.PageIndex = e.NewPageIndex;
            this.BindDataSource();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            string url = "AddDME21.aspx?" + "date=" + taskallocationDetailList1[rowIndex].StartTime.ToString("yyyy-MM-dd") + "&taskAllocationDetailId=" + taskallocationDetailList1[rowIndex].TaskAllocationDetailId;
            Response.Redirect(url);
        }

        protected void btnApproval_Click(object sender, EventArgs e)
        {
            TaskAllocationController allocation = ControllerFactory.CreateTaskAllocationController();

            taskAllocationList = allocation.GetAllTaskAllocation(false, false, false, false);

            int taskAllocationId = 0;

            foreach (var i in taskAllocationList)
            {
                if (i.DepartmetUnitPossitionsId == depId && i.TaskYearMonth.Month == month && i.TaskYearMonth.Year == DateTime.Now.AddMonths(1).Year)
                {
                    taskAllocationId = i.TaskAllocationId;
                }
            }

            taskAllocation = allocation.GetTaskAllocation(taskAllocationId, false, false);

            taskAllocation.TaskAllocationId = taskAllocationId;
            taskAllocation.StatusId = 1;
            taskAllocation.DME21RecommendedBy1 = 4;

            int value = allocation.UpdateTaskAllocation(taskAllocation);

            string url = "DME21Front.aspx";
            Response.Redirect(url);
        }
    }
}