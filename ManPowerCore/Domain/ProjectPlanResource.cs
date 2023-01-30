using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]

    public class ProjectPlanResource
    {
        [DBField("Id")]
        public int ResourcePersonPlanId { get; set; }

        [DBField("Resourse_Person_Id")]
        public int ResourcePersonId { get; set; }

        [DBField("Program_Plan_Id")]
        public int ProgramPlanId { get; set; }

    }
}
