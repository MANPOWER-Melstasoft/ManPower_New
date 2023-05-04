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

        [DBField("Staff_Leave_Id")]
        public int StaffLeaveId { get; set; }

        [DBField("Document")]
        public string Document { get; set; }
    }
}
