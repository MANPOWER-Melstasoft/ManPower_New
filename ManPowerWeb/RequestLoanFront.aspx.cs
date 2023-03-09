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
    public partial class RequestLoanFront : System.Web.UI.Page
    {
        List<LoanDetail> loanDetailList = new List<LoanDetail>();
        LoanDetailsController loanDetailsController = ControllerFactory.CreateLoanDetailsController();
        public int EmpId;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            EmpId = Convert.ToInt32(Session["EmpNumber"]);
            BindDataSource();
        }

        public void BindDataSource()
        {
            loanDetailList = loanDetailsController.GetAllLoanDetailWithStatus(true, true);
            loanDetailList = loanDetailList.Where(x => x.EmployeeId == EmpId).ToList();

            gvAppliedLoan.DataSource = loanDetailList;
            gvAppliedLoan.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string url = "RequestLoan.aspx";
            Response.Redirect(url);
        }
    }
}