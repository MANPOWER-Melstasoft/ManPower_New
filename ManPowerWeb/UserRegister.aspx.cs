using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
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
                    if (CheckExistsEmpNum(Convert.ToInt32(txtEmpNumber.Text), systemUserController) && CheckAvailableEmpNum(Convert.ToInt32(txtEmpNumber.Text)))
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

                        DepartmentUnitController departmentUnitTypeController = ControllerFactory.CreateDepartmentUnitController();
                        List<DepartmentUnit> departmentUnitList = departmentUnitTypeController.GetAllDepartmentUnit(false, false);
                        departmentUnitList = departmentUnitList.Where(x => x.DepartmentUnitId == Convert.ToInt32(ddlDepartmentUnit.SelectedValue)).ToList();

                        systemUser.PossitionsId = Convert.ToInt32(ddlPosition.SelectedValue);
                        systemUser.DepartmentUnitId = Convert.ToInt32(ddlDepartmentUnit.SelectedValue);
                        systemUser.ParentId = departmentUnitList[0].ParentId;

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
                lblEmpNumError.Text = "Already Exists!";
                return false;
            }
        }

        private bool CheckAvailableEmpNum(int Number)
        {
            EmploymentDetailsController employmentDetailsController = ControllerFactory.CreateEmploymentDetailsController();
            List<EmploymentDetails> employmentDetailsList = employmentDetailsController.GetAllEmploymentDetails();
            int flag = 0;
            foreach (var item in employmentDetailsList)
            {
                if (item.EmpNumber == Number)
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
        }

    }
}