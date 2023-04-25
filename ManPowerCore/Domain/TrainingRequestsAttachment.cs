using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class TrainingRequestsAttachment
    {
        [DBField("Id")]
        public int TrainingRequestAttachmentId { get; set; }

        [DBField("Attchment")]
        public string Attachment { get; set; }

        [DBField("Training_Request_Id")]
        public int TrainingRequestID { get; set; }
    }
}
