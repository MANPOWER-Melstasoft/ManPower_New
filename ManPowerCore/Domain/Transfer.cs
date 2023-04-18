using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class Transfer
    {
        [DBField("Id")]
        public int Id { get; set; }

        [DBField("Transfers_Retirement_Resignation_Main_Id")]
        public int MainId { get; set; }

        [DBField("Transfer_Type")]
        public string TransferType { get; set; }

        [DBField("Current_Dep")]
        public string CurrentDep { get; set; }

        [DBField("Department_Unit_Id")]
        public int NextDep { get; set; }

        [DBField("Reason")]
        public string Reason { get; set; }

        [DBField("Is_Active")]
        public int IsActive { get; set; }

        [DBField("From_Date")]
        public DateTime FromDate { get; set; }

        [DBField("To_Date")]
        public DateTime ToDate { get; set; }

        [DBField("Request_Work_Place")]
        public string RequestWorkPlace { get; set; }

        public TransfersRetirementResignationMain transfersRetirementResignationMain { get; set; }
    }
}
