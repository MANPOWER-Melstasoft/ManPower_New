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
    public partial class ApproveLoan : System.Web.UI.Page
    {
        List<LoanType> loanTypeList = new List<LoanType>();
        static List<LoanDetail> loanDetailList = new List<LoanDetail>();
        LoanDetailsController loanDetailsController = ControllerFactory.CreateLoanDetailsController();
        public int EmpId;
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
            loanDetailList = loanDetailsController.GetAllLoanDetailWithStatus(true, true);
            //  loanDetailList = loanDetailList.Where(x => x.EmployeeId == EmpId).ToList();

            gvLoan.DataSource = loanDetailList;
            gvLoan.DataBind();
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {


        }

        protected void btnCheck_Click1(object sender, EventArgs e)
        {
            double caluculation = float.Parse(txtBasicSalary.Text) * 0.4;

            double balance = caluculation - double.Parse(txtTotalDeduction.Text);

            if (balance > double.Parse(txtLoanAmount.Text))
            {
                lblCkeckerSuccess.Text = "Pass";
                lblCkeckerSuccess.Visible = true;
                lblCkeckerfailed.Visible = false;



            }
            else
            {
                lblCkeckerfailed.Text = "Failed";
                lblCkeckerSuccess.Visible = false;
                lblCkeckerfailed.Visible = true;
            }
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = gvLoan.PageSize;
            int pageindex = gvLoan.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;

            LoanDetail loanDetailObj = loanDetailList[rowIndex];

            txtLoanAmount.Text = loanDetailObj.LoanAmount.ToString();
            txtEmployeeId.Text = loanDetailObj.EmployeeId.ToString();

        }
    }
}