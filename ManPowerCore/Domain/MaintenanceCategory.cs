using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class MaintenanceCategory
    {
        [DBField("ID")]
        public int MaintenanceCategoryId { get; set; }

        [DBField("NAME")]
        public string MaintenanceCategoryName { get; set; }
    }
}
