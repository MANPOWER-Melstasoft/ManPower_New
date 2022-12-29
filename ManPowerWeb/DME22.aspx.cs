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
    public partial class DME22 : System.Web.UI.Page
    {
        int[] year = { DateTime.Now.Year - 1, DateTime.Now.Year, DateTime.Now.Year + 1 };
        List<TaskAllocation> taskAllocationList = new List<TaskAllocation>();
        int depId;

        TaskAllocationController allocation = ControllerFactory.CreateTaskAllocationController();
        protected void Page_Load(object sender, EventArgs e)
        {
            depId = Convert.ToInt32(Session["DepUnitPositionId"]);
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
            taskAllocationList = allocation.DME22(depId);
            DME22GridView.DataSource = taskAllocationList;
            DME22GridView.DataBind();

            foreach (GridViewRow row in DME22GridView.Rows)
            {
                if (row.Cells[2].Text == "Inprogress")
                {
                    ((LinkButton)row.FindControl("btnAction")).Enabled = true;
                }
                else
                {
                    ((LinkButton)row.FindControl("btnAction")).Enabled = false;
                    ((LinkButton)row.FindControl("btnAction")).CssClass = "btn btn-outline-secondary disabled";
                }
            }
        }

        protected void btnAction_Click1(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            string url = "DME22GetAction.aspx?" + "taskAllocationId=" + taskAllocationList[rowIndex].TaskAllocationId.ToString();
            Response.Redirect(url);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(ddlYear.SelectedValue);
            int month = Convert.ToInt32(ddlMonth.SelectedValue);

            BindDataSource();

            taskAllocationList = taskAllocationList.Where(x => x.TaskYearMonth.Year == year && x.TaskYearMonth.Month == month).ToList();

            DME22GridView.DataSource = taskAllocationList;
            DME22GridView.DataBind();
        }
    }
}