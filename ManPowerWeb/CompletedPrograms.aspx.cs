using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections;
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
        static List<ProgramPlan> mylist = new List<ProgramPlan>();
        List<ProgramPlan> searchList = new List<ProgramPlan>();
        List<ProgramPlan> ProgramPlanlist2 = new List<ProgramPlan>();
        private List<DepartmentUnitPositions> unitPositions = new List<DepartmentUnitPositions>();
        private List<ProgramAssignee> asignee = new List<ProgramAssignee>();


        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                BindDataSource();

            }
        }

        private void BindDataSource()
        {
            //ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            //programTargetsList = programTargetController.GetAllProgramTarget(false, false, false, false);

            //DepartmentUnitPositionsController unitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
            //unitPositions = unitPositionsController.GetAllDepartmentUnitPositions(false, false, false, false, false);

            //DepartmentUnitTypeController _DepartmentUnitTypeController = ControllerFactory.CreateDepartmentUnitTypeController();
            //listDistrict = _DepartmentUnitTypeController.GetDepartmentUnitType(2, true)._DepartmentUnit;

            //ProgramTypeController programTypeController = ControllerFactory.CreateProgramTypeController();
            //listProgramType = programTypeController.GetAllProgramType(false);

            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            ProgramPlanlist = programPlanController.GetAllProgramPlan(false, false, true, false, false, false);

            ProgramAssigneeController programAssigneeController = ControllerFactory.CreateProgramAssigneeController();
            asignee = programAssigneeController.GetAllProgramAssignee(false, true, false);



            foreach (var asignee in asignee.Where(x => x.DepartmentUnitPossitionsId == Convert.ToInt32(Session["DepUnitPositionId"])))
            {
                foreach (var plans in ProgramPlanlist.Where(x => x.ProjectStatusId == 4 && x.ProgramTargetId == asignee.ProgramTargetId))
                {
                    mylist.Add(plans);
                }
            }

            //foreach (var i in unitPositions.Where(u => u.SystemUserId == Convert.ToInt32(Session["UserId"])))
            //{
            //    foreach (var j in asignee.Where(u => u.DepartmentUnitPossitionsId == i.DepartmetUnitPossitionsId))
            //    {
            //        foreach (var k in programTargetsList.Where(u => u.ProgramTargetId == j.ProgramTargetId))
            //        {
            //            foreach (var l in ProgramPlanlist.Where(u => u.ProgramTargetId == k.ProgramTargetId && u.ProjectStatusId == 4))
            //            {
            //                mylist.Add(l);
            //            }
            //        }
            //    }
            //}

            ViewState["mylist"] = mylist;
            GridView1.DataSource = mylist;
            GridView1.DataBind();
            mylist.Clear();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(TextBox4.Text);

            searchList = (List<ProgramPlan>)ViewState["mylist"];
            mylist = mylist.Where(u => u.Date.Date == date.Date).ToList();
            GridView1.DataSource = mylist;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            GridView1.DataSource = mylist;
            GridView1.DataBind();
        }
    }
}