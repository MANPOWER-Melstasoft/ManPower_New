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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDesignationList();
                BindUserTypeList();
                BindPositionList();
                BindDepartmentList();
            }

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (VallidatePassword())
            {
                SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
                SystemUser systemUser = new SystemUser();

                DepartmentUnitController departmentUnitTypeController = ControllerFactory.CreateDepartmentUnitController();
                List<DepartmentUnit> departmentUnitList = departmentUnitTypeController.GetAllDepartmentUnit(false, false);
                departmentUnitList = departmentUnitList.Where(x => x.DepartmentUnitId == Convert.ToInt32(ddlDepartmentUnit.SelectedValue)).ToList();

                systemUser.Name = txtName.Text;
                systemUser.UserName = txtUserName.Text;
                systemUser.Email = txtEmail.Text;
                systemUser.ContactNumber = txtContactNumber.Text;
                systemUser.EmpNumber = Convert.ToInt32(txtEmpNumber.Text);
                systemUser.UserPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1");
                systemUser.CreatedDate = DateTime.Now;
                systemUser.CreatedUser = Session["UserId"].ToString();
                systemUser.DesignationId = Convert.ToInt32(ddlDesignation.SelectedValue);
                systemUser.UserTypeId = Convert.ToInt32(ddlUserType.SelectedValue);

                systemUser.PossitionsId = Convert.ToInt32(ddlPosition.SelectedValue);
                systemUser.DepartmentUnitId = Convert.ToInt32(ddlDepartmentUnit.SelectedValue);
                systemUser.ParentId = departmentUnitList[0].ParentId;

                systemUser.SystemUserId = systemUserController.SaveSystemUser(systemUser);

                Clear();

                lblSuccessMsg.Text = "Record Updated Successfully!";
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
            List<Possitions> possitionList = possitionsController.GetAllPossitions(false);


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
                //ddlDepartmentUnit.Items.Insert(0, new ListItem("-- select department unit --", ""));
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
            //lblCompany.Text = "N/A";
            //lblCompanyUnit.Text = "N/A";
            //lblDescription.Text = "N/A";
            //lblNature.Text = "N/A";
            //lblPlaintiff.Text = "N/A";
            //lblDefendant.Text = "N/A";

        }

    }
}