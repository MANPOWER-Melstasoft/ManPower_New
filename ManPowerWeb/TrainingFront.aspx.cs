using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class AddTrainingFront : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    BindListView();
            //}
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindListView();
            }
        }

        //public void BindListView()
        //{
        //    List<TrainingMain> trainningMainList = new List<TrainingMain>();
        //    TrainingMainController trainingMainController = ControllerFactory.CreateTrainingMainController();

        //    trainningMainList = trainingMainController.GetAllTrainingMain();
        //    trainningMainList = trainningMainList.Where(x => x.Is_Active == 1 && x.Start_Date > DateTime.Now).ToList();

        //    foreach (var item in trainningMainList)
        //    {
        //        item.Post_img = "SystemDocuments/TrainingImages/" + item.Post_img;
        //    }

        //    foreach (var item in trainningMainList)
        //    {
        //        StringBuilder cstextCard = new StringBuilder();

        //        cstextCard.Append(" <div class=\"col-xl-3 col-md-6\">   <div class=\"card mb-4\">   <div class=\"card-body\">   <asp:Image ID=\"");
        //        cstextCard.Append(item.TrainingMainId.ToString());
        //        cstextCard.Append("\" runat=\"server\" Height=\"100%\" Width=\"100%\" ImageUrl=\"");
        //        cstextCard.Append(item.Post_img);
        //        cstextCard.Append("\" />    <a class=\"small text-white stretched-link\" href=\"TrainingAd.aspx?TrainingMainId=");
        //        cstextCard.Append(item.TrainingMainId.ToString());
        //        cstextCard.Append("\"></a>    </div>    <div class=\"card-footer\">  <div class=\"text-center\">");
        //        cstextCard.Append(item.Title);
        //        cstextCard.Append("</div>     </div> </div>   </div>");

        //        ltTraining.Text += cstextCard;
        //    }


        //}

        public void BindListView()
        {
            List<TrainingMain> trainingMainList = new List<TrainingMain>();
            TrainingMainController trainingMainController = ControllerFactory.CreateTrainingMainController();

            trainingMainList = trainingMainController.GetAllTrainingMain();
            trainingMainList = trainingMainList.Where(x => x.Is_Active == 1 && x.Start_Date > DateTime.Now).ToList();

            foreach (var item in trainingMainList)
            {
                item.Post_img = "SystemDocuments/TrainingImages/" + item.Post_img;
                //item.Post_img = "SystemDocuments/TrainingImages/bottomimg2.jpg";

                StringBuilder cstextCard = new StringBuilder();



                cstextCard.Append(" <div class='col-xl-3 col-md-6'>   <div class='card mb-4'>   <div class='card-body'>   <img id =");
                cstextCard.Append(item.TrainingMainId.ToString());
                cstextCard.Append("\" style=\"height:100%;width:220px;\" src=");
                cstextCard.Append(item.Post_img);
                cstextCard.Append(">    <a class=\"small text-white stretched-link\" href=\"TrainingAd.aspx?TrainingMainId=");
                cstextCard.Append(item.TrainingMainId.ToString());
                cstextCard.Append("\"></a>    </div>    <div class=\"card-footer\">  <div class=\"text-center\">");
                cstextCard.Append(item.Title);
                cstextCard.Append("</div>     </div> </div>   </div>");

                ltTraining.Text += cstextCard.ToString();
            }
        }
    }
}