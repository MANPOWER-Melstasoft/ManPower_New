using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class JobPlacementFeedback
    {
        [DBField("ID")]
        public int JobPlacementFeedbackId { get; set; }

        [DBField("Job_Refferals_Id")]
        public int JobRefferalsId { get; set; }

        [DBField("Created_Date")]
        public DateTime CreatedDate { get; set; }

        [DBField("Created_User")]
        public string CreatedUser { get; set; }

        [DBField("Still_Working")]
        public int StillWorking { get; set; }

        [DBField("Resigned_Date")]
        public DateTime ResignedDate { get; set; }

        [DBField("REMARKS")]
        public string Remarks { get; set; }

        [DBField("Is_Active")]
        public int IsActive { get; set; }


        public JobRefferals jobRefferals { get; set; }
    }
}
