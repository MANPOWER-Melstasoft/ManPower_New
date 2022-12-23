using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class DME21Front : System.Web.UI.Page
    {
        int[] year = { DateTime.Now.Year - 1, DateTime.Now.Year, DateTime.Now.Year + 1 };
        protected void Page_Load(object sender, EventArgs e)
        {
            BindYear();
            BindMonth();
            BindDataSource();
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
            List<GridDME21> monthList = new List<GridDME21>
            {
                new GridDME21 {Year= 2022, Month= 10 , Status="Completed"},
                new GridDME21 {Year= 2022, Month= 11 , Status="Not Completed"},
                new GridDME21 {Year= 2022, Month= 12 , Status="InProgress"}
            };

            gvDME21Front.DataSource = monthList;
            gvDME21Front.DataBind();
        }

        protected void btnAddDME21_Click(object sender, EventArgs e)
        {
            string Url = "dme21.aspx";
            Response.Redirect(Url);
        }
    }

    public class GridDME21
    {
        public int Year { get; set; }

        public int Month { get; set; }

        public String Status { get; set; }
    }
}