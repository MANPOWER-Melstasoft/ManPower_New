using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class TransfersRetirementResignationMain
    {
        [DBField("Id")]
        public int MainId { get; set; }

        [DBField("Request_Type_Id")]
        public int RequestTypeId { get; set; }

        [DBField("Status_Id")]
        public int StatusId { get; set; }

        [DBField("Employee_ID")]
        public int EmployeeId { get; set; }

        [DBField("Created_Date")]
        public DateTime CreatedDate { get; set; }

        [DBField("Created_User")]
        public string CreatedUser { get; set; }

        [DBField("Documents")]
        public string Documents { get; set; }

        [DBField("Parent_Id")]
        public int ParentId { get; set; }

        [DBField("Recomend_Parent_Id")]
        public int RecomendParentId { get; set; }

        [DBField("Parent_Action")]
        public string ParentAction { get; set; }

        [DBField("Action_Taken_User_Id")]
        public int ActionTakenUserId { get; set; }

        [DBField("Action_Taken_Date")]
        public DateTime ActionTakenDate { get; set; }

        [DBField("Reason")]
        public string Reason { get; set; }

        [DBField("Remarks")]
        public string Remarks { get; set; }

        [DBField("Is_Active")]
        public int IsActive { get; set; }

        public RequestType requestType { get; set; }

        public TransfersRetirementResignationStatus status { get; set; }

        public Employee employee { get; set; }

        public SystemUser systemUser { get; set; }

        public SystemUser ActionTakenUser { get; set; }
    }
}
