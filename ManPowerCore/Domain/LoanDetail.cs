using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class LoanDetail
    {
        [DBField("Id")]
        public int LoanDetailsId { get; set; }

        [DBField("Payment_Voucher_Id")]
        public int PaymentVoucherId { get; set; }

        [DBField("Employee_ID")]
        public int EmployeeId { get; set; }

        [DBField("Approval_Status_Id")]
        public int ApprovalStatusId { get; set; }

        [DBField("Loan_Type_Id")]
        public int LoanTypeId { get; set; }

        [DBField("Full_Name")]
        public string FullName { get; set; }

        [DBField("Position")]
        public string Position { get; set; }

        [DBField("Work_Place")]
        public string WorkPlace { get; set; }

        [DBField("Work_Type")]
        public string WorkType { get; set; }

        [DBField("Appointed_Date")]
        public DateTime AppointedDate { get; set; }

        [DBField("Basic_Salary")]
        public float BasicSalary { get; set; }

        [DBField("Loan_Amount")]
        public float LoanAmount { get; set; }

        [DBField("Loan_Require_Date")]
        public DateTime LoanRequireDate { get; set; }

        [DBField("Created_Date")]
        public DateTime CreatedDate { get; set; }

        [DBField("Salary_No")]
        public string SalaryNo { get; set; }

        [DBField("Last_Loan_Date")]
        public DateTime LastLoanDate { get; set; }

        [DBField("Last_Loan_Paid_Month")]
        public DateTime LastLoanPaidMonth { get; set; }

        [DBField("Is_Active")]
        public int IsActive { get; set; }

        public ApprovalType ApprovalType { get; set; }

        public LoanType LoanType { get; set; }
    }
}
