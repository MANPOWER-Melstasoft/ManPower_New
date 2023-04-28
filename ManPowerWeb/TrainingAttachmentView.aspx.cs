using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class TrainingAttachmentView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            int trainingRequestId = Convert.ToInt32(Request.QueryString["TrainingRequestId"]);

            TrainingRequestsAttachmentController trainingRequestsAttachmentController = ControllerFactory.CreateTrainingRequestsAttachmentController();
            List<TrainingRequestsAttachment> trainingRequestsAttachmentList = trainingRequestsAttachmentController.GetAllTrainingRequestsAttachments();

            trainingRequestsAttachmentList = trainingRequestsAttachmentList.Where(x => x.TrainingRequestID == trainingRequestId).ToList();

            gvAttachments.DataSource = trainingRequestsAttachmentList;
            gvAttachments.DataBind();

        }
    }
}