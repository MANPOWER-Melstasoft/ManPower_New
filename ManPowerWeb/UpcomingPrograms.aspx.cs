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
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            BindDataSource();
        }

        private void BindDataSource()
        {

            DepartmentUnitPositionsController unitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
            unitPositions = unitPositionsController.GetAllDepartmentUnitPositions(false, false, false, false, false);

            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            user = systemUserController.GetAllSystemUser(false, false, false);

            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            programTargetsList = programTargetController.GetAllProgramTarget(false, false, false, false);

            ProgramAssigneeController programAssigneeController = ControllerFactory.CreateProgramAssigneeController();
            asignee = programAssigneeController.GetAllProgramAssignee(false, false, false);


            foreach (var i in unitPositions.Where(u => u.SystemUserId == Convert.ToInt32(Session["UserId"])))
            {
                foreach (var j in asignee.Where(u => u.DepartmentUnitPossitionsId == i.DepartmetUnitPossitionsId))
                {
                    foreach (var k in programTargetsList.Where(u => u.ProgramTargetId == j.ProgramTargetId))
                    {
                        myList.Add(k);
                    }
                }
            }

            ViewState["myList"] = myList;
            GridView1.DataSource = myList;
            GridView1.DataBind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(TextBox4.Text);

            myList = (List<ProgramTarget>)ViewState["myList"];
            GridView1.DataSource = myList.Where(u => u.StartDate.Date == date.Date && u.ProgramTypeId == int.Parse(ddl1.SelectedValue));
            GridView1.DataBind();
        }

        protected void reset(object sender, EventArgs e)
        {
            Response.Redirect("UpcomingPrograms.aspx");
        }
    }
}