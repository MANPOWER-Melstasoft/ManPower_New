using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class VoteLedger
    {
        [DBField("ID")]
        public int Id { get; set; }

        [DBField("From_Vote")]
        public int FromVote { get; set; }

        [DBField("To_Vote")]
        public int ToVote { get; set; }

        [DBField("Amount")]
        public float Amount { get; set; }

        [DBField("Created_By")]
        public int CreatedBy { get; set; }

        [DBField("Created_Date")]
        public DateTime CreatedDate { get; set; }

        [DBField("Approved_By")]
        public int ApprovedBy { get; set; }

        [DBField("Approved_Date")]
        public DateTime ApprovedDate { get; set; }

        [DBField("Is_Active")]
        public int IsActive { get; set; }

        public VoteAllocation fromVoteAllocation { get; set; }
        public VoteAllocation toVoteAllocation { get; set; }

        public SystemUser createdUser { get; set; }
        public SystemUser ApprovedUser { get; set; }

    }
}
