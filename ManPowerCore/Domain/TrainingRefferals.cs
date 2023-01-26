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

        [DBField("Beneficiary_Id")]
        public int BeneficiaryId { get; set; }

        [DBField("Created_Date")]
        public DateTime Date { get; set; }

        [DBField("Institute_Name")]
        public string InstituteName { get; set; }

        [DBField("Training_Course")]
        public string TrainingCourse { get; set; }

        [DBField("Contact_Person_Name")]
        public string ContactPerson { get; set; }

        [DBField("Contact_No")]
        public string ContactNo { get; set; }

        [DBField("Is_Active")]
        public int IsActive { get; set; }

        [DBField("Refferals_Date")]
        public DateTime RefferalsDate { get; set; }

        [DBField("Created_User")]
        public string CreatedUser { get; set; }

        public Beneficiary beneficiary { get; set; }
    }

}
