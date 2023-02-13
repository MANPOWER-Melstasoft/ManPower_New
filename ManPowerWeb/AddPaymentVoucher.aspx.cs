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
    public partial class AddPaymentVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                bindDataSource();
            }
        }


        private void bindDataSource()
        {
            SupplierController supplierController = ControllerFactory.CreateSupplierController();

            ddlSupplier.DataSource = supplierController.GetAllSupplier();
            ddlSupplier.DataValueField = "Id";
            ddlSupplier.DataTextField = "Name";
            ddlSupplier.DataBind();
            ddlSupplier.Items.Insert(0, new ListItem("Select Supplier", ""));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            PaymentVoucher paymentVoucher = new PaymentVoucher();

            paymentVoucher.SupplierId = Convert.ToInt32(ddlSupplier.SelectedValue);
            paymentVoucher.VoucherNumber = txtVNumber.Text;
            paymentVoucher.VoucherDate = DateTime.Parse(txtVDate.Text);
            paymentVoucher.PayeeName = txtPName.Text;
            paymentVoucher.PayeeAddress = txtPAddres.Text;
            paymentVoucher.ChequeNumber = txtChequeNumber.Text;
            paymentVoucher.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);

            paymentVoucher.IsVoucherAuthorized = Convert.ToInt32(rbIsVoucherAuthorized.SelectedValue);
            if (rbIsVoucherAuthorized.SelectedValue == "1")
            {
                paymentVoucher.VouAuthorizedDate = DateTime.Parse(txtVAutorizedDate.Text);
                paymentVoucher.VouAuthorizedUser = txtVAutorizedName.Text;
            }
            else
            {
                paymentVoucher.VouAuthorizedDate = DateTime.Parse(txtVAutorizedDate.Text);
                paymentVoucher.VouAuthorizedUser = null;
            }


            paymentVoucher.IsPayAuthorized = Convert.ToInt32(rbPayAutorized.SelectedValue);
            if (rbPayAutorized.SelectedValue == "1")
            {
                paymentVoucher.PayAuthorizedDate = DateTime.Parse(txtPayAutorizedDate.Text);
                paymentVoucher.PayAuthorizedUser = txtPayAutorizedName.Text;
            }
            else
            {
                DateTime? dt = null;
                paymentVoucher.PayAuthorizedDate = Convert.ToDateTime(dt);
                paymentVoucher.PayAuthorizedUser = null;
            }


            paymentVoucher.IsCanceled = Convert.ToInt32(rbIsCanceled.SelectedValue);
            if (rbIsCanceled.SelectedValue == "1")
            {
                paymentVoucher.CanceledDate = DateTime.Parse(txtCancelDate.Text);
                paymentVoucher.CanceledUser = txtCancelName.Text;
            }
            else
            {
                DateTime? dt = null;
                paymentVoucher.CanceledDate = Convert.ToDateTime(dt);
                paymentVoucher.CanceledUser = null;
            }


            paymentVoucher.BankAccount = txtBankAcc.Text;
            paymentVoucher.CreatedDate = DateTime.Now;

            paymentVoucher.CreatedUser = Session["UserId"].ToString();

            PaymentVoucherController paymentVoucherController = ControllerFactory.CreatePaymentVoucherController();

            int response = paymentVoucherController.Save(paymentVoucher);

            if (response != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Added Succesfully!', 'success');window.setTimeout(function(){window.location='AddPaymentVoucher.aspx'},2500);", true);

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');window.setTimeout(function(){window.location='AddPaymentVoucher.aspx'},2500);", true);
            }




        }
    }

}