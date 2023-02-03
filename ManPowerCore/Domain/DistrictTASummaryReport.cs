using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class DistrictTASummaryReport
    {

        [DBField("Target_ID")]
        public int ProgramTargetId { get; set; }
        [DBField("Plan_ID")]
        public int ProgramPlanId { get; set; }
        [DBField("name")]
        public string ProgramTargetName { get; set; }
        [DBField("Program_Type_Id")]
        public int ProjectTypeId { get; set; }
        [DBField("Projects")]
        public int Target { get; set; }
        [DBField("count")]
        public int Achievement { get; set; }
        [DBField("No_of_Beneficiaries")]
        public int NoOfBeneficiary { get; set; }
        [DBField("Locations")]
        public string Location { get; set; }

        public int PhysicalCount { get; set; }

        public int OnlineCount { get; set; }

        //public string OfficerName { get; set; }
    }
}
