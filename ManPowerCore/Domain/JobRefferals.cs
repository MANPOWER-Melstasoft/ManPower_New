using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class JobRefferals
    {
        [DBField("ID")]
        public int JobRefferalsId { get; set; }

        [DBField("COMPANY_VACANCY_REGISTRATION_ID")]
        public int VacancyRegistrationId { get; set; }

        [DBField("BENEFICIARY_ID")]
        public int BeneficiaryId { get; set; }

        [DBField("JOB_CATEGORY_ID")]
        public int JobCategoryId { get; set; }

        [DBField("CREATED_DATE")]
        public DateTime CereatedDate { get; set; }

        [DBField("REMARKS")]
        public string RefferalRemarks { get; set; }

        [DBField("JOB_PLACEMENT_DATE")]
        public DateTime JobPlacementDate { get; set; }

        [DBField("CAREER_GUIDANCE")]
        public string CareerGuidance { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }

        [DBField("Job_Refferals_Date")]
        public DateTime RefferalsDate { get; set; }

        [DBField("Created_User")]
        public string CreatedUser { get; set; }

        public CompanyVecansyRegistationDetails companyVecansyRegistationDetails { get; set; }

        public Beneficiary beneficiary { get; set; }
    }
}
