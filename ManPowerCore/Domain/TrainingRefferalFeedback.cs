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

        [DBField("Training_Refferals_Id")]
        public int TrainingRefferalId { get; set; }

        [DBField("Created_Date")]
        public DateTime Date { get; set; }

        [DBField("Training_Institute")]
        public string TrainingInstitute { get; set; }

        [DBField("In_Training")]
        public string InTraining { get; set; }

        [DBField("Training_Completed")]
        public string TrainingCompleted { get; set; }

        [DBField("Other_Remarks")]
        public string Remarks { get; set; }

        [DBField("Is_Active")]
        public int IsActive { get; set; }

        [DBField("Created_User")]
        public string CreatedUser { get; set; }

        public TrainingRefferals trainingRefferals { get; set; }
    }
}
