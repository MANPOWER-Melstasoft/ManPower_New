using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class FuelDetails
    {
        public string VehicleNumber { get; set; }


        public int FuelTypeId { get; set; }


        public string LitersCount { get; set; }

        public DateTime CreatedDate { get; set; }

        public string OrderNumber { get; set; }



    }
}
