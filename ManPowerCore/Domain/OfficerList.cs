using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class OfficerList
    {
        public int SystemUserId { get; set; }

        public string Name { get; set; }

        public int ParentId { get; set; }
        public int PossitionId { get; set; }

        public int DepartmentUnitId { get; set; }

        public int UserTypeId { get; set; }
    }
}
