using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class GuarantorDetail
    {
        [DBField("Id")]
        public int GuarantorDetailId { get; set; }

        [DBField("Distress_Loan_Id")]
        public int DistressLoanId { get; set; }

        [DBField("Name")]
        public string Name { get; set; }

        [DBField("Position")]
        public string Position { get; set; }

        [DBField("Appointed_Date")]
        public DateTime AppointedDate { get; set; }

        [DBField("Address")]
        public string Address { get; set; }
    }
}
