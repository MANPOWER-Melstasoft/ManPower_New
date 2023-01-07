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
            if (checkExsits())
            {
                DistricDsParentController districDsParentController = ControllerFactory.CreateDistricDsParentController();

                DistricDsParent districDsParent = new DistricDsParent();

                if (btnSubmit.Text == "Update")
                {
                    int Id = (int)ViewState["updatedRowIndex"];

                    districDsParent.Id = Id;
                    districDsParent.ParentUserId = Convert.ToInt32(ddlUser.SelectedValue);
                    districDsParent.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);

                    districDsParentController.Update(districDsParent);
                    btnSubmit.Text = "Create";
                    ddlUser.Enabled = true;
                }
                else
                {

                    districDsParent.ParentUserId = Convert.ToInt32(ddlUser.SelectedValue);
                    districDsParent.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);

                    districDsParentController.Save(districDsParent);
                }

                Clear();
                BindDataSource();

                lblErrorMsg.Text = string.Empty;
                lblSuccessMsg.Text = "Record Updated Successfully!";
            }
            else
            {
                lblErrorMsg.Text = "Already Exists!";
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pageSize = gvParent.PageSize;
            int pageIndex = gvParent.PageIndex;

            rowIndex = (pageSize * pageIndex) + rowIndex;
            List<DistricDsParent> districDsParentList = (List<DistricDsParent>)ViewState["districDsParentList"];

            ddlUser.SelectedValue = Convert.ToString(districDsParentList[rowIndex].ParentUserId);
            ddlUser.Enabled = false;
            ddlDepartment.SelectedValue = Convert.ToString(districDsParentList[rowIndex].DepartmentId);
            btnSubmit.Text = "Update";
            ViewState["updatedRowIndex"] = districDsParentList[rowIndex].Id;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DistricDsParentController districDsParentController = ControllerFactory.CreateDistricDsParentController();

            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pageSize = gvParent.PageSize;
            int pageIndex = gvParent.PageIndex;

            rowIndex = (pageSize * pageIndex) + rowIndex;
            List<DistricDsParent> districDsParentList = (List<DistricDsParent>)ViewState["districDsParentList"];
            DistricDsParent districDsParent = new DistricDsParent
            {
                ParentUserId = districDsParentList[rowIndex].ParentUserId,
                DepartmentId = districDsParentList[rowIndex].DepartmentId,
                Id = districDsParentList[rowIndex].Id
            };
            districDsParentController.Delete(districDsParent);

            BindDataSource();
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

            ViewState["districDsParentList"] = districDsParentList;
        }

        private void BindUserList()
        {
            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            List<SystemUser> systemUsersList = systemUserController.GetAllSystemUser(true, true, false);

            systemUsersList = systemUsersList.Where(x => x.UserTypeId == 3 && x._DepartmentUnitPositions.DepartmentUnitId == 1).ToList();

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

        private bool checkExsits()
        {
            DistricDsParentController districDsParentController = ControllerFactory.CreateDistricDsParentController();
            DistricDsParent districDsParent = new DistricDsParent
            {
                ParentUserId = Convert.ToInt32(ddlUser.SelectedValue),
                DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue),
            };

            DistricDsParent districDsParentext1 = districDsParentController.GetDistricDsParent(districDsParent);
            DistricDsParent districDsParentext2 = districDsParentController.GetDistricDsParentFromDep(districDsParent.DepartmentId);

            if (districDsParentext1.Id == 0 && districDsParentext2.Id == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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