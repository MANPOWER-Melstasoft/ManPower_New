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
    public partial class CompletedPrograms : System.Web.UI.Page
    {
        private List<ProgramTarget> programTargetsList = new List<ProgramTarget>();
        List<DepartmentUnit> listDistrict = new List<DepartmentUnit>();
        List<ProgramType> listProgramType = new List<ProgramType>();
        List<ProgramPlan> ProgramPlanlist = new List<ProgramPlan>();
        List<ProgramPlan> searchList = new List<ProgramPlan>();
        List<ProgramPlan> ProgramPlanlist2 = new List<ProgramPlan>();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataSource();

        }

        private void BindDataSource()
        {

            DepartmentUnitTypeController _DepartmentUnitTypeController = ControllerFactory.CreateDepartmentUnitTypeController();
            listDistrict = _DepartmentUnitTypeController.GetDepartmentUnitType(2, true)._DepartmentUnit;

            ProgramTypeController programTypeController = ControllerFactory.CreateProgramTypeController();
            listProgramType = programTypeController.GetAllProgramType(false);

            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            ProgramPlanlist = programPlanController.GetAllProgramPlan(false, false, false, false, false, false);

            ViewState["ProgramPlanlist"] = ProgramPlanlist;
            GridView1.DataSource = ProgramPlanlist;
            GridView1.DataBind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(TextBox4.Text);
            //ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            //searchList = programPlanController.getCompletedProgramsFilter(date);
            
            searchList = (List<ProgramPlan>)ViewState["ProgramPlanlist"];
            GridView1.DataSource = searchList.Where(u => u.ConductDate.Date == date.Date);
            GridView1.DataBind();
        }


        //protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    if (ddlYear.SelectedValue == "2020")
        //        GridView1.DataSource = programTargetsList.Where(x => x.TargetYear.ToString() == "2020");
        //    else
        //        GridView1.DataSource = programTargetsList;

        //    GridView1.DataBind();
        //}

        //protected void btnReset_Click(object sender, EventArgs e)
        //{

        //    GridView1.DataSource = programTargetsList.Where(x => x.TargetYear.ToString() == ddlYear.SelectedValue);
        //    GridView1.DataBind();
        //}

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    programTargetsListState = (List<ProgramTarget>)ViewState["programTargetsList"];
        //    GridView1.DataSource = programTargetsListState.Where(x => x.TargetYear.ToString() == ddlYear.SelectedValue);
        //    GridView1.DataBind();
        //}
    }
}