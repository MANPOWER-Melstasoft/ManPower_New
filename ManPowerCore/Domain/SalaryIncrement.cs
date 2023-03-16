using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class SalaryIncrement
    {

        [DBField("Id")]
        public int Id { get; set; }

        [DBField("Employee_ID")]
        public int EmployeeId { get; set; }

        [DBField("Salary_Increment_Status_Id")]
        public int SalaryIncrementStatusId { get; set; }

        [DBField("Created_User")]
        public string CreatedUser { get; set; }

        [DBField("Created_Date")]
        public DateTime CreatedDate { get; set; }

        [DBField("Basic_Salary")]
        public float BasicSalary { get; set; }

        [DBField("Allowances")]
        public float Allowances { get; set; }

        [DBField("Total_Salary")]
        public float TotalSalary { get; set; }

        public Employee Employee { get; set; }

        public SalaryIncrementStatus SalaryIncrementStatus { get; set; }
    }
}
