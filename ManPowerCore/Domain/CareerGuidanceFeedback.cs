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

        [DBField("CareerKeyTestResultsId")]
        public int CareerKeyTestResultsId { get; set; }

        [DBField("Date")]
        public DateTime Date { get; set; }

        [DBField("InJob")]
        public string InJob { get; set; }

        [DBField("InTraining")]
        public string InTraining { get; set; }

        [DBField("Remarks")]
        public string Remarks { get; set; }

        public CareerKeyTestResults careerKeyTestResults { get; set; }
    }
}
