using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]

    public class TransferType
    {
        [DBField("Id")]
        public int Id { get; set; }

        [DBField("Transfer_Type_Name")]
        public string TransferTypeName { get; set; }

        [DBField("Is_Active")]
        public string Is_Active { get; set; }
    }
}
