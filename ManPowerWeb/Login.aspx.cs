using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            DepartmentUnitPositionsController DepUnitPositionController = ControllerFactory.CreateDepartmentUnitPositionsController();

            DepartmentUnitPositions DepartmentUnitPosition = new DepartmentUnitPositions();
            SystemUser systemUser = new SystemUser();
            systemUser.UserName = txtUserName.Text;
            systemUser.UserPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1"); ;

            List<SystemUser> systeUserList = systemUserController.GetAllSystemUser(systemUser.UserName);

            if (systeUserList.Count != 0)
            {
                if (systeUserList[0].UserName.ToLower() == systemUser.UserName.ToLower() && systeUserList[0].UserPwd == systemUser.UserPwd)
                {

                    Session["UserId"] = systeUserList[0].SystemUserId;
                    Session["UserTypeId"] = systeUserList[0].UserTypeId;
                    Session["DesignationId"] = systeUserList[0].DesignationId;
                    Session["Name"] = systeUserList[0].Name;
                    Session["EmpNumber"] = systeUserList[0].EmpNumber;

                    DepartmentUnitPosition = DepUnitPositionController.departmentUnitPositionWithPID(systeUserList[0].SystemUserId);

                    Session["DepUnitPositionId"] = DepartmentUnitPosition.DepartmetUnitPossitionsId;
                    Session["DepUnitParentId"] = DepartmentUnitPosition.ParentId;

                    systemUserController.UpdateLastLoginDate(systeUserList[0]);

                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    txtPassword.Text = string.Empty;
                    lblErrorMsg.Text = "Incorrect Username or Password!";
                }

            }
            else
            {
                txtPassword.Text = string.Empty;
                lblErrorMsg.Text = "Incorrect Username or Password!";
            }
        }
    }
}