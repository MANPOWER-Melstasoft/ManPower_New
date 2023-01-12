using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class EmployeeContact
    {
        [DBField("ID")]
        public int EmployeeContactId { get; set; }

        [DBField("EMPLOYEE_ID")]
        public int EmpID { get; set; }

        [DBField("ADDRESS")]
        public string EmpAddress { get; set; }

        [DBField("MOBILE_NUMBER")]
        public int MobileNumber { get; set; }

        [DBField("TELEPHONE")]
        public int EmpTelephone { get; set; }

        [DBField("OFFICE_PHONE")]
        public int OfficePhone { get; set; }

        [DBField("POSTAL_CODE")]
        public int PostalCode { get; set; }

        [DBField("EMAIL")]
        public string EmpEmail { get; set; }

        //public Employee _Employee { get; set; } = new Employee();
    }
}
