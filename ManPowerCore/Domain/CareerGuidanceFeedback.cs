using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class CareerGuidanceFeedback
    {
        [DBField("Id")]
        public int Id { get; set; }

        [DBField("Career_Key_Test_Results_Id")]
        public int CareerKeyTestResultsId { get; set; }

        [DBField("Created_Date")]
        public DateTime Date { get; set; }

        [DBField("In_Job")]
        public string InJob { get; set; }

        [DBField("In_Training")]
        public string InTraining { get; set; }

        [DBField("Other_Remarks")]
        public string Remarks { get; set; }

        [DBField("Is_Active")]
        public string IsActive { get; set; }

        [DBField("Created_User")]
        public string CreatedUser { get; set; }

        public CareerKeyTestResults careerKeyTestResults { get; set; }
    }
}
