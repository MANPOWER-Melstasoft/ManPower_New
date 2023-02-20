using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class RequestorGuarantor
    {
        [DBField("Id")]
        public int GuarantorDetailId { get; set; }

        [DBField("Distress_Loan_Id")]
        public int DistressLoanId { get; set; }

        [DBField("Name_Of_Officer")]
        public string OfficerName { get; set; }

        [DBField("Amount")]
        public float Amount { get; set; }

        [DBField("Periodical_Amount")]
        public float PeriodicalAmount { get; set; }

        [DBField("Interest")]
        public float Interest { get; set; }
    }
}
