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
        List<TrainingRequests> trainingRequestsList = new List<TrainingRequests>();
        TrainingRequests trainingRequestObj = new TrainingRequests();
        static int depPositionID;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            depPositionID = Convert.ToInt32(Session["DepUnitPositionId"]);
            BindDataSource();
        }
        public void BindDataSource()
        {
            TrainingRequestsController trainingRequestsController = ControllerFactory.CreateTrainingRequestsController();
            trainingRequestsList = trainingRequestsController.GetAllTrainingRequestsWithDetail();

            trainingRequestsList = trainingRequestsList.Where(x => x.Is_Active == 1 && x.ProjectStatusId == 2 && x.Trainingmain.Start_Date > DateTime.Now).ToList();

            gvApproveTraining.DataSource = trainingRequestsList;
            gvApproveTraining.DataBind();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            TrainingRequestsController trainingRequestsController = ControllerFactory.CreateTrainingRequestsController();

            trainingRequestObj = trainingRequestsList[rowIndex];

            trainingRequestObj.Accepted_User = depPositionID;
            trainingRequestObj.Accepted_Date = DateTime.Now;
            trainingRequestObj.ProjectStatusId = 1008;

            int result = trainingRequestsController.Update(trainingRequestObj);
            if (result == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Approved..!', 'success');window.setTimeout(function(){window.location='approvetrainingrequest.aspx'},1500);", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);

            }

        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            TrainingRequestsController trainingRequestsController = ControllerFactory.CreateTrainingRequestsController();

            trainingRequestObj = trainingRequestsList[rowIndex];

            trainingRequestObj.Accepted_User = depPositionID;
            trainingRequestObj.Accepted_Date = DateTime.Now;
            trainingRequestObj.ProjectStatusId = 7;

            int result = trainingRequestsController.Update(trainingRequestObj);
            if (result == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Rejected..!', 'success');window.setTimeout(function(){window.location='approvetrainingrequest.aspx'},1500);", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);

            }
        }
    }
}