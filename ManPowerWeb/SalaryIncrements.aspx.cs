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
    public partial class SalaryIncrements : System.Web.UI.Page
    {
        SalaryIncrementController salaryIncrementController = ControllerFactory.CreateSalaryIncrementController();
        public List<SalaryIncrement> salaryIncrementList = new List<SalaryIncrement>();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            salaryIncrementList = salaryIncrementController.GetAllSalaryIncrement();
            gvSalaryIncrement.DataSource = salaryIncrementList;
            gvSalaryIncrement.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string url = "AddSalaryIncrement.aspx";
            Response.Redirect(url);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtkeyword.Text;

            if (keyword != "")
            {
                salaryIncrementList = salaryIncrementList.Where(x => x.Employee.LastName.ToLower().Contains(keyword.ToLower())).ToList();
            }
            gvSalaryIncrement.DataSource = salaryIncrementList;
            gvSalaryIncrement.DataBind();

            txtkeyword.Text = string.Empty;
        }

        protected void btnGetAll_Click(object sender, EventArgs e)
        {
            salaryIncrementList = salaryIncrementController.GetAllSalaryIncrement();
            gvSalaryIncrement.DataSource = salaryIncrementList;
            gvSalaryIncrement.DataBind();
        }
    }
}