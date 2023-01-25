using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class RetirementType
    {
        [DBField("Id")]
        public int Id { get; set; }

        [DBField("Name")]
        public string RetirementTypeName { get; set; }

        [DBField("Is_Active")]
        public string Is_Active { get; set; }
    }
}
