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
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataSource();
            }
        }

        private void BindDataSource()
        {
            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            List<SystemUser> systemUserList = systemUserController.GetAllSystemUser(true, false, false);
            if (Session["UserTypeId"].ToString() == "1")
            {
                systemUserList.RemoveAll(x => x.SystemUserId == Convert.ToInt32(Session["UserId"]));
                gvUser.DataSource = systemUserList;
            }
            if (Session["UserTypeId"].ToString() == "2")
            {
                SystemUser systemUser = systemUserController.GetSystemUser(Convert.ToInt32(Session["UserId"]), true, false, false);
                List<SystemUser> systemUserListFilter = systemUserList.Where(x => x._DepartmentUnitPositions.ParentId == systemUser._DepartmentUnitPositions.DepartmetUnitPossitionsId).ToList();
                gvUser.DataSource = systemUserListFilter;
            }
            gvUser.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUser.PageIndex = e.NewPageIndex;
            BindDataSource();

        }
    }
}