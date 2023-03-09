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
    public partial class DistressLoanAdmin : System.Web.UI.Page
    {
        List<LoanType> loanTypeList = new List<LoanType>();
        static List<LoanDetail> loanDetailList = new List<LoanDetail>();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                BindDataSource();
            }
        }

        public void BindDataSource()
        {

            LoanDetailsController loanDetailsController = ControllerFactory.CreateLoanDetailsController();
            loanDetailList = loanDetailsController.GetAllLoanDetailWithStatus(true, true);
            loanDetailList = loanDetailList.Where(x => x.ApprovalStatusId == 4).ToList();

            gvLoan.DataSource = loanDetailList;
            gvLoan.DataBind();
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = gvLoan.PageSize;
            int pageindex = gvLoan.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;

            txtLoandetailId.Text = loanDetailList[rowIndex].LoanDetailsId.ToString();

        }

        protected void btnRejectReason_Click(object sender, EventArgs e)
        {

        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {

        }
    }
}