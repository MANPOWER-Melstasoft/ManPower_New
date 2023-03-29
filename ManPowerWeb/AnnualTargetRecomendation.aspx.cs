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
        static List<ProgramTarget> programTargetsList = new List<ProgramTarget>();
        static List<ProgramTarget> programTargetsListFilter = new List<ProgramTarget>();


        List<ProgramTarget> programTargetsListPending = new List<ProgramTarget>();
        List<ProgramTarget> programTargetsListApproved = new List<ProgramTarget>();
        List<ProgramTarget> programTargetsListReject = new List<ProgramTarget>();
        SystemUser systemUser = new SystemUser();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                bindSource();
            }
        }

        private void bindSource()
        {
            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            programTargetsList = programTargetController.GetAllProgramTarget(true, true, true, true);
            programTargetsList = programTargetsList.Where(x => x.RecommendedBy == Convert.ToInt32(Session["UserId"])).ToList();
            programTargetsListFilter = programTargetsList.ToList();
            ViewState["All"] = programTargetsList;
            ViewState["pending"] = programTargetsList.Where(x => x.IsRecommended == 1).ToList();
            ViewState["Approved"] = programTargetsList.Where(x => x.IsRecommended == 2).ToList();
            ViewState["Rejected"] = programTargetsList.Where(x => x.IsRecommended == 3).ToList();

            if (ddlStatus.SelectedValue == "0")
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["All"];
                programTargetsListFilter = (List<ProgramTarget>)ViewState["All"];
            }
            else if (ddlStatus.SelectedValue == "1")
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["pending"];
                programTargetsListFilter = (List<ProgramTarget>)ViewState["pending"];
            }
            else if (ddlStatus.SelectedValue == "2")
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["Approved"];
                programTargetsListFilter = (List<ProgramTarget>)ViewState["Approved"];
            }
            else
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["Rejected"];
                programTargetsListFilter = (List<ProgramTarget>)ViewState["Rejected"];
            }
            GridView1.DataBind();


        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            //bindSource();
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = GridView1.PageSize;
            int pageindex = GridView1.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;
            Response.Redirect("AnnualTargetRecomendationView.aspx?ProgramTargetId=" + programTargetsListFilter[rowIndex].ProgramTargetId.ToString() + "&Status=" + programTargetsListFilter[rowIndex].IsRecommended);

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
                programTargetsListFilter = (List<ProgramTarget>)ViewState["All"];
            }
            else if (ddlStatus.SelectedValue == "1")
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["pending"];
                programTargetsListFilter = (List<ProgramTarget>)ViewState["pending"];
            }
            else if (ddlStatus.SelectedValue == "2")
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["Approved"];
                programTargetsListFilter = (List<ProgramTarget>)ViewState["Approved"];
            }
            else
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["Rejected"];
                programTargetsListFilter = (List<ProgramTarget>)ViewState["Rejected"];
            }
            GridView1.DataBind();

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                systemUser = systemUserController.GetSystemUser(Convert.ToInt32(e.Row.Cells[1].Text), false, false, false);
                e.Row.Cells[1].Text = systemUser.Name;
            }
        }
    }
}