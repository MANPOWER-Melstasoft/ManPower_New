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
        List<TrainingRequests> trainingRequestsList = new List<TrainingRequests>();
        public int depId;
        protected void Page_Load(object sender, EventArgs e)
        {
            depId = Convert.ToInt32(Session["DepUnitPositionId"]);
            BindDataSource();
        }

        public void BindDataSource()
        {
            TrainingRequestsController trainingRequestsController = ControllerFactory.CreateTrainingRequestsController();
            trainingRequestsList = trainingRequestsController.GetAllTrainingRequestsWithDetail();

            trainingRequestsList = trainingRequestsList.Where(x => x.Created_User == depId && x.Is_Active == 1 && x.ProjectStatusId == 1008 && x.Trainingmain.Start_Date > DateTime.Now).ToList();

            gvApproveTraining.DataSource = trainingRequestsList;
            gvApproveTraining.DataBind();
        }
    }
}