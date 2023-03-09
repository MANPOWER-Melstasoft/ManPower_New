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
    public partial class AddSupplier : System.Web.UI.Page
    {
        List<SupplierType> supplierTypeList = new List<SupplierType>();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                bindaDataSource();
            }
        }

        private void bindaDataSource()
        {
            SupplierTypeController supplierTypeController = ControllerFactory.CreateSupplierTypeController();
            supplierTypeList = supplierTypeController.GetAllSupplierType();
            supplierTypeList = supplierTypeList.Where(x => x.IsActive == 1).ToList();

            ddlSupplierType.DataSource = supplierTypeList;
            ddlSupplierType.DataValueField = "Id";
            ddlSupplierType.DataTextField = "SupplyTypeName";
            ddlSupplierType.DataBind();
            ddlSupplierType.Items.Insert(0, new ListItem("Select Supplier Type", ""));

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();

            SupplierController supplierController = ControllerFactory.CreateSupplierController();

            supplier.CreatedDate = DateTime.Now;
            supplier.CreatedUser = Session["Name"].ToString();
            supplier.Name = txtName.Text;
            supplier.Address = txtAddres.Text;
            supplier.VatRegNumber = txtVatRegNpo.Text;
            supplier.SupplierTypeId = Convert.ToInt32(ddlSupplierType.SelectedValue);
            supplier.StatusId = 1;

            int TargetResponse = supplierController.Save(supplier);

            if (TargetResponse != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success')", true);
                clear();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);
            }

        }

        private void clear()
        {
            txtName.Text = "";
            txtAddres.Text = "";
            txtVatRegNpo.Text = "";
            ddlSupplierType.ClearSelection();
        }
    }
}
