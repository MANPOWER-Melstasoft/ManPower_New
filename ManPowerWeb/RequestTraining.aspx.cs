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
    public partial class RequestTraining : System.Web.UI.Page
    {
        List<Training_Request> trainingRequestList = new List<Training_Request>();

        public int trainingRequestId;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataSource();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string url = "addtrainingrequest.aspx?" + "TrainingRequestId=" + 0;
            Response.Redirect(url);
        }

        public void BindDataSource()
        {
            TrainingRequestController trainingRequestController = ControllerFactory.CreateTrainingRequestController();
            trainingRequestList = trainingRequestController.GetAllPendingTrainingRequest();

            gvRequestTraining.DataSource = trainingRequestList;
            gvRequestTraining.DataBind();
        }

        protected void btnAction_Click(object sender, EventArgs e)
        {

            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            trainingRequestId = trainingRequestList[rowIndex].TrainingRequestId;

            string url = "addtrainingrequest.aspx?" + "TrainingRequestId=" + trainingRequestId;
            Response.Redirect(url);
        }
    }
}