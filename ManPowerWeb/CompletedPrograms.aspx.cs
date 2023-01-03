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
        List<ProgramPlan> mylist = new List<ProgramPlan>();
        List<ProgramPlan> searchList = new List<ProgramPlan>();
        List<ProgramPlan> ProgramPlanlist2 = new List<ProgramPlan>();
        private List<DepartmentUnitPositions> unitPositions = new List<DepartmentUnitPositions>();
        private List<ProgramAssignee> asignee = new List<ProgramAssignee>();


        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataSource();
        }

        private void BindDataSource()
        {
            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            programTargetsList = programTargetController.GetAllProgramTarget(false, false, false, false);

            DepartmentUnitPositionsController unitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
            unitPositions = unitPositionsController.GetAllDepartmentUnitPositions(false, false, false, false, false);

            DepartmentUnitTypeController _DepartmentUnitTypeController = ControllerFactory.CreateDepartmentUnitTypeController();
            listDistrict = _DepartmentUnitTypeController.GetDepartmentUnitType(2, true)._DepartmentUnit;

            ProgramTypeController programTypeController = ControllerFactory.CreateProgramTypeController();
            listProgramType = programTypeController.GetAllProgramType(false);

            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            ProgramPlanlist = programPlanController.GetAllProgramPlan(false, false, false, false, false, false);

            ProgramAssigneeController programAssigneeController = ControllerFactory.CreateProgramAssigneeController();
            asignee = programAssigneeController.GetAllProgramAssignee(true, false, false);

            foreach (var i in unitPositions.Where(u => u.SystemUserId == Convert.ToInt32(Session["UserId"])))
            {
                foreach (var j in asignee.Where(u => u.DepartmentUnitPossitionsId == i.DepartmetUnitPossitionsId))
                {
                    foreach (var k in programTargetsList.Where(u => u.ProgramTargetId == j.ProgramTargetId))
                    {
                        foreach (var l in ProgramPlanlist.Where(u => u.ProgramTargetId == k.ProgramTargetId))
                        {
                            mylist.Add(l);
                        }
                    }
                }
            }

            ViewState["mylist"] = mylist;
            GridView1.DataSource = mylist;
            GridView1.DataBind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(TextBox4.Text);

            searchList = (List<ProgramPlan>)ViewState["mylist"];
            GridView1.DataSource = searchList.Where(u => u.Date.Date == date.Date);
            GridView1.DataBind();
        }
    }
}