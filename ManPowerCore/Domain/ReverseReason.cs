using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]

    public class ReverseReason
    {
        [DBField("Id")]
        public int Id { get; set; }

        [DBField("Reverse_Reason_Name")]
        public string ReverseReasonName { get; set; }

        [DBField("Is_Active")]
        public string Is_Active { get; set; }
    }
}
