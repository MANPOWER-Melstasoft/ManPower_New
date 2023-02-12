using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class Report
    {
        public string LeaveType { get; set; }

        public String Entitlement { get; set; }

        public double ApprovedLeaves { get; set; }

        public double PendingApproval { get; set; }

        public double LeaveBalannce { get; set; }

        public double NoOfDays { get; set; }
        public int EmployeeId { get; set; }



    }
}
