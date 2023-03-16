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
    }
}