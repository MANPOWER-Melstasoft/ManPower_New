using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class Supplier
    {
        [DBField("Id")]
        public int Id { get; set; }

        [DBField("Supplier_Type_Id")]
        public int SupplierTypeId { get; set; }

        [DBField("Name")]
        public string Name { get; set; }

        [DBField("Address")]
        public string Address { get; set; }

        [DBField("Vat_Reg_Number")]
        public string VatRegNumber { get; set; }

        [DBField("Created_Date")]
        public DateTime CreatedDate { get; set; }

        [DBField("Created_User")]
        public string CreatedUser { get; set; }

        [DBField("Status_Id")]
        public int StatusId { get; set; }
    }
}
