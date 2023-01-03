using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class UpcomingPrograms : System.Web.UI.Page
    {
        private string district;
        private string ds;
        private string des;
        private string pTypeName;
        private DateTime start;

        private List<ProgramTarget> programTargetsList = new List<ProgramTarget>();
        private List<ProgramTarget> TargetsList = new List<ProgramTarget>();
        private List<ProgramTarget> myList = new List<ProgramTarget>();
        List<ProgramTarget> myList2 = new List<ProgramTarget>();
        private List<ProgramAssignee> asignee = new List<ProgramAssignee>();
        private List<DepartmentUnitPositions> unitPositions = new List<DepartmentUnitPositions>();
        private List<SystemUser> user = new List<SystemUser>();
        List<DepartmentUnit> listDistrict = new List<DepartmentUnit>();
        List<DepartmentUnitType> unitType = new List<DepartmentUnitType>();
        List<ProgramType> listProgramType = new List<ProgramType>();
        List<ManPowerCore.Domain.Program> program = new List<ManPowerCore.Domain.Program>();

        List<ProgramAssignee> MyAssigneelist = new List<ProgramAssignee>();
        public SystemUser userRegistationDetailsList;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            BindDataSource();
        }

        private void BindDataSource()
        {

            DepartmentUnitPositionsController unitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
            unitPositions = unitPositionsController.GetAllDepartmentUnitPositions(false, false, false, false, false);

            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            user = systemUserController.GetAllSystemUser(false, false, false);

            //DepartmentUnitController unit = ControllerFactory.CreateDepartmentUnitController();
            //listDistrict = unit.GetAllDepartmentUnit(false, false);

            //DepartmentUnitTypeController aa = ControllerFactory.CreateDepartmentUnitTypeController();
            //unitType = aa.GetAllDepartmentUnitType(false);

            //ProgramTypeController programTypeController = ControllerFactory.CreateProgramTypeController();
            //listProgramType = programTypeController.GetAllProgramType(false);

            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            programTargetsList = programTargetController.GetAllProgramTarget(false, false, false, false);

            ProgramAssigneeController programAssigneeController = ControllerFactory.CreateProgramAssigneeController();
            asignee = programAssigneeController.GetAllProgramAssignee(false, false, false);

            //ProgramController programController = ControllerFactory.CreateProgramController();
            //program = programController.GetAllProgram(false);

            //List<ProgramTarget> TargetsList = programTargetController.GetAllProgramTarget(false, false, true, false);

            //foreach (var i in programTargetsList)
            //{
            //    if (i.TargetMonth == DateTime.Today.Month)
            //    {
            //    }
            //}


            foreach (var i in unitPositions.Where(u => u.SystemUserId == Convert.ToInt32(Session["UserId"])))
            {
                foreach (var j in asignee.Where(u => u.DepartmentUnitPossitionsId == i.DepartmetUnitPossitionsId))
                {
                    foreach (var k in programTargetsList.Where(u => u.ProgramTargetId == j.ProgramTargetId && u.StartDate >= DateTime.Today.Date))
                    {
                        myList.Add(k);
                    }
                }
            }

            ViewState["myList"] = myList;
            GridView1.DataSource = myList;
            GridView1.DataBind();

            

            //foreach (var k in MyAssigneelist)
            //{
            //    foreach (var i in unitPositions.Where(u => u.DepartmetUnitPossitionsId == k.DepartmentUnitPossitionsId))
            //    {
            //        foreach (var j in listDistrict.Where(u => u.DepartmentUnitId == i.ParentId))
            //        {

            //            district = j.Name;

            //        }
            //    }
            //}

            //foreach (var k in MyAssigneelist)
            //{
            //    foreach (var i in unitPositions.Where(u => u.DepartmetUnitPossitionsId == k.DepartmentUnitPossitionsId))
            //    {
            //        foreach (var j in listDistrict.Where(u => u.DepartmentUnitId == i.DepartmentUnitId))
            //        {
            //            if (j.DepartmentUnitTypeId == 2)
            //            {
            //                ds = "- District Level Target -";
            //            }
            //            else if (j.DepartmentUnitTypeId == 3)
            //            {
            //                ds = j.Name;
            //            }
            //        }
            //    }
            //}


            //foreach (var k in MyAssigneelist)
            //{
            //    foreach (var i in programTargetsList.Where(u => u.ProgramTargetId == k.ProgramTargetId))
            //    {
            //        start = i.StartDate;
            //    }
            //}

            //foreach (var k in MyAssigneelist)
            //{
            //    foreach(var i in programTargetsList.Where(u => u.ProgramTargetId == k.ProgramTargetId))
            //                    {
            //        des = i.Description;
            //    }
            //}

            //foreach (var k in MyAssigneelist)
            //{
            //    foreach(var i in programTargetsList.Where(u => u.ProgramTargetId == k.ProgramTargetId))
            //    {
            //        foreach(var j in listProgramType.Where(u => u.ProgramTypeId == i.ProgramTypeId))
            //        {
            //            pTypeName = j.ProgramTypeName;
            //        }
            //    }

            //}
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //myList.CopyTo(myList2);
            DateTime date = Convert.ToDateTime(TextBox4.Text);
            //ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            //searchList = programPlanController.getCompletedProgramsFilter(date);

            myList = (List<ProgramTarget>)ViewState["myList"];
            GridView1.DataSource = myList.Where(u => u.StartDate.Date == date.Date && u.ProgramTypeId == int.Parse( ddl1.SelectedValue));
            GridView1.DataBind();
        }
    }
}