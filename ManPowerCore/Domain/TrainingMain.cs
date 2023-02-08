using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class TrainingMain
    {
        [DBField("Id")]
        public int TrainingMainId { get; set; }

        [DBField("Title")]
        public string Title { get; set; }

        [DBField("Content")]
        public string Content { get; set; }

        [DBField("Created_date")]
        public DateTime Created_Date { get; set; }

        [DBField("Created_user")]
        public int Created_User { get; set; }

        [DBField("Member_Count")]
        public int Member_Count { get; set; }

        [DBField("Open_date")]
        public DateTime Start_Date { get; set; }

        [DBField("End_date")]
        public DateTime End_date { get; set; }

        [DBField("Post_img")]
        public string Post_img { get; set; }

        [DBField("Is_Active")]
        public int Is_Active { get; set; }
    }
}
