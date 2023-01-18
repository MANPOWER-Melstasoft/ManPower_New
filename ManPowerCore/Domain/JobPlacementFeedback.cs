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

        [DBField("DATE")]
        public DateTime AssignedDate { get; set; }

        [DBField("STILL_WORKING")]
        public int StillWorking { get; set; }

        [DBField("RESIGNED_DATE")]
        public DateTime ResignedDate { get; set; }

        [DBField("REMARKS")]
        public string Remarks { get; set; }

        [DBField("Created_User")]
        public string CreatedUser { get; set; }

        public JobRefferals jobRefferals { get; set; }
    }
}
