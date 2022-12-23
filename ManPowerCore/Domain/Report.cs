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

        public int ApprovedLeaves { get; set; }

        public int PendingApproval { get; set; }

        public int LeaveBalannce { get; set; }

        public int NoOfDays { get; set; }



    }
}
