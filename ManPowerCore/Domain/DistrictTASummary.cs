using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class DistrictTASummary
    {
        public int ProgramTargetId { get; set; }

        public int ProgramPlanId { get; set; }

        public string ProgramTargetName { get; set; }

        public int ProjectTypeId { get; set; }

        public int Target { get; set; }

        public int Achievement { get; set; }

        public int NoOfBeneficiary { get; set; }

        public string Location { get; set; }

        //public string OfficerName { get; set; }

    }
}
