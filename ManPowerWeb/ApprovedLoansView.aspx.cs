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
using System.Xml.Linq;

namespace ManPowerWeb
{
    public partial class ApprovedLoansView : System.Web.UI.Page
    {
        public int loanDetailsId;
        public List<LoanDetail> loanDetailList = new List<LoanDetail>();
        public LoanDetail loanDetailObj = new LoanDetail();
        public List<LoanType> loanTypeList = new List<LoanType>();
        public DistressLoan distressLoanObj = new DistressLoan();
        public List<GuarantorDetail> guarantordetailList = new List<GuarantorDetail>();
        public List<RequestorGuarantor> requestorGuarantorList = new List<RequestorGuarantor>();
        public ApprovalHistory approvalHistoryObj = new ApprovalHistory();
        public int EmpId;
        public string salarySlip;

        static string EmployeeId;
        string encryptedTicket;
        public string SalarySlip { get { return salarySlip; } }


        LoanDetailsController loanDetailsController = ControllerFactory.CreateLoanDetailsController();
        DistressLoanController distressLoanController = ControllerFactory.CreateDistressLoanController();
        GuarantorDetailController guarantorDetailController = ControllerFactory.CreateGuarantorDetailController();
        RequestorGuarantorController requestorGuarantorController = ControllerFactory.CreateRequestorGuarantorController();
        ApprovalHistoryController approvalHistoryController = ControllerFactory.CreateApprovalHistoryController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //----------------------- Decrypt URL ---------------------------------------------------
                encryptedTicket = Request.QueryString["encrypt"];
                FormsAuthenticationTicket decryptedTicket = FormsAuthentication.Decrypt(encryptedTicket);
                loanDetailsId = Convert.ToInt32(HttpUtility.ParseQueryString(decryptedTicket.UserData)["LoanDetailId"]);


                //EmployeeId = Request.QueryString["id"];

                BindDataSource();
            }
        }
        public void BindDataSource()
        {

            loanDetailList = loanDetailsController.GetAllLoanDetailWithStatus(true, true);

            loanDetailObj = loanDetailList.Where(x => x.LoanDetailsId == loanDetailsId).Single();

            BindDdlLoanType();

            ddlLoanType.SelectedValue = loanDetailObj.LoanTypeId.ToString();
            if (loanDetailObj.LoanTypeId == 1)
            {
                lblLoanType.Text = "Special Loan";
            }
            else if (loanDetailObj.LoanTypeId == 2)
            {
                lblLoanType.Text = "Festival Loan";
            }
            else
            {
                lblLoanType.Text = "Distress Loan";
            }
            txtName.Text = loanDetailObj.FullName;
            txtPosition.Text = loanDetailObj.Position;
            txtPositionType.Text = loanDetailObj.WorkType;
            txtWorkPlace.Text = loanDetailObj.WorkPlace;
            txtAppointmentDate.Text = loanDetailObj.AppointedDate.ToString("yyyy-MM-dd");
            txtBasicSalary.Text = loanDetailObj.BasicSalary.ToString();
            txtLoanAmount.Text = loanDetailObj.LoanAmount.ToString();
            txtDateWanted.Text = loanDetailObj.LoanRequireDate.ToString("yyyy-MM-dd");

            if (loanDetailObj.LoanTypeId.ToString() == "3")
            {
                distressLoanObj = distressLoanController.GetAllDistressLoan().Where(x => x.LoanDetailsId == loanDetailsId).Single();

                txtLoanReason.Text = distressLoanObj.ReasonForLoan;
                txtLastLoan.Text = distressLoanObj.LastLoanDate.ToString("yyyy-MM-dd");

                ddlLastLoanType.SelectedValue = distressLoanObj.LastLoanType.ToString();
                if (distressLoanObj.LastLoanType == 1)
                {
                    lblLoanType.Text = "Special Loan";
                }
                else if (distressLoanObj.LastLoanType == 2)
                {
                    lblLoanType.Text = "Festival Loan";
                }
                else
                {
                    lblLoanType.Text = "Distress Loan";
                }

                txtLastLoanAmount.Text = distressLoanObj.LastLoanAmount.ToString();
                txtlastLoanDate.Text = distressLoanObj.LastLoanDate.ToString("yyyy-MM-dd");
                txtPayableLoanAmount.Text = distressLoanObj.PayableAmount.ToString();
                txtDistressLoanBalance.Text = distressLoanObj.DistressLoanBalance.ToString();
                txtPremiumAmount.Text = distressLoanObj.PeriodicalAmount.ToString();
                txtNumberOfInstallments.Text = distressLoanObj.NoOfPeriods.ToString();
                txt40SalaryExceed.Text = distressLoanObj.FourtyOfSalary;
                txtGuarantorFaith.Text = distressLoanObj.GuarantorApprove;
                salarySlip = distressLoanObj.SalarySlip;

                guarantordetailList = guarantorDetailController.GetAllGuarantorDetail().Where(x => x.DistressLoanId == distressLoanObj.DistressLoanId).ToList();

                gvGuarantor.DataSource = guarantordetailList;
                gvGuarantor.DataBind();

                requestorGuarantorList = requestorGuarantorController.GetAllRequestorGuarantor().Where(x => x.DistressLoanId == distressLoanObj.DistressLoanId).ToList();

                gvApplicantAsGurontor.DataSource = requestorGuarantorList;
                gvApplicantAsGurontor.DataBind();


                //Admin data bind
                txtIsprobation.Text = distressLoanObj.IsProbation;
                txtIsSuspend.Text = distressLoanObj.IsSuspend;
                txtIsPermenentAfterProbation.Text = distressLoanObj.PossibilityToPermanent;
                txtIsPermannet.Text = distressLoanObj.IsPermanent;
                txtRetireDate.Text = distressLoanObj.RetireDate.ToString("yyyy-MM-dd");
                txtConsolidatedSalary.Text = distressLoanObj.MonthlyConsolidatedSalary.ToString();



            }


        }
        public void BindDdlLoanType()
        {
            LoanTypeController loanTypeController = ControllerFactory.CreateLoanTypeController();

            loanTypeList = loanTypeController.GetAllLoanType();

            ddlLoanType.DataSource = loanTypeList;
            ddlLoanType.DataValueField = "Id";
            ddlLoanType.DataTextField = "Loan_Type_Name";
            ddlLoanType.DataBind();

            ddlLastLoanType.DataSource = loanTypeList;
            ddlLastLoanType.DataValueField = "Id";
            ddlLastLoanType.DataTextField = "Loan_Type_Name";
            ddlLastLoanType.DataBind();
        }
    }
}