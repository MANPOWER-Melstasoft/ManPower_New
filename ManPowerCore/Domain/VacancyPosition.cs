using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class VacancyPosition
    {
        [DBField("Id")]
        public int Id { get; set; }
        [DBField("Position_Name")]
        public string VacancyPositionName { get; set; }

        [DBField("Position_Category")]
        public string VacancyCategory { get; set; }

        [DBField("Is_Active")]
        public int IsActive { get; set; }

    }
}
