using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class ContractType
    {
        [DBField("ID")]
        public int ContractTypeId { get; set; }

        [DBField("NAME")]
        public string ContractTypeName { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }
    }
}
