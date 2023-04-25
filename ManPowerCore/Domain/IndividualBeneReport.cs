using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class IndividualBeneReport
    {
        [DBField("ID")]
        public int BenificiaryId { get; set; }

        [DBField("NIC")]
        public string BeneficiaryNic { get; set; }

        [DBField("NAME")]
        public string InduvidualBeneficiaryName { get; set; }

        [DBField("GENDER")]
        public string BeneficiaryGender { get; set; }

        [DBField("DATE_OF_BIRTH")]
        public DateTime DateOfBirth { get; set; }

        [DBField("PERSONAL_ADDRESS")]
        public string PersonalAddress { get; set; }

        [DBField("EMAIL")]
        public string BeneficiaryEmail { get; set; }

        [DBField("JOB_PREFERENCE")]
        public string JobPreference { get; set; }

        [DBField("CONTACT_NUMBER")]
        public string ContactNumber { get; set; }

        [DBField("WHATSAPP_NUMBER")]
        public string WhatsappNumber { get; set; }

        [DBField("IS_IN_SCHOOL")]
        public int IsSchoolStudent { get; set; }
        public string IsSchoolStudentStr { get; set; }

        [DBField("SCHOOL_NAME")]
        public string SchoolName { get; set; }

        [DBField("ADDRESS_OF_SCHOOL")]
        public string AddressOfSchool { get; set; }

        [DBField("GRADE")]
        public string SchoolGrade { get; set; }

        [DBField("PARENT_NIC")]
        public string ParentNic { get; set; }



        [DBField("Career_Key_Test_Id")]
        public int CareerKeyTestId { get; set; }

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
        public string ProvidedGuidance { get; set; }

        [DBField("Career_Key_Test_Held_Date")]
        public DateTime CareerKeyTestHeldDate { get; set; }

        [DBField("Career_Key_Test_Program_Plan")]
        public string CareerKeyTestProgramPlan { get; set; }


        [DBField("Training_Refferals_Id")]
        public int TrainingRefferalsId { get; set; }

        [DBField("Institute_Name")]
        public string InstituteName { get; set; }

        [DBField("Training_Course")]
        public string TrainingCourse { get; set; }

        [DBField("Contact_Person_Name")]
        public string ContactPerson { get; set; }

        [DBField("Training_Refferals_Date")]
        public DateTime TrainingRefferalsDate { get; set; }

        [DBField("Training_Refferals_Program_Plan")]
        public string TrainingRefferalsProgramPlan { get; set; }



        [DBField("Job_Refferals_Id")]
        public int JobRefferalsId { get; set; }

        [DBField("Company_Name")]
        public string CompanyName { get; set; }

        [DBField("Career_Path")]
        public string CareerPath { get; set; }

        [DBField("Job_Position")]
        public string JobPosition { get; set; }

        [DBField("Career_Guidance")]
        public string CareerGuidance { get; set; }

        [DBField("Remarks")]
        public string Remarks { get; set; }

        [DBField("Job_Refferals_Date")]
        public DateTime JobRefferalsDate { get; set; }

        [DBField("Job_Placement_Date")]
        public DateTime JobPlacementDate { get; set; }

        [DBField("Job_Refferals_Program_Plan")]
        public string JobRefferalsProgramPlan { get; set; }
    }
}
