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
        //public DistressLoan distressLoanObj = new DistressLoan();
        public List<GuarantorDetail> guarantordetailList = new List<GuarantorDetail>();
        public List<RequestorGuarantor> requestorGuarantorList = new List<RequestorGuarantor>();
        public int loanDetailsId;

        LoanDetailsController loanDetailsController = ControllerFactory.CreateLoanDetailsController();
        DistressLoanController distressLoanController = ControllerFactory.CreateDistressLoanController();
        GuarantorDetailController guarantorDetailController = ControllerFactory.CreateGuarantorDetailController();
        RequestorGuarantorController requestorGuarantorController = ControllerFactory.CreateRequestorGuarantorController();
        ApprovalHistoryController approvalHistoryController = ControllerFactory.CreateApprovalHistoryController();

        public int EmpId;

        public string salarySlip;
        public string SalarySlip { get { return salarySlip; } }
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
            loanDetailList = loanDetailList.Where(x => x.ApprovalStatusId == 1).ToList();

            gvLoan.DataSource = loanDetailList;
            gvLoan.DataBind();

            LoanTypeController loanTypeController = ControllerFactory.CreateLoanTypeController();
            loanTypeList = loanTypeController.GetAllLoanType();

            ddlLoanType.DataSource = loanTypeList;
            ddlLoanType.DataValueField = "Id";
            ddlLoanType.DataTextField = "Loan_Type_Name";
            ddlLoanType.DataBind();
            ddlLoanType.Items.Insert(0, new ListItem("Select Loan Type", ""));


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

            if (loanDetailObj.LoanTypeId == 3)
            {
                btnApprove.Visible = false;
                btnReject.Visible = false;
            }

            ViewState["LoanDetailId"] = loanDetailObj.LoanDetailsId;
            ViewState["LoanTypeId"] = loanDetailObj.LoanTypeId;

            //loanDetailList = loanDetailsController.GetAllLoanDetailWithStatus(true, true);

            //loanDetailObj = loanDetailList.Where(x => x.LoanDetailsId == loanDetailsId).Single();



            ddlLoanType.SelectedValue = loanDetailObj.LoanTypeId.ToString();
            txtName.Text = loanDetailObj.FullName;
            txtPosition.Text = loanDetailObj.Position;
            txtPositionType.Text = loanDetailObj.WorkType;
            txtWorkPlace.Text = loanDetailObj.WorkPlace;
            txtAppointmentDate.Text = loanDetailObj.AppointedDate.ToString("yyyy-MM-dd");
            txtViewBasicSalary.Text = loanDetailObj.BasicSalary.ToString();
            txtRequestinLoanAmount.Text = loanDetailObj.LoanAmount.ToString();
            txtDateWanted.Text = loanDetailObj.LoanRequireDate.ToString("yyyy-MM-dd");


            List<DistressLoan> distressLoanObj = distressLoanController.GetAllDistressLoan();
            distressLoanObj = distressLoanObj.Where(x => x.LoanDetailsId == loanDetailObj.LoanDetailsId).ToList();

            if (distressLoanObj.Count > 0)
            {
                txtLoanReason.Text = distressLoanObj[0].ReasonForLoan;
                txtLastLoan.Text = distressLoanObj[0].LastLoanDate.ToString("yyyy-MM-dd");

                //ddlLastLoanType.SelectedValue = distressLoanObj.LastLoanType.ToString();
                //txtLastLoanAmount.Text = distressLoanObj.LastLoanAmount.ToString();
                //txtPayableLoanAmount.Text = distressLoanObj.PayableAmount.ToString();
                //txtDistressLoanBalance.Text = distressLoanObj.DistressLoanBalance.ToString();
                //txtPremiumAmount.Text = distressLoanObj.PeriodicalAmount.ToString();
                //txtNumberOfInstallments.Text = distressLoanObj.NoOfPeriods.ToString();

                salarySlip = distressLoanObj[0].SalarySlip;

                guarantordetailList = guarantorDetailController.GetAllGuarantorDetail().Where(x => x.DistressLoanId == distressLoanObj[0].DistressLoanId).ToList();

                gvGuarantor.DataSource = guarantordetailList;
                gvGuarantor.DataBind();

                requestorGuarantorList = requestorGuarantorController.GetAllRequestorGuarantor().Where(x => x.DistressLoanId == distressLoanObj[0].DistressLoanId).ToList();

                gvApplicantAsGurontor.DataSource = requestorGuarantorList;
                gvApplicantAsGurontor.DataBind();
            }



        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            ApprovalHistory approvalHistory = new ApprovalHistory();
            DistressLoan distressLoan = null;
            LoanDetail loanDetail = null;

            DistressLoanController distressLoanController = ControllerFactory.CreateDistressLoanController();

            bool validationFlag = false;

            approvalHistory.ApproveDate = DateTime.Now;
            approvalHistory.ApproveBy = Convert.ToInt32(Session["EmpNumber"]);
            approvalHistory.ApprovalStatusId = 4;
            approvalHistory.LoanDetailsId = Convert.ToInt32(ViewState["LoanDetailId"]);
            approvalHistory.RejectReason = "";

            if (Convert.ToInt32(ViewState["LoanTypeId"]) != 3)
            {
                loanDetail = new LoanDetail();

                if (txtLastLoanPaidDateAdvance.Text != "")
                {
                    loanDetail.LastLoanPaidMonth = DateTime.Parse(txtLastLoanPaidDateAdvance.Text);

                }
                else
                {
                    loanDetail.LastLoanPaidMonth = DateTime.MinValue;

                }

                if (txtLastLoanDateAdvance.Text != "")
                {
                    loanDetail.LastLoanDate = DateTime.Parse(txtLastLoanDateAdvance.Text);

                }
                else
                {
                    loanDetail.LastLoanDate = DateTime.MinValue;

                }


                loanDetail.LoanDetailsId = Convert.ToInt32(ViewState["LoanDetailId"]);
                loanDetail.ApprovalStatusId = 4;

                int response = loanDetailsController.UpdateStatusWithHistory(approvalHistory.LoanDetailsId, 4, approvalHistory, loanDetail, distressLoan);

                if (response != 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Succesfully Approved!', 'success');window.setTimeout(function(){window.location='ApproveLoan.aspx'},2500);", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something went wrong!', 'error');window.setTimeout(function(){window.location='ApproveLoan.aspx'},2500);", true);
                }
            }
            //Only if Distress Loan
            else
            {
                distressLoan = new DistressLoan();
                distressLoan.LoanDetailsId = Convert.ToInt32(ViewState["LoanDetailId"]);

                if (ddlLastLoanType.Text != "")
                {
                    distressLoan.LastLoanDate = DateTime.Parse(txtLastLoanDate.Text);
                    distressLoan.LastLoanAmount = double.Parse(txtLastLoanAmount.Text);
                    distressLoan.LastLoanBalance = float.Parse(txtLastLoanBalance.Text);

                }
                else
                {
                    distressLoan.LastLoanDate = DateTime.MinValue;
                    distressLoan.LastLoanAmount = 0;
                    distressLoan.LastLoanBalance = 0;

                }
                distressLoan.LastLoanAmount = double.Parse(txtLastLoanAmount.Text);
                distressLoan.FourtyOfSalary = rbIsFourty.SelectedItem.Text;
                distressLoan.PayableAmount = float.Parse(txtPayableLoanAmount.Text);
                distressLoan.DistressLoanBalance = float.Parse(txtDistressLoanBalance.Text);
                distressLoan.PeriodicalAmount = float.Parse(txtPremiumAmount.Text);
                distressLoan.NoOfPeriods = Convert.ToInt32(txtNumberOfInstallments.Text);

                if (rbIsGurontorAcceptable.SelectedValue != "")
                {
                    distressLoan.GuarantorApprove = rbIsGurontorAcceptable.SelectedItem.Text;

                }
                else
                {
                    distressLoan.GuarantorApprove = "";

                }



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

                    int response = loanDetailsController.UpdateStatusWithHistory(approvalHistory.LoanDetailsId, 4, approvalHistory, loanDetail, distressLoan);

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


        }


        protected void btnRejectReason_Click(object sender, EventArgs e)
        {
            DistressLoanController distressLoanController = ControllerFactory.CreateDistressLoanController();
            DistressLoan distressLoan = null;
            LoanDetail loanDetail = null;

            ApprovalHistory approvalHistory = new ApprovalHistory();
            approvalHistory.ApproveDate = DateTime.Now;
            approvalHistory.ApproveBy = Convert.ToInt32(Session["EmpNumber"]);
            approvalHistory.ApprovalStatusId = 5;
            approvalHistory.LoanDetailsId = Convert.ToInt32(ViewState["LoanDetailId"]);
            approvalHistory.RejectReason = txtrejectReason.Text;



            if (Convert.ToInt32(ViewState["LoanTypeId"]) != 3)
            {
                loanDetail = new LoanDetail();

                if (txtLastLoanPaidDateAdvance.Text != "")
                {
                    loanDetail.LastLoanPaidMonth = DateTime.Parse(txtLastLoanPaidDateAdvance.Text);

                }
                else
                {
                    loanDetail.LastLoanPaidMonth = DateTime.MinValue;

                }

                if (txtLastLoanDateAdvance.Text != "")
                {
                    loanDetail.LastLoanDate = DateTime.Parse(txtLastLoanDateAdvance.Text);

                }
                else
                {
                    loanDetail.LastLoanDate = DateTime.MinValue;

                }

                loanDetail.LoanDetailsId = Convert.ToInt32(ViewState["LoanDetailId"]);
                loanDetail.ApprovalStatusId = 5;

                int response = loanDetailsController.UpdateStatusWithHistory(approvalHistory.LoanDetailsId, 5, approvalHistory, loanDetail, distressLoan);

                if (response != 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Succesfully Rejected!', 'success');window.setTimeout(function(){window.location='ApproveLoan.aspx'},2500);", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something went wrong!', 'error');window.setTimeout(function(){window.location='ApproveLoan.aspx'},2500);", true);
                }
            }
            //Only if Distress Loan
            else
            {
                distressLoan = new DistressLoan();
                distressLoan.LoanDetailsId = Convert.ToInt32(ViewState["LoanDetailId"]);

                distressLoan.LastLoanType = Convert.ToInt32(ddlLastLoanType.SelectedValue);

                if (ddlLastLoanType.Text != "")
                {
                    distressLoan.LastLoanDate = DateTime.Parse(txtLastLoanDate.Text);
                    distressLoan.LastLoanAmount = double.Parse(txtLastLoanAmount.Text);
                    distressLoan.LastLoanBalance = float.Parse(txtLastLoanBalance.Text);

                }
                else
                {
                    distressLoan.LastLoanDate = DateTime.MinValue;
                    distressLoan.LastLoanAmount = 0;
                    distressLoan.LastLoanBalance = 0;

                }


                distressLoan.FourtyOfSalary = rbIsFourty.SelectedItem.Text;
                distressLoan.PayableAmount = float.Parse(txtPayableLoanAmount.Text);
                distressLoan.DistressLoanBalance = float.Parse(txtDistressLoanBalance.Text);
                distressLoan.PeriodicalAmount = float.Parse(txtPremiumAmount.Text);
                distressLoan.NoOfPeriods = Convert.ToInt32(txtNumberOfInstallments.Text);


                if (rbIsGurontorAcceptable.SelectedValue != "")
                {
                    distressLoan.GuarantorApprove = rbIsGurontorAcceptable.SelectedItem.Text;

                }
                else
                {
                    distressLoan.GuarantorApprove = "";

                }

                int response = loanDetailsController.UpdateStatusWithHistory(approvalHistory.LoanDetailsId, 5, approvalHistory, loanDetail, distressLoan);

                if (response != 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Succesfully Rejected!', 'success');window.setTimeout(function(){window.location='ApproveLoan.aspx'},2500);", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something went wrong!', 'error');window.setTimeout(function(){window.location='ApproveLoan.aspx'},2500);", true);
                }
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