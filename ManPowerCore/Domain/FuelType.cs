using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class FuelType
    {
        [DBField("Fuel_Type_Id")]
        public int FuelTypeId { get; set; }

        [DBField("Fuel_Name")]
        public string FuelTypeName { get; set; }
    }


}
