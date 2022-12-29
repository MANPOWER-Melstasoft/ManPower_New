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
    public partial class ApprovedTraining : System.Web.UI.Page
    {
        List<Training_Request> trainingRequestList = new List<Training_Request>();
        public int depId;
        protected void Page_Load(object sender, EventArgs e)
        {
            depId = Convert.ToInt32(Session["DepUnitPositionId"]);
            BindDataSource();
        }

        public void BindDataSource()
        {
            TrainingRequestController trainingRequestController = ControllerFactory.CreateTrainingRequestController();
            trainingRequestList = trainingRequestController.GetAllApprovedTrainingRequest(depId);

            gvApproveTraining.DataSource = trainingRequestList;
            gvApproveTraining.DataBind();
        }
    }
}