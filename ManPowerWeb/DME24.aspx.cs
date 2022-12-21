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
    public partial class DME24 : System.Web.UI.Page
    {

        List<ResourcePerson> resName = new List<ResourcePerson>();
        List<ProgramPlan> programPlans = new List<ProgramPlan>();
        List<ManPowerCore.Domain.Program> program = new List<ManPowerCore.Domain.Program>();
        List<ManPowerCore.Domain.Program> myprogramlist = new List<ManPowerCore.Domain.Program>();
        List<ProgramTarget> programlist = new List<ProgramTarget>();
        List<ProgramTarget> targets = new List<ProgramTarget>();
        List<ProgramAssignee> pa = new List<ProgramAssignee>();
        List<ProgramAssignee> assignees = new List<ProgramAssignee>();
        public SystemUser userRegistationDetailsList;
        private List<DepartmentUnitPositions> unitPositions = new List<DepartmentUnitPositions>();


        protected void Page_Load(object sender, EventArgs e)
        {

           // BindDataSource();
            //diloagBox.Visible = false;

            if (!IsPostBack)
            {
                BindDataSource();
                //hideDSDivision();
                //bindOficerRecomendation();

            }
        }

        private void BindDataSource()
        {
            ProgramTargetController _ProgramTargetController = ControllerFactory.CreateProgramTargetController();
            programlist = _ProgramTargetController.GetAllProgramTarget(false, false, false, false);

            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            programPlans = programPlanController.GetAllProgramPlan(false, false, false, false, false, false);

            ResourcePersonController resourcePersonController = ControllerFactory.CreateResourcePersonController();
            resName = resourcePersonController.GetAllResourcePerson();

            ProgramController programController = ControllerFactory.CreateProgramController();
            program = programController.GetAllProgram(false);

            ProgramAssigneeController programAssigneeController = ControllerFactory.CreateProgramAssigneeController();
            pa = programAssigneeController.GetAllProgramAssignee(false, false, false);

            DepartmentUnitPositionsController unitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
            unitPositions = unitPositionsController.GetAllDepartmentUnitPositions(false, false, false, false, true);

            foreach (var i in unitPositions.Where(u => u.SystemUserId == 13))
            {
                foreach (var j in pa.Where(u => u.DepartmentUnitPossitionsId == i.DepartmetUnitPossitionsId))
                {
                    foreach (var k in programlist)
                    {
                        if (k.ProgramTargetId == j.ProgramTargetId)
                        {
                            targets.Add(k);
                        }
                    }

                }
            }

            foreach (var i in targets)
            {
                foreach (var j in program.Where(u => u.ProgramId == i.ProgramId))
                {
                    myprogramlist.Add(j);
                }
            }

            ddlProgramName.DataSource = myprogramlist;
            ddlProgramName.DataBind();
            ddlProgramName.DataTextField = "ProgramName";
            ddlProgramName.DataValueField = "ProgramId";
            ddlProgramName.DataBind();

            ddlResourcePerson.DataSource = resName;
            ddlResourcePerson.DataTextField = "Name";
            ddlResourcePerson.DataValueField = "ResoursePersonId";
            ddlResourcePerson.DataBind();
        }

        private void bindProgram()
        {
            ProgramController programController = ControllerFactory.CreateProgramController();
            program = programController.GetAllProgram(false);
            if (ddlProgramName.SelectedValue != "")
            {
                ddlProgramName.DataSource = program.Where(u => u.ProgramId.ToString() == ddlProgramName.SelectedValue);
                ddlProgramName.DataBind();
                ddlProgramName.DataTextField = "ProgramName";
                ddlProgramName.DataValueField = "ProgramId";
                ddlProgramName.DataBind();
            }
            else
            {
                ddlProgramName.Items.Clear();
            }
        }

        protected void ddlProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindProgram();
        }


        private void bindResourcePerson()
        {
            ProgramController programController = ControllerFactory.CreateProgramController();
            program = programController.GetAllProgram(false);
            if (ddlResourcePerson.SelectedValue != "")
            {
                ddlResourcePerson.DataSource = resName.Where(u => u.ResoursePersonId.ToString() == ddlResourcePerson.SelectedValue);
                ddlResourcePerson.DataBind();
                ddlResourcePerson.DataTextField = "Name";
                ddlResourcePerson.DataValueField = "ResoursePersonId";
                ddlResourcePerson.DataBind();
            }
            else
            {
                ddlResourcePerson.Items.Clear();
            }
        }

        protected void ddlResourcePerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindResourcePerson();
        }
    }
}