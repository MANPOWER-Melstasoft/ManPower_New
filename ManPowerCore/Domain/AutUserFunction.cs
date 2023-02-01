using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]

    public class AutUserFunction
    {
        [DBField("AUT_FUNCTION_ID")]
        public int AutFunctionId { get; set; }

        [DBField("AUT_USER_ID")]
        public int AutUserId { get; set; }

        public AutFunction autFunction { get; set; }

        public SystemUser systemUser { get; set; }
    }
}
