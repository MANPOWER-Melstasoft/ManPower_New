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
    public partial class AnnualTargetRecomendation : System.Web.UI.Page
    {
        List<ProgramTarget> myList = new List<ProgramTarget>();
        List<ProgramTarget> programTargetsList = new List<ProgramTarget>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindSource();
            }


        }
        private void bindSource()
        {
            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            programTargetsList = programTargetController.GetAllProgramTarget(true, true, true, true);

            foreach (var i in programTargetsList.Where(u => u.IsRecommended == 1))
            {
                myList.Add(i);
            }
            GridView1.DataSource = myList;
            GridView1.DataBind();


        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            bindSource();
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = GridView1.PageSize;
            int pageindex = GridView1.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;
            Response.Redirect("AnnualTargetRecomendationView.aspx?ProgramTargetId=" + myList[rowIndex].ProgramTargetId.ToString());
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindSource();
        }


    }
}