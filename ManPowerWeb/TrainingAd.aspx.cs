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
    public partial class TrainingAd : System.Web.UI.Page
    {
        public int trainingMainId;
        public int depId;
        public int ParenId;

        public List<TrainingMain> trainingMainList = new List<TrainingMain>();

        public List<TrainingRequests> trainingRequestsList = new List<TrainingRequests>();

        public TrainingRequests trainingRequests = new TrainingRequests();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            trainingMainId = Convert.ToInt32(Request.QueryString["TrainingMainId"]);
            depId = Convert.ToInt32(Session["DepUnitPositionId"]);
            ParenId = Convert.ToInt32(Session["DepUnitParentId"]);

            BindDataSource();

            ButtonEnable();
        }

        public void BindDataSource()
        {
            TrainingMainController trainingMainController = ControllerFactory.CreateTrainingMainController();

            trainingMainList = trainingMainController.GetAllTrainingMain();

            trainingMainList = trainingMainList.Where(x => x.TrainingMainId == trainingMainId).ToList();

            foreach (var item in trainingMainList)
            {
                item.Post_img = "~/SystemDocuments/TrainingImages/" + item.Post_img;
                int depID = Convert.ToInt32(Session["DepUnitPositionId"]);
                if (item.Created_User == Convert.ToInt32(Session["DepUnitPositionId"]))
                {
                    btnApply.Visible = false;
                    btnReject.Visible = false;
                }
            }

            lvTrainingAd.DataSource = trainingMainList;
            lvTrainingAd.DataBind();

        }

        public void ButtonEnable()
        {
            TrainingRequestsController trainingRequestsController = ControllerFactory.CreateTrainingRequestsController();

            List<TrainingRequests> trainingRequestsList1 = new List<TrainingRequests>();

            trainingRequestsList1 = trainingRequestsController.GetAllTrainingRequestsBiMainId(trainingMainId);

            int flag = 0;

            foreach (var item in trainingRequestsList1)
            {
                if (item.Created_User == depId && item.Is_Active == 1)
                {
                    flag = 1;
                }
            }

            if (flag == 1)
            {
                btnApply.Enabled = false;
                btnApply.CssClass = "btn btn-outline-secondary disabled";
                btnApply.Text = "Applied";
                btnReject.Enabled = true;
                btnReject.CssClass = "btn btn-outline-danger";
            }
            else
            {
                btnApply.Enabled = true;
                btnApply.CssClass = "btn btn-outline-success";
                btnApply.Text = "Apply";
                btnReject.Enabled = false;
                btnReject.CssClass = "btn btn-outline-secondary disabled";
            }
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            int output;
            TrainingRequestsController trainingRequestsController = ControllerFactory.CreateTrainingRequestsController();

            trainingRequests.TrainingMainId = trainingMainId;
            trainingRequests.ProjectStatusId = 1;
            trainingRequests.Created_User = depId;
            trainingRequests.Created_Date = DateTime.Now;


            output = trainingRequestsController.Save(trainingRequests);

            //string url = "TrainingAd.aspx?TrainingMainId=" + trainingMainId;

            if (output == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Applied Succesfully!', 'success');window.setTimeout(function(){window.location='trainingfront.aspx'},2000);", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);
            }
            //Response.Redirect(url);
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            int output;
            TrainingRequestsController trainingRequestsController = ControllerFactory.CreateTrainingRequestsController();

            List<TrainingRequests> trainingRequestsList1 = new List<TrainingRequests>();

            TrainingRequests trainingRequests1 = new TrainingRequests();

            trainingRequestsList1 = trainingRequestsController.GetAllTrainingRequestsBiMainId(trainingMainId);

            trainingRequests1 = trainingRequestsList1.Where(x => x.Created_User == depId && x.Is_Active == 1).Single();

            output = trainingRequestsController.Delete(trainingRequests1);

            if (output == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Cancelled Succesfully!', 'success');window.setTimeout(function(){window.location='trainingfront.aspx'},2000);", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);
            }
            //string url = "TrainingAd.aspx?TrainingMainId=" + trainingMainId;
            //Response.Redirect(url);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrainingFront.aspx");
        }
    }
}