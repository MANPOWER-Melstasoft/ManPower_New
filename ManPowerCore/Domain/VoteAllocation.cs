using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class VoteAllocation
    {
        [DBField("ID")]
        public int Id { get; set; }

        [DBField("Vote_Type_ID")]
        public int VoteTypeId { get; set; }

        [DBField("Year_Allocation")]
        public DateTime Year { get; set; }

        [DBField("Vote_Number")]
        public string VoteNumber { get; set; }

        [DBField("Amount")]
        public float Amount { get; set; }

        [DBField("Reamin_Amount")]
        public float RemainAmount { get; set; }

        [DBField("Created_By")]
        public int CreatedBy { get; set; }

        [DBField("Created_Date")]
        public DateTime CreatedDate { get; set; }

        [DBField("Is_Active")]
        public int IsActive { get; set; }


        public VoteType voteType { get; set; }

        public SystemUser createdUser { get; set; }
    }
}
