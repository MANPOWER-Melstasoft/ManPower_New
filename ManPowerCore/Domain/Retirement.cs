using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class Retirement
    {
        [DBField("Id")]
        public int Id { get; set; }

        [DBField("Transfers_Retirement_Resignation_Main_Id")]
        public int MainId { get; set; }

        [DBField("Joined_Date")]
        public DateTime JoinedDate { get; set; }

        [DBField("Reason")]
        public string Reason { get; set; }

        [DBField("Retirement_Type")]
        public string RetirementType { get; set; }

        [DBField("Remark")]
        public string Remark { get; set; }

        [DBField("Is_Active")]
        public int IsActive { get; set; }

        public TransfersRetirementResignationMain transfersRetirementResignationMain { get; set; }
    }
}
