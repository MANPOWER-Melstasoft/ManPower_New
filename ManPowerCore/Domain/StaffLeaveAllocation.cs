using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class StaffLeaveAllocation
    {
        [DBField("id")]
        public int StaffLeaveAllocationId { get; set; }
        [DBField("Employee_ID")]
        public int EmployeesID { get; set; }

        [DBField("Leave_Year")]
        public int LeaveYear { get; set; }
        [DBField("Leave_Type_id")]

        public int LeaveTypeId { get; set; }
        [DBField("No_Of_Days")]
        public int NoOfDays { get; set; }
        [DBField("Entitlement")]

        public string Entitlement { get; set; }
        [DBField("Month_Limit")]



        public int MonthLimit { get; set; }
        [DBField("Month_Limit_Applied_To")]

        public DateTime MonthLimitAppliedTo { get; set; }

        public List<LeaveType> _leaveTypes { get; set; } = new List<LeaveType>();


    }
}
