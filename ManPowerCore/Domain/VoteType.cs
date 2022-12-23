using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class VoteType
    {

        [DBField("ID")]
        public int Id { get; set; }

        [DBField("Details")]
        public string Deatils { get; set; }

        [DBField("Is_Active")]
        public int IsActive { get; set; }

    }
}
