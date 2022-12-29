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


        List<ProgramTarget> programTargetsListPending = new List<ProgramTarget>();
        List<ProgramTarget> programTargetsListApproved = new List<ProgramTarget>();
        List<ProgramTarget> programTargetsListReject = new List<ProgramTarget>();

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

            ViewState["All"] = programTargetsList;
            ViewState["pending"] = programTargetsList.Where(x => x.IsRecommended == 0).ToList();
            ViewState["Approved"] = programTargetsList.Where(x => x.IsRecommended == 1).ToList();
            ViewState["Rejected"] = programTargetsList.Where(x => x.IsRecommended == 2).ToList();

            if (ddlStatus.SelectedValue == "0")
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["All"];
            }
            else if (ddlStatus.SelectedValue == "1")
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["pending"];
            }
            else if (ddlStatus.SelectedValue == "2")
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["Approved"];
            }
            else
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["Rejected"];
            }
            GridView1.DataBind();


        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            bindSource();
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = GridView1.PageSize;
            int pageindex = GridView1.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;
            Response.Redirect("AnnualTargetRecomendationView.aspx?ProgramTargetId=" + programTargetsList[rowIndex].ProgramTargetId.ToString() + "&Status=" + programTargetsList[rowIndex].IsRecommended);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.bindSource();

        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlStatus.SelectedValue == "0")
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["All"];
            }
            else if (ddlStatus.SelectedValue == "1")
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["pending"];
            }
            else if (ddlStatus.SelectedValue == "2")
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["Approved"];
            }
            else
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["Rejected"];
            }
            GridView1.DataBind();

        }
    }
}