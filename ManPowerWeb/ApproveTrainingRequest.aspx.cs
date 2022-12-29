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
    public partial class ApproveTrainingRequest : System.Web.UI.Page
    {
        List<Training_Request> trainingRequestList = new List<Training_Request>();

        Training_Request trainingRequestObj = new Training_Request();

        public int depPositionID;
        protected void Page_Load(object sender, EventArgs e)
        {
            depPositionID = Convert.ToInt32(Session["DepUnitPositionId"]);
            BindDataSource();
        }
        public void BindDataSource()
        {
            TrainingRequestController trainingRequestController = ControllerFactory.CreateTrainingRequestController();
            trainingRequestList = trainingRequestController.GetOnlyPendingTrainingRequest(depPositionID);

            gvApproveTraining.DataSource = trainingRequestList;
            gvApproveTraining.DataBind();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            TrainingRequestController trainingRequestController = ControllerFactory.CreateTrainingRequestController();

            trainingRequestObj = trainingRequestList[rowIndex];

            trainingRequestObj.TrainingRequestId = trainingRequestList[rowIndex].TrainingRequestId;
            trainingRequestObj.StatusID = 1008;

            trainingRequestController.UpdateTrainingRequest(trainingRequestObj);

            string url = "approvetrainingrequest.aspx";
            Response.Redirect(url);
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            TrainingRequestController trainingRequestController = ControllerFactory.CreateTrainingRequestController();

            trainingRequestObj = trainingRequestList[rowIndex];

            trainingRequestObj.TrainingRequestId = trainingRequestList[rowIndex].TrainingRequestId;
            trainingRequestObj.StatusID = 7;

            trainingRequestController.UpdateTrainingRequest(trainingRequestObj);

            string url = "approvetrainingrequest.aspx";
            Response.Redirect(url);
        }
    }
}