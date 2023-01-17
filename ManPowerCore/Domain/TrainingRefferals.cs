using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class TrainingRefferals
    {
        [DBField("Id")]
        public int Id { get; set; }

        [DBField("BeneficiaryId")]
        public int BeneficiaryId { get; set; }

        [DBField("Date")]
        public DateTime Date { get; set; }

        [DBField("Instutename")]
        public string InstituteName { get; set; }

        [DBField("TrainingCourse")]
        public string TrainingCourse { get; set; }

        [DBField("ContactPerson")]
        public string ContactPerson { get; set; }

        [DBField("ContactNo")]
        public string ContactNo { get; set; }

        [DBField("Is_Active")]
        public string IsActive { get; set; }

        public Beneficiary beneficiary { get; set; }
    }

}
