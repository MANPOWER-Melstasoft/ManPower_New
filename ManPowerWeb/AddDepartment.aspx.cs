using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ManPowerWeb
{
    public partial class AddDepartmentUnit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDepartmentList();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            DepartmentUnitController departmentUnitController2 = ControllerFactory.CreateDepartmentUnitController();

            int parentId = 0;
            DepartmentUnit departmentUnit = new DepartmentUnit();
            departmentUnit.DepartmentUnitTypeId = Convert.ToInt32(ddlDepartment.SelectedValue);

            if (ddlDepartment.SelectedValue == "2")
            {
                departmentUnit.Name = txtDistrict.Text;
                parentId = 1;
            }
            if (ddlDepartment.SelectedValue == "3")
            {
                departmentUnit.Name = txtDsDivision.Text;
                parentId = Convert.ToInt32(ddlDistrict.SelectedValue);
            }

            List<DepartmentUnit> CheckDepartmentUnitList = departmentUnitController2.GetAllDepartmentUnit(departmentUnit.Name, departmentUnit.DepartmentUnitTypeId, parentId);

            if (CheckDepartmentUnitList.Count == 0)
            {
                departmentUnit.Email = txtEmail.Text;
                departmentUnit.Fax = txtFax.Text;
                departmentUnit.AddressLine1 = txtAddLine1.Text;
                departmentUnit.AddressLine2 = txtAddLine2.Text;
                departmentUnit.AddressLine3 = txtAddLine3.Text;
                departmentUnit.ParentId = parentId;

                DepartmentUnitController departmentUnitController = ControllerFactory.CreateDepartmentUnitController();
                departmentUnitController.SaveDepartmentUnit(departmentUnit);

                Clear();
                lblErrorMsg.Text = "";
                lblSuccessMsg.Text = "Record Updated Successfully!";

            }
            else
            {
                lblSuccessMsg.Text = "";
                lblErrorMsg.Text = "This Department Is Already Exist!";
            }


        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void BindDepartmentList()
        {
            DepartmentUnitTypeController departmentUnitTypeController = ControllerFactory.CreateDepartmentUnitTypeController();
            List<DepartmentUnitType> departmentUnitTypeList = departmentUnitTypeController.GetAllDepartmentUnitType(false);


            ddlDepartment.DataSource = departmentUnitTypeList;
            ddlDepartment.DataValueField = "DepartmentUnitTypeId";
            ddlDepartment.DataTextField = "Name";
            ddlDepartment.DataBind();
            ddlDepartment.Items.RemoveAt(0);
            ddlDepartment.Items.Insert(0, new ListItem("-- select department --", ""));

        }

        private void BindDistricList()
        {
            DepartmentUnitTypeController _DepartmentUnitTypeController = ControllerFactory.CreateDepartmentUnitTypeController();
            List<DepartmentUnit> districtList = _DepartmentUnitTypeController.GetDepartmentUnitType(2, true)._DepartmentUnit;



            ddlDistrict.DataSource = districtList;
            ddlDistrict.DataValueField = "DepartmentUnitId";
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("-- select district --", ""));

        }

        private void Clear()
        {
            ddlDepartment.SelectedIndex = 0;
            ddlDistrict.SelectedIndex = 0;
            txtDistrict.Text = string.Empty;
            txtDsDivision.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtAddLine1.Text = string.Empty;
            txtAddLine2.Text = string.Empty;
            txtAddLine3.Text = string.Empty;
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDepartment.SelectedItem.Value == "3")
            {
                BindDistricList();
            }
        }
    }
}