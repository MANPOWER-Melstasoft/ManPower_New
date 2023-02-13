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
    public partial class AddSupplierType : System.Web.UI.Page
    {
        SupplierTypeController supplierTypeController = ControllerFactory.CreateSupplierTypeController();
        List<SupplierType> supplierTypeList = new List<SupplierType>();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataSource();
        }
        private void BindDataSource()
        {

            supplierTypeList = supplierTypeController.GetAllSupplierType();
            gvAddSupplierType.DataSource = supplierTypeList;
            gvAddSupplierType.DataBind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (btnSave.Text == "Update")
            {
                int rowIndex = (int)ViewState["updatedRowIndex"];
                SupplierType supplierType = new SupplierType();
                supplierType.Id = rowIndex;
                supplierType.SupplyTypeName = txtSupplierName.Text;

                supplierTypeController.Update(supplierType);
                btnSave.Text = "Save";
            }
            else
            {
                SupplierType supplierType = new SupplierType();
                supplierType.SupplyTypeName = txtSupplierName.Text;

                supplierTypeController.Save(supplierType);
            }


            Clear();
            BindDataSource();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;


            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pageSize = gvAddSupplierType.PageSize;
            int pageIndex = gvAddSupplierType.PageIndex;

            rowIndex = (pageSize * pageIndex) + rowIndex;

            txtSupplierName.Text = supplierTypeList[rowIndex].SupplyTypeName;
            btnSave.Text = "Update";
            ViewState["updatedRowIndex"] = supplierTypeList[rowIndex].Id;
        }

        private void Clear()
        {
            txtSupplierName.Text = string.Empty;

        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pageSize = gvAddSupplierType.PageSize;
            int pageIndex = gvAddSupplierType.PageIndex;

            rowIndex = (pageSize * pageIndex) + rowIndex;

            supplierTypeList[rowIndex].IsActive = 0;

            supplierTypeController.Update(supplierTypeList[rowIndex]);
            BindDataSource();
        }
    }
}