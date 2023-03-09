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
    public partial class AddTrainingFront1 : System.Web.UI.Page
    {
        public List<TrainingMain> trainningMainList = new List<TrainingMain>();

        TrainingMainController trainingMainController = ControllerFactory.CreateTrainingMainController();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            BindDataSource();
        }

        public void BindDataSource()
        {

            trainningMainList = trainingMainController.GetAllTrainingMain();

            trainningMainList = trainningMainList.Where(x => x.Is_Active == 1 && x.Start_Date > DateTime.Now).ToList();

            gvTrainingFront.DataSource = trainningMainList;
            gvTrainingFront.DataBind();
        }

        protected void btnAddtraining_Click(object sender, EventArgs e)
        {
            string Url = "AddTraining.aspx?TrainingMainId=" + 0;
            Response.Redirect(Url);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            trainningMainList[rowIndex].Is_Active = 0;

            trainingMainController.Update(trainningMainList[rowIndex]);

            string url = "AddTrainingFront.aspx";
            Response.Redirect(url);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            string Url = "AddTraining.aspx?TrainingMainId=" + trainningMainList[rowIndex].TrainingMainId;
            Response.Redirect(Url);
        }
    }
}