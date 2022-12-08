using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class DME21 : System.Web.UI.Page
    {
        private string selectedYear = DateTime.Now.AddMonths(1).ToString("yyyy");
        private int month = DateTime.Now.AddMonths(1).Month;
        private string monthName = DateTime.Now.AddMonths(1).ToString("MMMM");
        List<AllocatedDates> DateList = new List<AllocatedDates>();
        public string Year { get { return selectedYear; } }
        public string Month { get { return monthName; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataSource();
        }

        public void BindDataSource()
        {
            for (int i = 0; i < new DateTime(Convert.ToInt32(selectedYear), month, 01).AddMonths(1).AddDays(-1).Day; i++)
            {
                DateList.Add(new AllocatedDates() { date = new DateTime(Convert.ToInt32(selectedYear), month, 01).AddDays(i).Date });
            }

            DME21GridView.DataSource = DateList;
            DME21GridView.DataBind();
        }
    }

    public class AllocatedDates
    {
        public DateTime date { get; set; }
    }
}