using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]

    public class Training_Request
    {
        [DBField("ID")]
        public int TrainingRequestId { get; set; }

        [DBField("EMPLOYEE_ID")]
        public int Employee_Id { get; set; }

        [DBField("PROGRAM_DATE")]
        public DateTime? ProgramDate { get; set; }

        [DBField("PROGRAM_ID")]
        public int ProgramId { get; set; }

        [DBField("REQUESTED_DATE")]
        public DateTime? RequestedDate { get; set; }

        [DBField("Requested_user_id")]
        public int RequestedUserID { get; set; }

        [DBField("APPROVED_BY")]
        public string ApprovedBy { get; set; }

        [DBField("APPROVED_DATE")]
        public DateTime? ApprovedDate { get; set; }

        [DBField("Status_ID")]
        public int StatusID { get; set; }

        [DBField("Training_Category")]
        public string TrainingCategory { get; set; }

        [DBField("Institute")]
        public string Institute { get; set; }

        [DBField("Content_type")]
        public string Content { get; set; }

        [DBField("Doc_Upload")]
        public string DocUpload { get; set; }
    }
}