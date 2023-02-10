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
    public partial class ResetPassword : System.Web.UI.Page
    {
        static List<SystemUser> userList = new List<SystemUser>();
        static SystemUser systemUser = new SystemUser();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                BindUser();
            }
        }


        private void BindUser()
        {
            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            userList = systemUserController.GetAllSystemUser(false, true, false);

            ddlUser.DataSource = userList;
            ddlUser.DataValueField = "SystemUserId";
            ddlUser.DataTextField = "Name";
            ddlUser.DataBind();
            ddlUser.Items.Insert(0, new ListItem("-- select user --", ""));

        }

        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUser.SelectedValue != "")
            {
                systemUser = userList.Where(x => x.SystemUserId == Convert.ToInt32(ddlUser.SelectedValue)).Single();
                lblUserType.Text = systemUser._UserType.UserTypeName;
            }
            else
            {
                lblUserType.Text = "";

            }
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();

            if (txtNewPasword.Text == txtReNewPasword.Text)
            {
                int output = 0;
                lblMisMatchPwd.Text = string.Empty;
                systemUser.UserPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtReNewPasword.Text, "SHA1");
                output = systemUserController.ChangePassword(systemUser);

                if (output == 1)
                {
                    ddlUser.SelectedIndex = 0;
                    lblUserType.Text = string.Empty;
                    txtNewPasword.Text = string.Empty;
                    txtReNewPasword.Text = string.Empty;

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Password Changed Succesfully!', 'success');window.setTimeout(2500);", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Password Changed Fail!', 'error');", true);
                }
            }
            else
            {
                lblMisMatchPwd.Text = "Password MissMatch";
            }
        }

    }
}