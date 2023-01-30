using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]

    public class ApproveAction
    {

        [DBField("Id")]
        public int Id { get; set; }

        [DBField("Approve_Action_Name")]
        public string ApproveActionName { get; set; }

        [DBField("Is_Active")]
        public string Is_Active { get; set; }
    }
}
