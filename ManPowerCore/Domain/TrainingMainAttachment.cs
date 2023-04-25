using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class TrainingMainAttachment
    {

        [DBField("Id")]
        public int TrainingMainAttachmentId { get; set; }

        [DBField("Attchment")]
        public string Attachment { get; set; }

        [DBField("Training_Main_Id")]
        public int TrainingMainId { get; set; }
    }
}
