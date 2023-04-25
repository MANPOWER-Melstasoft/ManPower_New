using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]

    public class LeaveType
    {
        [DBField("ID")]
        public int LeaveTypeId { get; set; }

        [DBField("NAME")]
        public string Name { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }
    }
}
