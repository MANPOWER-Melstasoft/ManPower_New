using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class HolidaySheet
    {
        [DBField("Id")]
        public int Id { get; set; }

        [DBField("Date")]
        public DateTime HolidayDate { get; set; }


        [DBField("Description")]
        public string Description { get; set; }

        [DBField("Is_Active")]
        public int IsActive { get; set; }
    }
}
