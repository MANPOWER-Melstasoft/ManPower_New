using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class FuelDetailsDomain
    {
        [DBField("Vehicle_Number")]
        public string VehicleNumber { get; set; }

        [DBField("Fuel_Type_Id")]
        public int FuelTypeId { get; set; }

        [DBField("Liters")]
        public string LitersCount { get; set; }

        [DBField("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [DBField("OrderNumber")]
        public string OrderNumber { get; set; }



    }




}
