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


namespace ManPowerWeb
{
    public partial class AnnualTarget : System.Web.UI.Page
    {
        List<ProgramTarget> programTargetsList = new List<ProgramTarget>();
        List<ProgramTarget> programTargetsListState = new List<ProgramTarget>();



        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataSource();

        }

        private void BindDataSource()
        {

            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            programTargetsList = programTargetController.GetAllProgramTarget(false, false, false, false);
            ViewState["programTargetsList"] = programTargetsList;
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
            programTargetsListState = (List<ProgramTarget>)ViewState["programTargetsList"];
            GridView1.DataSource = programTargetsListState.Where(x => x.TargetYear.ToString() == ddlYear.SelectedValue);
            GridView1.DataBind();
        }

        protected void btnAddNewTarget_Click(object sender, EventArgs e)
        {

        }
    }


}