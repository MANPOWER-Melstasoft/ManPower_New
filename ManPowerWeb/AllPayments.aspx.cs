using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class AllPayments : System.Web.UI.Page
    {
        PaymentVoucherController PaymentVoucherController = ControllerFactory.CreatePaymentVoucherController();
        List<PaymentVoucher> paymentVoucherList = new List<PaymentVoucher>();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            BindDataSource();

            if (!IsPostBack)
            {
                BindMonth();
            }
        }

        public void BindDataSource()
        {
            paymentVoucherList = PaymentVoucherController.GetAllPaymentVoucherWithSupplier(true);

            gvPayments.DataSource = paymentVoucherList;
            gvPayments.DataBind();
        }

        public void BindMonth()
        {
            List<Month> monthTable = new List<Month>();

            monthTable.Add(new Month() { monthName = "All Month", monthNumber = 0 });
            monthTable.Add(new Month() { monthName = "January", monthNumber = 1 });
            monthTable.Add(new Month() { monthName = "February", monthNumber = 2 });
            monthTable.Add(new Month() { monthName = "March", monthNumber = 3 });
            monthTable.Add(new Month() { monthName = "April", monthNumber = 4 });
            monthTable.Add(new Month() { monthName = "May", monthNumber = 5 });
            monthTable.Add(new Month() { monthName = "June", monthNumber = 6 });
            monthTable.Add(new Month() { monthName = "July", monthNumber = 7 });
            monthTable.Add(new Month() { monthName = "August", monthNumber = 8 });
            monthTable.Add(new Month() { monthName = "September", monthNumber = 9 });
            monthTable.Add(new Month() { monthName = "October", monthNumber = 10 });
            monthTable.Add(new Month() { monthName = "November", monthNumber = 11 });
            monthTable.Add(new Month() { monthName = "December", monthNumber = 12 });

            ddlMonth.DataSource = monthTable;
            ddlMonth.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keyWord = txtKeyWord.Text;
            int month = Convert.ToInt32(ddlMonth.SelectedValue);

            if (month == 0 && keyWord != "")
            {
                paymentVoucherList = paymentVoucherList.Where(x => x.VoucherNumber.ToLower().Contains(keyWord.ToLower())
                || x.PayeeName.ToLower().Contains(keyWord.ToLower())
                || x.PayeeAddress.ToLower().Contains(keyWord.ToLower())).ToList();
            }
            else if (keyWord == "" && month != 0)
            {
                paymentVoucherList = paymentVoucherList.Where(x => x.VoucherDate.Month == month).ToList();
            }
            else if (keyWord != "" && month != 0)
            {
                paymentVoucherList = paymentVoucherList.Where(x => (x.VoucherNumber.ToLower().Contains(keyWord.ToLower()) && x.VoucherDate.Month == month)
                || (x.PayeeName.ToLower().Contains(keyWord.ToLower()) && x.VoucherDate.Month == month)
                || (x.PayeeAddress.ToLower().Contains(keyWord.ToLower())) && x.VoucherDate.Month == month).ToList();
            }

            gvPayments.DataSource = paymentVoucherList;
            gvPayments.DataBind();

            txtKeyWord.Text = string.Empty;
        }

        protected void btnGetAll_Click(object sender, EventArgs e)
        {
            BindDataSource();
            txtKeyWord.Text = string.Empty;
        }

        protected void btvView_Click(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            string url = "AllPaymentsRender.aspx?" + "paymentVoucherID=" + paymentVoucherList[rowIndex].Id;
            Response.Redirect(url);
        }
    }
}