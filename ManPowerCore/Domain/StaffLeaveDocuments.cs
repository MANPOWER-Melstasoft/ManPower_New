using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class StaffLeaveDocuments
    {
        [DBField("ID")]
        public int Id { get; set; }

        [DBField("Employee_ID")]
        public int StaffLeaveId { get; set; }

        [DBField("Vehicle_Number")]
        public string Document { get; set; }
    }
}
