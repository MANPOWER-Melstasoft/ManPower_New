using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class VehicleMeintenance
    {
        [DBField("ID")]
        public int VehicleMeintenanceId { get; set; }

        [DBField("Employee_ID")]
        public int EmpId { get; set; }

        [DBField("Date")]
        public DateTime RequestDate { get; set; }

        [DBField("Vehicle_Number")]
        public string VehicleNumber { get; set; }

        [DBField("Description")]
        public string RequestDescription { get; set; }

        [DBField("Is_Approved")]
        public int IsApproved { get; set; }

        [DBField("Recomand_By")]
        public int RecomandBy { get; set; }

        [DBField("Recomand_Date")]
        public DateTime RecomandDate { get; set; }

        [DBField("Approved_By")]
        public int ApprovedBy { get; set; }

        [DBField("Approved_date")]
        public DateTime ApprovedDate { get; set; }

        [DBField("Estimated_Cost")]
        public float EstimatedCost { get; set; }

        [DBField("Attachment")]
        public string Attachment { get; set; }

        [DBField("Maintenance_Category_Id")]
        public int CategoryId { get; set; }

        [DBField("Requested_By")]
        public int RequestedBy { get; set; }

        [DBField("File_No")]
        public string FileNo { get; set; }

        [DBField("Rejected_Reason")]
        public string RejectedReason { get; set; }

        [DBField("Vehicle_Meter")]
        public string VehicleMeter { get; set; }

        [DBField("Vehicle_Previous_Meter")]
        public string VehiclePrevMeter { get; set; }

        [DBField("Mileage")]
        public string Mileage { get; set; }

        public Employee Employee { get; set; }

        public SystemUser RequestBy { get; set; }

        public SystemUser RecommendBy { get; set; }

        public SystemUser ApproveBy { get; set; }
    }
}
