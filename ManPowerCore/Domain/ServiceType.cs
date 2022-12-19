using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class ServiceType
    {
        [DBField("ID")]
        public int ServiceTypeId { get; set; }

        [DBField("NAME")]
        public string ServiceTypeName { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }
    }
}
