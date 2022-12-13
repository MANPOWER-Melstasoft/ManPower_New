﻿using ManPowerCore.Common;
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

            SystemUser systemUser = new SystemUser();
            systemUser.UserName = txtUserName.Text;
            systemUser.UserPwd = txtPassword.Text;
            //FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1"); ;

            List<SystemUser> systeUserList = systemUserController.GetAllSystemUser(systemUser.UserName);

            if (systeUserList.Count != 0)
            {
                if (systeUserList[0].UserName == systemUser.UserName && systeUserList[0].UserPwd == systemUser.UserPwd)
                {
                    Session["UserId"] = systemUser.SystemUserId;
                    Session["UserTypeId"] = systemUser.UserTypeId;
                    Session["DesignationId"] = systemUser.DesignationId;
                    Session["Name"] = systemUser.Name;

                    Response.Redirect("DME21.aspx");
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