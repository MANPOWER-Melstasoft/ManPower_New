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
    public partial class UserRolePrivileges : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUserType();
            }
        }


        protected void btnChange_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            List<AutFunction> autUserFunctionList = (List<AutFunction>)ViewState["previlagesList"];

            AutSystemRoleFunctionController autSystemRoleFunctionController = ControllerFactory.CreateAutSystemRoleFunctionController();

            AutSystemRoleFunction autSystemRoleFunction = new AutSystemRoleFunction();
            autSystemRoleFunction.UserTypeId = Convert.ToInt32(ddlUser.SelectedValue);
            autSystemRoleFunction.AutFunctionId = autUserFunctionList[rowIndex].AutFunctionId;

            autSystemRoleFunctionController.Change(autSystemRoleFunction);

            BindFunctionList();
        }



        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUser.SelectedValue != "")
            {
                gvUserPrevilages.Visible = true;
                BindFunctionList();
            }
            else
            {
                gvUserPrevilages.Visible = false;
            }
        }

        private void BindUserType()
        {
            UserTypeController userTypeController = ControllerFactory.CreateUserTypeController();
            List<UserType> userList = userTypeController.GetAllUserType(false);

            ddlUser.DataSource = userList;
            ddlUser.DataValueField = "UserTypeId";
            ddlUser.DataTextField = "UserTypeName";
            ddlUser.DataBind();
            ddlUser.Items.Insert(0, new ListItem("-- select user type --", ""));

            ViewState["usertypeList"] = userList;
        }


        private void BindFunctionList()
        {

            AutFunctionController autFunctionController = ControllerFactory.CreateAutFunctionController();
            List<AutFunction> autFunctionList = autFunctionController.GetAllAutFunction();

            foreach (var item in autFunctionList)
            {
                item.Status = "NO";
            }

            AutSystemRoleFunctionController autSystemRoleFunctionController = ControllerFactory.CreateAutSystemRoleFunctionController();
            List<AutSystemRoleFunction> autSystemRoleFunctionList = autSystemRoleFunctionController.GetAllAutSystemRoleFunctionById(Convert.ToInt32(ddlUser.SelectedValue));

            if (autSystemRoleFunctionList.Count != 0)
            {

                foreach (var item1 in autFunctionList)
                {
                    foreach (var item2 in autSystemRoleFunctionList)
                    {
                        if (item2.AutFunctionId == item1.AutFunctionId)
                        {
                            item1.Status = "YES";
                        }
                    }
                }
            }

            gvUserPrevilages.DataSource = autFunctionList;
            gvUserPrevilages.DataBind();

            ViewState["previlagesList"] = autFunctionList;

        }

    }
}