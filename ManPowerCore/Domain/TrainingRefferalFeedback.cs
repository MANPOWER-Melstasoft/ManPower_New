using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class TrainingRefferalFeedback
    {
        [DBField("Id")]
        public int Id { get; set; }

        [DBField("TrainingRefferalId")]
        public int TrainingRefferalId { get; set; }

        [DBField("Date")]
        public DateTime Date { get; set; }

        [DBField("TrainingInstitute")]
        public string TrainingInstitute { get; set; }

        [DBField("InTraining")]
        public string InTraining { get; set; }

        [DBField("TrainingCompleted")]
        public string TrainingCompleted { get; set; }

        [DBField("Remarks")]
        public string Remarks { get; set; }

        public TrainingRefferals trainingRefferals { get; set; }
    }
}
