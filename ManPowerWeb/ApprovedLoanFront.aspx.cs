using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class ApprovedLoanFront : System.Web.UI.Page
    {
        static List<LoanDetail> loanDetailList = new List<LoanDetail>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataSource();
            }
        }

        public void BindDataSource()
        {
            LoanDetailsController loanDetailsController = ControllerFactory.CreateLoanDetailsController();

            loanDetailList = loanDetailsController.GetAllLoanDetailWithStatus(true, true);
            loanDetailList = loanDetailList.Where(x => x.ApprovalStatusId == 8).ToList();

            gvApprove1Admin.DataSource = loanDetailList;
            gvApprove1Admin.DataBind();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            //------------------Encrypt URL-------------------------------------- -
            string queryString = "LoanDetailId=" + loanDetailList[rowIndex].LoanDetailsId;
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                version: 1,
                name: "MyAuthTicket",
                issueDate: DateTime.Now,
                expiration: DateTime.Now.AddMinutes(10),
                isPersistent: false,
                userData: queryString,
                cookiePath: FormsAuthentication.FormsCookiePath);

            string encryptedTicket = FormsAuthentication.Encrypt(ticket);

            string url = "ApprovedLoansView.aspx?LoanDetailId=" + encryptedTicket;
            Response.Redirect(url);

        }
    }
}