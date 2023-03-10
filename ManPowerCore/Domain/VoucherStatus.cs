using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class VoucherStatus
    {
        [DBField("Id")]
        public int VoucherStatusId { get; set; }

        [DBField("Status_Name")]
        public string StatusName { get; set; }
    }
}
