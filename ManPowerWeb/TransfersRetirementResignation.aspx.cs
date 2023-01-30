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
    public partial class TransfersRetirementResignation : System.Web.UI.Page
    {

        List<ProgramTarget> programTargetsList = new List<ProgramTarget>();
        List<ProgramTarget> programTargetsListState = new List<ProgramTarget>();
        List<ProgramTarget> programTargetsSearchList = new List<ProgramTarget>();

        bool isCLicked = false;

        int year = DateTime.Now.Year;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataSource();
            }

        }

        private void BindDataSource()
        {

            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            programTargetsList = programTargetController.GetAllProgramTarget(false, false, false, false);



            if (isCLicked)
            {
                programTargetsSearchList = (List<ProgramTarget>)ViewState["programTargetsSearchList"];
                ViewState["programTargetsList"] = programTargetsSearchList.ToList();
                ViewState["programTargetsListRejected"] = programTargetsSearchList.Where(x => x.IsRecommended == 3).ToList();
                ViewState["programTargetsListApproved"] = programTargetsSearchList.Where(x => x.IsRecommended == 2).ToList();
                ViewState["programTargetsListPending"] = programTargetsSearchList.Where(x => x.IsRecommended == 1).ToList();
                ViewState["programTargetsListNotRecommended"] = programTargetsSearchList.Where(x => x.IsRecommended == 0).ToList();

                GridView1.DataSource = programTargetsSearchList;
            }
            else
            {
                ViewState["programTargetsList"] = programTargetsList.ToList();
                ViewState["programTargetsListRejected"] = programTargetsList.Where(x => x.IsRecommended == 3).ToList();
                ViewState["programTargetsListApproved"] = programTargetsList.Where(x => x.IsRecommended == 2).ToList();
                ViewState["programTargetsListPending"] = programTargetsList.Where(x => x.IsRecommended == 1).ToList();
                ViewState["programTargetsListNotRecommended"] = programTargetsList.Where(x => x.IsRecommended == 0).ToList();
                GridView1.DataSource = programTargetsList;
            }


            GridView1.DataBind();

        }




        protected void btnAddNewTarget_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddTransfersRetirementResignation.aspx");
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            if (isCLicked == true)
            {
                isCLicked = false;

            }
            else
            {
                BindDataSource();
            }

        }


        protected void btnView_Click(object sender, EventArgs e)
        {
            BindDataSource();
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = GridView1.PageSize;
            int pageindex = GridView1.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;
            Response.Redirect("AddTransfersRetirementResignation.aspx?ProgramTargetId=" + programTargetsList[rowIndex].ProgramTargetId.ToString());

        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (ddlStatus.SelectedIndex == 0)
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["programTargetsListNotRecommended"];
            }
            else if (ddlStatus.SelectedIndex == 1)
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["programTargetsListPending"];
            }
            else if (ddlStatus.SelectedIndex == 2)
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["programTargetsListApproved"];
            }
            else if (ddlStatus.SelectedIndex == 3)
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["programTargetsListRejected"];
            }
            else
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["programTargetsList"];
            }

            GridView1.DataBind();
        }


    }
}