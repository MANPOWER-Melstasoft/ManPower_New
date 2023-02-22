using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class DistressLoan
    {
        [DBField("Id")]
        public int DistressLoanId { get; set; }

        [DBField("Loan_Details_Id")]
        public int LoanDetailsId { get; set; }

        [DBField("Reason_For_Loan")]
        public string ReasonForLoan { get; set; }

        [DBField("Last_Loan_Balance")]
        public double LastLoanBalance { get; set; }

        [DBField("Is_Probation")]
        public string IsProbation { get; set; }

        [DBField("Possibility_To_Permanent")]
        public string PossibilityToPermanent { get; set; }

        [DBField("Is_Permanent")]
        public string IsPermanent { get; set; }

        [DBField("Retire_Date")]
        public DateTime RetireDate { get; set; }

        [DBField("Monthly_Consolidated_salary")]
        public double MonthlyConsolidatedSalary { get; set; }

        [DBField("Is_Suspend")]
        public string IsSuspend { get; set; }

        [DBField("Last_Loan_Type")]
        public int LastLoanType { get; set; }

        [DBField("Last_Loan_Date")]
        public DateTime LastLoanDate { get; set; }

        [DBField("Last_Loan_Amount")]
        public double LastLoanAmount { get; set; }

        [DBField("Fourty_Of_Salary")]
        public string FourtyOfSalary { get; set; }

        [DBField("Payable_Amount")]
        public double PayableAmount { get; set; }

        [DBField("Distress_Loan_Balance")]
        public double DistressLoanBalance { get; set; }

        [DBField("Periodical_Amount")]
        public double PeriodicalAmount { get; set; }

        [DBField("No_Of_Periods")]
        public int NoOfPeriods { get; set; }

        [DBField("Guarantor_Approve")]
        public string GuarantorApprove { get; set; }
    }
}
