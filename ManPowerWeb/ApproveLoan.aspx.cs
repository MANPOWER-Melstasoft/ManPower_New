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
            loanDetailList = loanDetailList.Where(x => x.ApprovalStatusId == 2).ToList();

            gvLoan.DataSource = loanDetailList;
            gvLoan.DataBind();

            LoanTypeController loanTypeController = ControllerFactory.CreateLoanTypeController();
            loanTypeList = loanTypeController.GetAllLoanType();

            ddlLastLoanType.DataSource = loanTypeList;
            ddlLastLoanType.DataValueField = "Id";
            ddlLastLoanType.DataTextField = "Loan_Type_Name";
            ddlLastLoanType.DataBind();
            ddlLastLoanType.Items.Insert(0, new ListItem("Select Loan Type", ""));
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
            txtLoanType.Text = loanDetailObj.LoanTypeId.ToString();

            ViewState["LoanDetailId"] = loanDetailObj.LoanDetailsId;


        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            ApprovalHistory approvalHistory = new ApprovalHistory();
            DistressLoanController distressLoanController = ControllerFactory.CreateDistressLoanController();

            DistressLoan distressLoan = new DistressLoan();

            bool validationFlag = false;
            approvalHistory.ApproveDate = DateTime.Now;
            approvalHistory.ApproveBy = Convert.ToInt32(Session["EmpNumber"]);
            approvalHistory.ApprovalStatusId = 4;
            approvalHistory.LoanDetailsId = Convert.ToInt32(ViewState["LoanDetailId"]);
            approvalHistory.RejectReason = "";

            distressLoan.LoanDetailsId = Convert.ToInt32(ViewState["LoanDetailId"]);
            distressLoan.LastLoanType = Convert.ToInt32(ddlLastLoanType.SelectedValue);
            distressLoan.LastLoanDate = DateTime.Parse(txtLastLoanDate.Text);
            distressLoan.LastLoanAmount = double.Parse(txtLastLoanAmount.Text);
            distressLoan.FourtyOfSalary = rbIsFourty.SelectedItem.Text;
            distressLoan.PayableAmount = float.Parse(txtPayableLoanAmount.Text);
            distressLoan.DistressLoanBalance = float.Parse(txtDistressLoanBalance.Text);
            distressLoan.PeriodicalAmount = float.Parse(txtPremiumAmount.Text);
            distressLoan.NoOfPeriods = Convert.ToInt32(txtNumberOfInstallments.Text);
            distressLoan.LastLoanBalance = float.Parse(txtLastLoanBalance.Text);
            distressLoan.GuarantorApprove = rbIsGurontorAcceptable.SelectedItem.Text;


            if (txtLastLoanDate.Text != "" && DateTime.Parse(txtLastLoanDate.Text) < DateTime.Now)
            {
                lbllastLoandate.Visible = true;
                validationFlag = true;
            }
            else
            {
                lbllastLoandate.Visible = false;
            }

            if (validationFlag)
            {
                int response = loanDetailsController.UpdateStatusWithHistory(approvalHistory.LoanDetailsId, 4, approvalHistory, distressLoan);

                if (response != 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Succesfully Approved!', 'success');window.setTimeout(function(){window.location='ApproveLoan.aspx'},2500);", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something went wrong!', 'error');window.setTimeout(function(){window.location='ApproveLoan.aspx'},2500);", true);
                }

            }

        }


        protected void btnRejectReason_Click(object sender, EventArgs e)
        {
            DistressLoanController distressLoanController = ControllerFactory.CreateDistressLoanController();


            ApprovalHistory approvalHistory = new ApprovalHistory();
            approvalHistory.ApproveDate = DateTime.Now;
            approvalHistory.ApproveBy = Convert.ToInt32(Session["EmpNumber"]);
            approvalHistory.ApprovalStatusId = 5;
            approvalHistory.LoanDetailsId = Convert.ToInt32(ViewState["LoanDetailId"]);
            approvalHistory.RejectReason = txtrejectReason.Text;

            DistressLoan distressLoan = new DistressLoan();
            distressLoan.LoanDetailsId = Convert.ToInt32(ViewState["LoanDetailId"]);
            distressLoan.LastLoanType = Convert.ToInt32(ddlLastLoanType.SelectedValue);
            distressLoan.LastLoanDate = DateTime.Parse(txtLastLoanDate.Text);
            distressLoan.LastLoanAmount = double.Parse(txtLastLoanAmount.Text);
            distressLoan.FourtyOfSalary = rbIsFourty.SelectedItem.Text;
            distressLoan.PayableAmount = float.Parse(txtPayableLoanAmount.Text);
            distressLoan.DistressLoanBalance = float.Parse(txtDistressLoanBalance.Text);
            distressLoan.PeriodicalAmount = float.Parse(txtPremiumAmount.Text);
            distressLoan.NoOfPeriods = Convert.ToInt32(txtNumberOfInstallments.Text);
            distressLoan.LastLoanBalance = float.Parse(txtLastLoanBalance.Text);
            distressLoan.GuarantorApprove = rbIsGurontorAcceptable.SelectedItem.Text;

            int response = loanDetailsController.UpdateStatusWithHistory(approvalHistory.LoanDetailsId, 5, approvalHistory, distressLoan);

            if (response != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Succesfully Rejected!', 'success');window.setTimeout(function(){window.location='ApproveLoan.aspx'},2500);", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something went wrong!', 'error');window.setTimeout(function(){window.location='ApproveLoan.aspx'},2500);", true);
            }
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            double caluculation = float.Parse(txtBasicSalary.Text) * 0.4;

            double balance = caluculation - double.Parse(txtTotalDeduction.Text);

            if (balance > double.Parse(txtLoanAmount.Text))
            {
                lblCkecker.Text = "Pass";
                lblCkecker.Visible = true;
                lblCkecker.CssClass = "alert-success";
                btnApprove.Visible = true;
                btnReject.Visible = true;
            }
            else
            {
                lblCkecker.Text = "Failed";
                lblCkecker.CssClass = "alert-danger";
                lblCkecker.Visible = true;
                btnApprove.Visible = false;
                btnReject.Visible = true;
            }
        }
    }
}