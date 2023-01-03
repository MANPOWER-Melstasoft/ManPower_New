using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class AddParent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUserList();
                BindDepartmentList();
                BindDataSource();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DistricDsParentController districDsParentController = ControllerFactory.CreateDistricDsParentController();

            DistricDsParent districDsParent = new DistricDsParent();

            districDsParent.ParentUserId = Convert.ToInt32(ddlUser.SelectedValue);
            districDsParent.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);

            districDsParentController.Save(districDsParent);

            Clear();
            BindDataSource();

            lblErrorMsg.Text = string.Empty;
            lblSuccessMsg.Text = "Record Updated Successfully!";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void BindDataSource()
        {
            DistricDsParentController districDsParentController = ControllerFactory.CreateDistricDsParentController();
            List<DistricDsParent> districDsParentList = districDsParentController.GetAllDistricDsParent(true, true);
            gvParent.DataSource = districDsParentList;
            gvParent.DataBind();
        }

        private void BindUserList()
        {
            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            List<SystemUser> systemUsersList = systemUserController.GetAllSystemUser(false, false, false);

            ddlUser.DataSource = systemUsersList;
            ddlUser.DataValueField = "SystemUserId";
            ddlUser.DataTextField = "UserName";
            ddlUser.DataBind();
            ddlUser.Items.Insert(0, new ListItem("-- select user --", ""));

        }

        private void BindDepartmentList()
        {
            DepartmentUnitController departmentUnitController = ControllerFactory.CreateDepartmentUnitController();
            List<DepartmentUnit> departmentUnitList = departmentUnitController.GetAllDepartmentUnit(false, false);

            ddlDepartment.DataSource = departmentUnitList;
            ddlDepartment.DataValueField = "DepartmentUnitId";
            ddlDepartment.DataTextField = "Name";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("-- select department --", ""));
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvParent.PageIndex = e.NewPageIndex;
            BindDataSource();

        }

        private void Clear()
        {
            ddlDepartment.SelectedIndex = 0;
            ddlUser.SelectedIndex = 0;
            lblErrorMsg.Text = string.Empty;
            lblSuccessMsg.Text = string.Empty;
        }

    }

}