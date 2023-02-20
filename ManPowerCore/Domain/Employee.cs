using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class Employee
    {
        [DBField("ID")]
        public int EmployeeId { get; set; }

        [DBField("RELIGION_ID")]
        public int ReligionId { get; set; }

        [DBField("ETHNICITY_ID")]
        public int EthnicityId { get; set; }

        [DBField("NIC")]
        public string EmployeeNIC { get; set; }

        [DBField("NIC_ISSUE_DATE")]
        public DateTime NicIssueDate { get; set; }

        [DBField("PASSPORT_NUMBER")]
        public string EmployeePassportNumber { get; set; }

        [DBField("TITLE")]
        public string Title { get; set; }

        [DBField("INITIAL")]
        public string EmpInitials { get; set; }

        [DBField("LAST_NAME")]
        public string LastName { get; set; }

        [DBField("NAME_DENOTE_BY_INITIAL")]
        public string NameWithInitials { get; set; }

        [DBField("GENDER")]
        public string EmpGender { get; set; }

        [DBField("DATE_OF_BIRTH")]
        public DateTime DOB { get; set; }

        [DBField("MARITAL_STATUS")]
        public string MaritalStatus { get; set; }

        [DBField("PENSION_DATE")]
        public DateTime PensionDate { get; set; }

        [DBField("VNOP_NO")]
        public int VNOPNo { get; set; }

        [DBField("APPOINTMENT_NO")]
        public int AppointmentNo { get; set; }

        [DBField("FILE_NO")]
        public int FileNo { get; set; }

        [DBField("EMP_NO")]
        public int EmpNo { get; set; }

        [DBField("ABSORB")]
        public string EpmAbsorb { get; set; }

        [DBField("SUPERVISOR_ID")]
        public int SupervisorId { get; set; }

        [DBField("MANAGER_ID")]
        public int ManagerId { get; set; }

        [DBField("DSDIVISION_ID")]
        public int DSDivisionId { get; set; }

        [DBField("DISTRICT_ID")]
        public int DistrictId { get; set; }

        [DBField("UNIT_TYPE")]
        public int UnitType { get; set; }


        [DBField("Designation_Id")]
        public int DesignationId { get; set; }

        [DBField("Salary_Num")]
        public string SalaryNo { get; set; }


        [DBField("ED_Completion_Date")]
        public DateTime EDCompletionDate { get; set; }


        public string fullName { get; set; }


        public Designation designation { get; set; }

        public EmergencyContact _EmergencyContact { get; set; } = new EmergencyContact();
        public EmployeeContact _EmployeeContact { get; set; } = new EmployeeContact();
        public List<Dependant> _Dependant { get; set; } = new List<Dependant>();
        public List<EmploymentDetails> _EmploymentDetails { get; set; } = new List<EmploymentDetails>();

        public EmploymentDetails _EmploymentDetailsSingle { get; set; } = new EmploymentDetails();
        public List<EducationDetails> _EducationDetails { get; set; } = new List<EducationDetails>();
        public List<EmployeeServices> _EmployeeServices { get; set; } = new List<EmployeeServices>();
    }
}
