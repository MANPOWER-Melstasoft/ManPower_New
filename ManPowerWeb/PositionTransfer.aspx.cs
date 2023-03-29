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
    public partial class PositionTransfer : System.Web.UI.Page
    {
        List<TransfersRetirementResignationMain> transfersRetirementResignationMainList = new List<TransfersRetirementResignationMain>();
        List<Employee> employeesList = new List<Employee>();
        List<Employee> employeesListDropDown = new List<Employee>();
        static List<SystemUser> systemUsers;
        static int systemUserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDataSource();
            }
        }

        private void bindDataSource()
        {
            TransfersRetirementResignationMainController transfersRetirementResignationMainController = ControllerFactory.CreateTransfersRetirementResignationMainController();
            transfersRetirementResignationMainList = transfersRetirementResignationMainController.GetAllTransfersRetirementResignation(false);

            EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
            employeesList = employeeController.GetAllEmployees();

            foreach (Employee employee in employeesList)
            {
                foreach (var item in transfersRetirementResignationMainList.Where(x => x.StatusId == 2 && x.RequestTypeId == 1))
                {
                    if (item.EmployeeId == employee.EmployeeId)
                    {
                        employeesListDropDown.Add(employee);
                    }
                }
            }

            ddlTransferTo.DataSource = employeesListDropDown;
            ddlTransferTo.DataTextField = "NameWithInitials";
            ddlTransferTo.DataValueField = "EmployeeId";
            ddlTransferTo.DataBind();

            ddlTransferTo.Items.Insert(0, new ListItem("--Select Transfered Person--", ""));
        }

        protected void ddlTransferTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
            Employee employeeObject = new Employee();
            int employeeId = Convert.ToInt32(ddlTransferTo.SelectedValue);
            employeeObject = employeeController.GetEmployeeById(employeeId);

            //get retirment Employee Systemuser Id

            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            systemUsers = systemUserController.GetAllSystemUser(true, false, false);

            var retireEmployeeSystemUserDetails = systemUsers.Where(x => x.EmpNumber == employeeId).Single();
            systemUserId = retireEmployeeSystemUserDetails.SystemUserId;


            if (employeeObject.UnitType == 3)
            {
                systemUsers = systemUsers.Where(x => x._DepartmentUnitPositions.DepartmentUnitId == employeeObject.DSDivisionId && x.SystemUserId != systemUserId).ToList();
            }
            else
            {
                systemUsers = systemUsers.Where(x => x._DepartmentUnitPositions.DepartmentUnitId == employeeObject.DistrictId && x.SystemUserId != systemUserId).ToList();
            }


            ddlTransferFrom.DataSource = systemUsers;
            ddlTransferFrom.DataValueField = "SystemUserId";
            ddlTransferFrom.DataTextField = "Name";
            ddlTransferFrom.DataBind();

            ddlTransferFrom.Items.Insert(0, new ListItem("--Select Employee--", ""));

        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            DepartmentUnitPositionsController departmentUnitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();

            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            systemUsers = systemUserController.GetAllSystemUser(true, false, false);

            SystemUser systemUser = systemUsers.Where(x => x.SystemUserId == Convert.ToInt32(ddlTransferFrom.SelectedValue)).Single();

            int depUnitPosId = systemUser._DepartmentUnitPositions.DepartmetUnitPossitionsId;

            int response = departmentUnitPositionsController.UpdateSytemUserIdByDepartment_Unit_PositionId(systemUserId, depUnitPosId);

            if (response != 0)
            {

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", string.Format("swal('Success!', 'Successfully Transferd!', 'success');window.setTimeout(function(){{window.location='PositionTransfer.aspx'}} ,2500);"), true);

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", string.Format("swal('Success!', 'Successfully Transferd!', 'success');window.setTimeout(function(){{window.location='PositionTransfer.aspx'}} ,2500);"), true);
            }
        }
    }
}