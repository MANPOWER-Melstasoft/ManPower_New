﻿using ManPowerCore.Common;
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
        public string MobileNumber { get; set; }

        [DBField("TELEPHONE")]
        public string EmpTelephone { get; set; }

        [DBField("OFFICE_PHONE")]
        public string OfficePhone { get; set; }

        [DBField("POSTAL_CODE")]
        public string PostalCode { get; set; }

        [DBField("EMAIL")]
        public string EmpEmail { get; set; }

        //public Employee _Employee { get; set; } = new Employee();
    }
}
