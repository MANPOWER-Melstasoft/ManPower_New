using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class TrainingRequests
    {
        [DBField("Id")]
        public int TrainingRequestsId { get; set; }

        [DBField("Training_main_id")]
        public int TrainingMainId { get; set; }

        [DBField("Project_status_id")]
        public int ProjectStatusId { get; set; }

        [DBField("Created_date")]
        public DateTime Created_Date { get; set; }

        [DBField("Created_user")]
        public int Created_User { get; set; }

        [DBField("Accepted_date")]
        public DateTime Accepted_Date { get; set; }

        [DBField("Accepted_user")]
        public int Accepted_User { get; set; }

        [DBField("Is_Active")]
        public int Is_Active { get; set; }

        public ProjectStatus ProjectStatus { get; set; }

        public TrainingMain Trainingmain { get; set; }

        public SystemUser SystemUser { get; set; }
    }
}
