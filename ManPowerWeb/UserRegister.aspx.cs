using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class UserRegister : System.Web.UI.Page
    {
        UserPrevilage userPrevilage = new UserPrevilage();
        int functionId = 24;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (userPrevilage.checkPrevilage(Convert.ToInt32(Session["UserId"]), functionId))
            {
                if (!IsPostBack)
                {
                    BindDesignationList();
                    BindUserTypeList();
                    BindPositionList();
                    BindDepartmentList();
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (VallidatePassword())
            {
                SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
                List<SystemUser> systemUserList = systemUserController.GetAllSystemUser(false, false, false);
                SystemUser systemUserTst = new SystemUser();

                systemUserTst = systemUserList.Where(x => x.UserName.ToLower() == txtUserName.Text.ToLower()).FirstOrDefault();

                if (systemUserTst == null)
                {
                    if (CheckAvailableEmpNum(Convert.ToInt32(txtEmpNumber.Text)) && CheckExistsEmpNum(Convert.ToInt32(txtEmpNumber.Text), systemUserController))
                    {
                        SystemUser systemUser = new SystemUser();
                        systemUser.Name = txtName.Text;
                        systemUser.UserName = txtUserName.Text.ToLower();
                        systemUser.Email = txtEmail.Text;
                        systemUser.ContactNumber = txtContactNumber.Text;
                        systemUser.EmpNumber = Convert.ToInt32(txtEmpNumber.Text);
                        systemUser.UserPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1");
                        systemUser.CreatedDate = DateTime.Now;
                        systemUser.CreatedUser = Session["UserId"].ToString();
                        systemUser.DesignationId = Convert.ToInt32(ddlDesignation.SelectedValue);
                        systemUser.UserTypeId = Convert.ToInt32(ddlUserType.SelectedValue);

                        //DepartmentUnitController departmentUnitTypeController = ControllerFactory.CreateDepartmentUnitController();
                        //List<DepartmentUnit> departmentUnitList = departmentUnitTypeController.GetAllDepartmentUnit(false, false);
                        //departmentUnitList = departmentUnitList.Where(x => x.DepartmentUnitId == Convert.ToInt32(ddlDepartmentUnit.SelectedValue)).ToList();

                        systemUser.PossitionsId = Convert.ToInt32(ddlPosition.SelectedValue);
                        systemUser.DepartmentUnitId = Convert.ToInt32(ddlDepartmentUnit.SelectedValue);
                        systemUser.ParentId = GetParentId();

                        systemUser.SystemUserId = systemUserController.SaveSystemUser(systemUser);

                        Clear();

                        lblErrorUser.Text = "";
                        lblSuccessMsg.Text = "Record Updated Successfully!";
                    }
                }
                else
                {
                    lblSuccessMsg.Text = "";
                    lblErrorUser.Text = "Username Already Taken!";
                }
            }


        }

        private int GetParentId()
        {
            int parentId = 0;
            int userType = Convert.ToInt32(ddlUserType.SelectedValue);
            int depType = Convert.ToInt32(ddlDepartmentType.SelectedValue);
            int depId = Convert.ToInt32(ddlDepartmentUnit.SelectedValue);

            DepartmentUnitPositionsController departmentUnitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
            List<DepartmentUnitPositions> departmentUnitPositionsList = departmentUnitPositionsController.GetAllDepartmentUnitPositions(false, false, true, false, true);

            if (userType == 1 || (userType == 2 && depType == 1))
            {
                return parentId;
            }

            if (userType == 3 && (depType == 1 || depType == 2 || depType == 3))
            {
                foreach (var x in departmentUnitPositionsList)
                {
                    if (x.DepartmentUnitId == depId && x._SystemUser.UserTypeId == 2)
                    {
                        parentId = x.DepartmetUnitPossitionsId;
                    }
                }
                if (parentId == 0)
                {
                    lblManagerError.Text = "There is no Manager to this Unit!";
                }
                return parentId;
            }

            if (userType == 2 && (depType == 2 || depType == 3))
            {
                DistricDsParentController districDsParentController = ControllerFactory.CreateDistricDsParentController();
                List<DistricDsParent> districDsParentList = districDsParentController.GetAllDistricDsParent(false, false);
                int userId = 0;
                foreach (var x in districDsParentList)
                {
                    if (x.DepartmentId == depId)
                    {
                        userId = x.ParentUserId;
                    }
                }
                if (userId != 0)
                {
                    foreach (var x in departmentUnitPositionsList)
                    {
                        if (x.SystemUserId == userId)
                        {
                            parentId = x.DepartmetUnitPossitionsId;
                        }
                    }
                }
                else
                {
                    lblManagerError.Text = "There is no Manager to this Unit!";
                }
                return parentId;
            }
            return parentId;
        }

        private bool CheckExistsEmpNum(int Number, SystemUserController s)
        {
            SystemUser systemUser = s.CheckEmpNumberExists(Number);

            if (systemUser.SystemUserId == 0)
            {
                lblEmpNumError.Text = string.Empty;
                lblErrorUser.Text = string.Empty;
                lblSuccessMsg.Text = string.Empty;
                return true;
            }
            else
            {
                lblSuccessMsg.Text = string.Empty;
                lblErrorUser.Text = string.Empty;
                lblEmpNumError.Text = "Already Used!";
                return false;
            }
        }

        private bool CheckAvailableEmpNum(int Number)
        {
            EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
            List<Employee> employeeList = employeeController.GetAllEmployees();
            int flag = 0;
            foreach (var item in employeeList)
            {
                if (item.EmployeeId == Number)
                {
                    flag = 1;
                    break;
                }
            }

            if (flag == 1)
            {
                lblEmpNumError.Text = string.Empty;
                lblErrorUser.Text = string.Empty;
                lblSuccessMsg.Text = string.Empty;
                return true;
            }
            else
            {
                lblSuccessMsg.Text = string.Empty;
                lblErrorUser.Text = string.Empty;
                lblEmpNumError.Text = "Emp Number does not Exists!";
                return false;
            }
        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private bool VallidatePassword()
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                lblErrorPassword.Text = "";
                return true;
            }
            else
            {
                lblErrorPassword.Text = "Passwords should be the same";
                return false;
            }

        }

        private void BindDesignationList()
        {
            DesignationController designationController = ControllerFactory.CreateDesignationController();
            List<Designation> designationList = designationController.GetAllDesignation(false, false);


            ddlDesignation.DataSource = designationList;
            ddlDesignation.DataValueField = "DesignationId";
            ddlDesignation.DataTextField = "DesigntionName";
            ddlDesignation.DataBind();
            ddlDesignation.Items.Insert(0, new ListItem("-- select designation --", ""));

        }

        private void BindUserTypeList()
        {
            UserTypeController userTypeController = ControllerFactory.CreateUserTypeController();
            List<UserType> userTypeList = userTypeController.GetAllUserType(false);


            ddlUserType.DataSource = userTypeList;
            ddlUserType.DataValueField = "UserTypeId";
            ddlUserType.DataTextField = "UserTypeName";
            ddlUserType.DataBind();
            ddlUserType.Items.Insert(0, new ListItem("-- select user type --", ""));

        }

        private void BindPositionList()
        {
            PossitionsController possitionsController = ControllerFactory.CreatePossitionsController();
            List<Possitions> possitionList = possitionsController.GetAllPossitions(false, false);


            ddlPosition.DataSource = possitionList;
            ddlPosition.DataValueField = "PossitionId";
            ddlPosition.DataTextField = "PositionName";
            ddlPosition.DataBind();
            ddlPosition.Items.Insert(0, new ListItem("-- select position --", ""));

        }

        private void BindDepartmentList()
        {
            DepartmentUnitTypeController departmentUnitTypeController = ControllerFactory.CreateDepartmentUnitTypeController();
            List<DepartmentUnitType> departmentUnitTypeList = departmentUnitTypeController.GetAllDepartmentUnitType(false);


            ddlDepartmentType.DataSource = departmentUnitTypeList;
            ddlDepartmentType.DataValueField = "DepartmentUnitTypeId";
            ddlDepartmentType.DataTextField = "Name";
            ddlDepartmentType.DataBind();
            ddlDepartmentType.Items.Insert(0, new ListItem("-- select department --", ""));

        }

        protected void ddlDepartmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDepartmentUnitList();
        }

        private void BindDepartmentUnitList()
        {

            if (ddlDepartmentType.SelectedValue != "")
            {
                DepartmentUnitController departmentUnitTypeController = ControllerFactory.CreateDepartmentUnitController();
                List<DepartmentUnit> departmentUnitList = departmentUnitTypeController.GetAllDepartmentUnit(false, false);

                departmentUnitList = departmentUnitList.Where(x => x.DepartmentUnitTypeId == Convert.ToInt32(ddlDepartmentType.SelectedValue)).ToList();

                ddlDepartmentUnit.DataSource = departmentUnitList;
                ddlDepartmentUnit.DataValueField = "DepartmentUnitId";
                ddlDepartmentUnit.DataTextField = "Name";
                ddlDepartmentUnit.DataBind();
            }
            else
            {
                ddlDepartmentUnit.Items.Clear();
            }


        }

        private void Clear()
        {
            txtName.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtContactNumber.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtEmpNumber.Text = string.Empty;
            ddlDesignation.SelectedIndex = 0;
            ddlPosition.SelectedIndex = 0;
            ddlUserType.SelectedIndex = 0;
            ddlDepartmentType.SelectedIndex = 0;
            ddlDepartmentUnit.Items.Clear();
            lblSuccessMsg.Text = string.Empty;
        }

    }
}