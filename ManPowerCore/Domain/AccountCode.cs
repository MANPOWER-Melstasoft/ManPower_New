using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class AccountCode
    {
        [DBField("Id")]
        public int Id { get; set; }

        [DBField("Description")]
        public string Description { get; set; }

        [DBField("Ledger_Code")]
        public int LedgerCode { get; set; }

        [DBField("Is_Active")]
        public int IsActive { get; set; }
    }
}
