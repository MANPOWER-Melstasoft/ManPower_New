using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class Resignation
    {
        [DBField("Id")]
        public int Id { get; set; }

        [DBField("Transfers_Retirement_Resignation_Main_Id")]
        public int MainId { get; set; }

        [DBField("Resignation_Date")]
        public DateTime ResignationDate { get; set; }

        [DBField("Reason")]
        public string Reason { get; set; }

        [DBField("Is_Active")]
        public int IsActive { get; set; }

        public TransfersRetirementResignationMain transfersRetirementResignationMain { get; set; }
    }
}
