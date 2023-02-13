using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class SupplierType
    {
        [DBField("Id")]
        public int Id { get; set; }

        [DBField("Supply_Type_Name")]
        public string SupplyTypeName { get; set; }

        [DBField("Is_Active")]
        public int IsActive { get; set; }
    }
}
