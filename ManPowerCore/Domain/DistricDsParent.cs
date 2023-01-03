using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class DistricDsParent
    {
        [DBField("Id")]
        public int Id { get; set; }

        [DBField("Parent_User_Id")]
        public int ParentUserId { get; set; }

        [DBField("Department_Id")]
        public int DepartmentId { get; set; }

        public SystemUser systemUser { get; set; }
        public DepartmentUnit departmentUnit { get; set; }

    }
}
