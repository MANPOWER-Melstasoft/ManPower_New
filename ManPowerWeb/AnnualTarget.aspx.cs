using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace ManPowerWeb
{
    public partial class AnnualTarget : System.Web.UI.Page
    {
        List<ProgramTarget> programTargetsList = new List<ProgramTarget>();
        List<ProgramTarget> programTargetsListState = new List<ProgramTarget>();
        bool isCLicked = false;

        int year = DateTime.Now.Year;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                for (int i = year - 10; i <= year + 10; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    ddlYear.Items.Add(li);
                }
                //ddlYear.Items.FindByText(year.ToString()).Selected = true;
                ddlYear.Items.Insert(0, new ListItem("Select Year", ""));
                BindDataSource();
            }




        }

        private void BindDataSource()
        {

            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            programTargetsList = programTargetController.GetAllProgramTarget(false, false, false, false);
            ViewState["programTargetsList"] = programTargetsList.ToList();
            ViewState["programTargetsListRejected"] = programTargetsList.Where(x => x.IsRecommended == 3).ToList();
            ViewState["programTargetsListApproved"] = programTargetsList.Where(x => x.IsRecommended == 2).ToList();
            ViewState["programTargetsListPending"] = programTargetsList.Where(x => x.IsRecommended == 1).ToList();
            ViewState["programTargetsListNotRecommended"] = programTargetsList.Where(x => x.IsRecommended == 0).ToList();

            GridView1.DataSource = programTargetsList;
            GridView1.DataBind();

        }


        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlYear.SelectedValue == "2020")
                GridView1.DataSource = programTargetsList.Where(x => x.TargetYear.ToString() == "2020");
            else
                GridView1.DataSource = programTargetsList;

            GridView1.DataBind();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

            GridView1.DataSource = programTargetsList.Where(x => x.TargetYear.ToString() == ddlYear.SelectedValue);
            GridView1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            isCLicked = true;
            bindDataSearch();

        }
        private void bindDataSearch()
        {
            programTargetsListState = (List<ProgramTarget>)ViewState["programTargetsList"];

            GridView1.DataSource = programTargetsListState.Where(x => x.TargetYear.ToString() == ddlYear.SelectedValue && x.TargetMonth.ToString() == ddlMonth.SelectedValue).ToList();


            GridView1.DataBind();
            isCLicked = false;
        }

        protected void btnAddNewTarget_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewTarget.aspx");
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            if (isCLicked == true)
            {
                bindDataSearch();
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
            Response.Redirect("AnnualTargetView.aspx?ProgramTargetId=" + programTargetsList[rowIndex].ProgramTargetId.ToString() + "&Status=" + programTargetsList[rowIndex].IsRecommended);





        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (ddlStatus.SelectedIndex == 0)
            {
                GridView1.DataSource = (List<ProgramTarget>)ViewState["programTargetsListNotRecommended"]; ;
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