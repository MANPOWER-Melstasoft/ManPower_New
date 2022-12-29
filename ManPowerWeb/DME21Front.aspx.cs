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
    public partial class DME21Front : System.Web.UI.Page
    {
        int[] year = { DateTime.Now.Year - 1, DateTime.Now.Year, DateTime.Now.Year + 1 };
        List<TaskAllocation> TaskAllocationList1 = new List<TaskAllocation>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindYear();
                BindMonth();
                BindDataSource();
            }
        }
        private void BindYear()
        {
            ddlYear.DataSource = year;
            ddlYear.DataBind();
        }

        private void BindMonth()
        {
            List<Month> monthTable = new List<Month>();

            monthTable.Add(new Month() { monthName = "January", monthNumber = 1 });
            monthTable.Add(new Month() { monthName = "February", monthNumber = 2 });
            monthTable.Add(new Month() { monthName = "March", monthNumber = 3 });
            monthTable.Add(new Month() { monthName = "April", monthNumber = 4 });
            monthTable.Add(new Month() { monthName = "May", monthNumber = 5 });
            monthTable.Add(new Month() { monthName = "June", monthNumber = 6 });
            monthTable.Add(new Month() { monthName = "July", monthNumber = 7 });
            monthTable.Add(new Month() { monthName = "August", monthNumber = 8 });
            monthTable.Add(new Month() { monthName = "September", monthNumber = 9 });
            monthTable.Add(new Month() { monthName = "October", monthNumber = 10 });
            monthTable.Add(new Month() { monthName = "November", monthNumber = 11 });
            monthTable.Add(new Month() { monthName = "December", monthNumber = 12 });

            ddlMonth.DataSource = monthTable;
            ddlMonth.DataBind();
        }

        private void BindDataSource()
        {

            int flag1 = 0;

            int depId = Convert.ToInt32(Session["DepUnitPositionId"]);

            TaskAllocationController allocation = ControllerFactory.CreateTaskAllocationController();


            TaskAllocationList1 = allocation.DME21Front(depId);

            gvDME21Front.DataSource = TaskAllocationList1;
            gvDME21Front.DataBind();

            List<TaskAllocation> taskAllocationList = new List<TaskAllocation>();

            taskAllocationList = allocation.GetAllTaskAllocation(false, false, false, false);



            foreach (var i in taskAllocationList)
            {
                if (i.DepartmetUnitPossitionsId == depId && i.TaskYearMonth.Month == DateTime.Now.AddMonths(1).Month && i.TaskYearMonth.Year == DateTime.Now.AddMonths(1).Year && i.StatusId > 0)
                {
                    flag1 = 1;
                }
            }

            if (flag1 == 1)
            {
                btnAddDME21.Enabled = false;
                btnAddDME21.CssClass = "btn btn-outline-secondary disabled";
            }
            else
            {
                btnAddDME21.Enabled = true;
                btnAddDME21.CssClass = "btn btn-outline-secondary";
            }
        }

        protected void btnAddDME21_Click(object sender, EventArgs e)
        {
            string Url = "dme21.aspx";
            Response.Redirect(Url);
        }

        protected void btnAction_Click(object sender, EventArgs e)
        {

            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            string url = "DME21FrontRender.aspx?" + "taskAllocationID=" + TaskAllocationList1[rowIndex].TaskAllocationId;
            Response.Redirect(url);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(ddlYear.SelectedValue);
            int month = Convert.ToInt32(ddlMonth.SelectedValue);

            BindDataSource();

            TaskAllocationList1 = TaskAllocationList1.Where(x => x.TaskYearMonth.Year == year && x.TaskYearMonth.Month == month).ToList();

            gvDME21Front.DataSource = TaskAllocationList1;
            gvDME21Front.DataBind();

        }
    }

}