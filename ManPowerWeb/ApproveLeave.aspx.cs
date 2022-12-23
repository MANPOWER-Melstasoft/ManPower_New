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
    public partial class ApproveLeave : System.Web.UI.Page
    {
        List<SystemUser> systemUsers = new List<SystemUser>();
        List<DepartmentUnit> departmentUnitsList = new List<DepartmentUnit>();
        List<Employee> employeesList = new List<Employee>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDataSource();
            }

        }
        private void bindDataSource()
        {
            DepartmentUnitController departmentUnitController = ControllerFactory.CreateDepartmentUnitController();
            departmentUnitsList = departmentUnitController.GetAllDepartmentUnit(false, false);

            ddlHo.DataSource = departmentUnitsList.Where(x => x.DepartmentUnitTypeId == 1);
            ddlHo.DataValueField = "DepartmentUnitId";
            ddlHo.DataTextField = "Name";


            ddlDistrict.DataSource = departmentUnitsList.Where(x => x.DepartmentUnitTypeId == 2);
            ddlDistrict.DataValueField = "DepartmentUnitId";
            ddlDistrict.DataTextField = "Name";


            ddlHo.DataBind();
            ddlDistrict.DataBind();

            EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
            employeesList = employeeController.GetAllEmployees(true);

            gvApproveLeave.DataSource = employeesList;
            gvApproveLeave.DataBind();


        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDSDivision();
        }

        private void bindDSDivision()
        {
            DepartmentUnitController departmentUnitController = ControllerFactory.CreateDepartmentUnitController();
            departmentUnitsList = departmentUnitController.GetAllDepartmentUnit(false, false);

            ddlDS.DataSource = departmentUnitsList.Where(x => x.DepartmentUnitTypeId == 3 && x.ParentId == int.Parse(ddlDistrict.SelectedValue));
            ddlDS.DataValueField = "DepartmentUnitId";
            ddlDS.DataTextField = "Name";
            ddlDS.DataBind();




        }

        protected void gvApproveLeave_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}