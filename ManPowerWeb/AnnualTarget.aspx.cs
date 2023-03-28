using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace ManPowerWeb
{
    public partial class AnnualTarget : System.Web.UI.Page
    {
        static List<ProgramTarget> programTargetsList = new List<ProgramTarget>();
        static List<ProgramTarget> programTargetsListState = new List<ProgramTarget>();
        static List<ProgramTarget> programTargetsSearchList = new List<ProgramTarget>();

        bool isCLicked = false;

        int year = DateTime.Now.Year;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

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
            //programTargetsList = programTargetsList.Where(x => x.CreatedBy == Convert.ToInt32(Session["UserId"])).ToList();


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
            if (ddlMonth.SelectedValue != "" || ddlYear.SelectedValue != "")
            {
                bindDataSearch();
            }


            if (ddlStatus.SelectedValue == "1")
            {
                programTargetsList = programTargetsList.Where(x => x.IsRecommended == 1).ToList();
                GridView1.DataSource = programTargetsList;

            }
            else if (ddlStatus.SelectedValue == "2")
            {
                programTargetsList = programTargetsList.Where(x => x.IsRecommended == 2).ToList();
                GridView1.DataSource = programTargetsList;
            }
            else if (ddlStatus.SelectedValue == "3")
            {
                programTargetsList = programTargetsList.Where(x => x.IsRecommended == 3).ToList();
                GridView1.DataSource = programTargetsList;
            }
            else if (ddlStatus.SelectedValue == "0")
            {
                programTargetsList = programTargetsList.Where(x => x.IsRecommended == 0).ToList();
                GridView1.DataSource = programTargetsList;
            }
            else
            {
                GridView1.DataSource = programTargetsList;
            }

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
            ViewState["programTargetsSearchList"] = programTargetsListState.Where(x => x.StartDate.Month.ToString() == ddlMonth.SelectedValue && x.StartDate.Year.ToString() == ddlYear.SelectedValue).ToList();

            GridView1.DataSource = programTargetsListState.Where(x => x.StartDate.Month.ToString() == ddlMonth.SelectedValue && x.StartDate.Year.ToString() == ddlYear.SelectedValue).ToList();


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



            //------------------Encrypt URL-------------------------------------- -
            //string queryString = " ProgramTargetId = " + programTargetsList[rowIndex].ProgramTargetId.ToString() + " & Status = " + programTargetsList[rowIndex].IsRecommended;
            string queryString = "ProgramTargetId=" + programTargetsList[rowIndex].ProgramTargetId.ToString() + "&Status=" + programTargetsList[rowIndex].IsRecommended;


            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                version: 1,
                name: "MyAuthTicket",
                issueDate: DateTime.Now,
                expiration: DateTime.Now.AddMinutes(10),
                isPersistent: false,
                userData: queryString,
                cookiePath: FormsAuthentication.FormsCookiePath);

            string encryptedTicket = FormsAuthentication.Encrypt(ticket);

            string url = "AnnualTargetView.aspx?encrypt=" + encryptedTicket;
            Response.Redirect(url);

            //Response.Redirect("AnnualTargetView.aspx?ProgramTargetId=" + programTargetsList[rowIndex].ProgramTargetId.ToString() + "&Status=" + programTargetsList[rowIndex].IsRecommended);

        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (ddlStatus.SelectedValue == "0")
            {
                programTargetsList = programTargetsList.Where(x => x.IsRecommended == 0).ToList();
                GridView1.DataSource = (List<ProgramTarget>)ViewState["programTargetsListNotRecommended"];
            }
            else if (ddlStatus.SelectedValue == "1")
            {
                programTargetsList = programTargetsList.Where(x => x.IsRecommended == 0).ToList();
                GridView1.DataSource = (List<ProgramTarget>)ViewState["programTargetsListPending"];
            }
            else if (ddlStatus.SelectedValue == "2")
            {
                programTargetsList = programTargetsList.Where(x => x.IsRecommended == 0).ToList();
                GridView1.DataSource = (List<ProgramTarget>)ViewState["programTargetsListApproved"];
            }
            else if (ddlStatus.SelectedValue == "3")
            {
                programTargetsList = programTargetsList.Where(x => x.IsRecommended == 0).ToList();
                GridView1.DataSource = (List<ProgramTarget>)ViewState["programTargetsListRejected"];
            }
            else
            {
                BindDataSource();
                GridView1.DataSource = (List<ProgramTarget>)ViewState["programTargetsList"];
            }



            GridView1.DataBind();
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = ViewState["programTargetsList"] = programTargetsList.ToList();
            GridView1.DataBind();
        }
    }


}