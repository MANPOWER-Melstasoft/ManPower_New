using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class planningEdit : System.Web.UI.Page
    {
        List<ResourcePerson> resourcePeopleList = new List<ResourcePerson>();
        List<ProgramTarget> programTargets = new List<ProgramTarget>();
        int programTargetId;
        string programTargetName;
        int programId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataSource();

            }

        }
        private void dataSource()
        {
            ResourcePersonController resourcePersonController = ControllerFactory.CreateResourcePersonController();
            resourcePeopleList = resourcePersonController.GetAllResourcePerson();


            programTargetId = Convert.ToInt32(Request.QueryString["ProgramTargetId"]);
            ViewState["programTargetId"] = programTargetId;
            programTargetName = Request.QueryString["ProgramName"];
            txtProgramName.Text = programTargetName;
            ddlResourcePerson.DataSource = resourcePeopleList;
            ddlResourcePerson.DataValueField = "ResoursePersonId";
            ddlResourcePerson.DataTextField = "Name";
            ddlResourcePerson.DataBind();
        }



        protected void btnSave_Click1(object sender, EventArgs e)
        {
            ProgramPlan programPlan = new ProgramPlan();
            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();


            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            programTargets = programTargetController.GetAllProgramTargetWithPlan();




            programPlan.Date = DateTime.Now;
            programPlan.ProjectStatusId = 1;
            programPlan.ProgramName = "";
            programPlan.FinancialSource = "";
            programPlan.ProgramCategoryId = 1;
            programPlan.Location = txtLocation.Text;
            programPlan.Outcome = 0;
            programPlan.Output = 0;
            programPlan.ActualOutput = 0;
            programPlan.IsApproved = 0;
            programPlan.ApprovedBy = "";
            programPlan.ApprovedDate = DateTime.Now;
            programPlan.TotalEstimatedAmount = (float)Convert.ToDouble(txtBudget.Text);
            programPlan.ApprovedAmount = 0;
            programPlan.ActualAmount = 0;
            programPlan.MaleCount = int.Parse(txtMaleCount.Text);
            programPlan.FemaleCount = int.Parse(txtFemaleCount.Text);
            programPlan.Remark = "";
            programPlan.ProgramTargetId = programTargetId;
            programPlan.ProgramName = programTargetName;
            programPlan.Coordinater = ddlResourcePerson.SelectedValue;



            int response = programPlanController.UpdateProgramPlan(programPlan);
            if (response != 0)
            {
                Response.Redirect("planning.aspx");

            }

        }

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            programTargetId = Convert.ToInt32(Request.QueryString["ProgramTargetId"]);

            int response = programPlanController.UpdateProgramPlanComplete(4, programTargetId);
            if (response != 0)
            {
                Response.Redirect("planning.aspx");

            }
        }
    }
}