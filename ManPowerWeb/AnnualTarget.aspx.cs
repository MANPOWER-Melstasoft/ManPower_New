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
    public partial class AnnualTarget : System.Web.UI.Page
    {
        List<ProgramTarget> programTargetsList = new List<ProgramTarget>();
        List<string> yearList = new List<string> { "2020", "2021", "2022" };

        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataSource();

        }

        private void BindDataSource()
        {

            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            programTargetsList = programTargetController.GetAllProgramTarget(false, false, false, false);
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
    }


}