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
    public partial class PersonalFilesSearch : System.Web.UI.Page
    {
        List<Employee> employees = new List<Employee>();

        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
            employees = employeeController.GetAllEmployees();

            ViewState["employees"] = employees;
            GridView1.DataSource = employees;
            GridView1.DataBind();
        }
    }
}