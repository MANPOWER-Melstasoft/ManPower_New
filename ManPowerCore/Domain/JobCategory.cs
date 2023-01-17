using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class JobCategory
    {
        [DBField("ID")]
        public int JobCategoryId { get; set; }

        [DBField("TITLE")]
        public string Title { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }
    }
}
