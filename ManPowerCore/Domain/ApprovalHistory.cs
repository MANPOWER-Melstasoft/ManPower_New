using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class ApprovalHistory
    {
        [DBField("Id")]
        public int ApprovalHistoryId { get; set; }

        [DBField("Approval_Status_Id")]
        public int ApprovalStatusId { get; set; }

        [DBField("Loan_Details_Id")]
        public int LoanDetailsId { get; set; }

        [DBField("Approve_By")]
        public int ApproveBy { get; set; }

        [DBField("Approve_Date")]
        public DateTime ApproveDate { get; set; }

        [DBField("Reject_Reason")]
        public string RejectReason { get; set; }
    }
}
