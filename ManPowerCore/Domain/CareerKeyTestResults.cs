using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class CareerKeyTestResults
    {
        [DBField("Id")]
        public int Id { get; set; }

        [DBField("Beneficiary_Id")]
        public int BeneficiaryId { get; set; }

        [DBField("Created_Date")]
        public DateTime Date { get; set; }

        [DBField("R")]
        public int R { get; set; }

        [DBField("I")]
        public int I { get; set; }

        [DBField("A")]
        public int A { get; set; }

        [DBField("S")]
        public int S { get; set; }

        [DBField("E")]
        public int E { get; set; }

        [DBField("C")]
        public int C { get; set; }

        [DBField("Provided_Guidance")]
        public string Guidence { get; set; }

        [DBField("Is_Active")]
        public string IsActive { get; set; }

        public Beneficiary beneficiary { get; set; }
    }
}
