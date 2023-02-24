using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class EmergencyContact
    {
        [DBField("ID")]
        public int DependantTypeId { get; set; }

        [DBField("EMPLOYEE_ID")]
        public int EmployeeId { get; set; }

        [DBField("CONTACT_PERSON_NME")]
        public string Name { get; set; }

        [DBField("DEPENDENT_TYPE_TO_EMPLOYEE")]
        public string DependentToEmployee { get; set; }

        [DBField("Address_OF_Emegency_Person")]
        public string EmgAddress { get; set; }

        [DBField("TELEPHONE")]
        public string EmgTelephone { get; set; }

        [DBField("MOBILE")]
        public string EmgMobile { get; set; }

        [DBField("OFFICE_PHONE")]
        public string OfficePhone { get; set; }

        //public Employee _Employee { get; set; } = new Employee();
    }
}
