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
    public partial class PlanningRecommendation1 : System.Web.UI.Page
    {

        static List<ProgramPlan> plansList = new List<ProgramPlan>();
        List<ProgramPlanApprovalDetails> ProgramPlanApprovalDetails = new List<ProgramPlanApprovalDetails>();
        List<ProjectPlanResource> projectPlanResourcesList = new List<ProjectPlanResource>();
        SystemUser systemUser = new SystemUser();
        List<ResourcePerson> resourcePeopleList = new List<ResourcePerson>();



        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                DataSourceBind();

                ResourcePersonController resourcePersonController = ControllerFactory.CreateResourcePersonController();
                resourcePeopleList = resourcePersonController.GetAllResourcePerson(false);

                //Bind Data To CheckBox List
                chkList.DataSource = resourcePeopleList;
                chkList.DataValueField = "ResoursePersonId";
                chkList.DataTextField = "Name";
                chkList.DataBind();

                //End Bind Data To CheckBox List
            }
        }

        private void DataSourceBind()
        {
            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            ProgramPlanApprovalDetailsController programPlanApprovalDetailsController = ControllerFactory.CreateProgramPlanApprovalDetailsController();

            ProgramPlanApprovalDetails = programPlanApprovalDetailsController.GetAll();

            plansList = programPlanController.GetAllProgramPlan(false, false, true, false, false, false);
            plansList = plansList.Where(x => x.ProjectStatusId == 2013).ToList();


            foreach (var item in plansList)
            {

                item._ProgramPlanApprovalDetails = ProgramPlanApprovalDetails.Where(u => u.ProgramPlanId == item.ProgramPlanId && u.Recommendation1By == Convert.ToInt32(Session["DepUnitPositionId"])).ToList();
            }

            gvProgramPlan.DataSource = plansList;
            gvProgramPlan.DataBind();


        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = gvProgramPlan.PageSize;
            int pageindex = gvProgramPlan.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;

            ProgramPlan programPlansListBind = new ProgramPlan();
            programPlansListBind = plansList[rowIndex];

            List<ProgramPlan> programPlansList = plansList.Where(x => x.ProgramPlanId == programPlansListBind.ProgramPlanId).ToList();

            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            systemUser = systemUserController.GetSystemUser(programPlansListBind._ProgramTarget.CreatedBy, false, false, false);

            ViewState["ProgramPlanId"] = plansList[rowIndex].ProgramPlanId;

            //get Employee Details With DS Division

            EmployeeDetailsFromProgramPlanController employeeDetailsFromProgramPlanController = ControllerFactory.CreateEmployeeDetailsFromProgramPlanController();
            EmployeeDetailsFromProgramPlan employeeDetailsFromProgramPlan = employeeDetailsFromProgramPlanController.GetAllEmployeeDetailsFromProgramPlansByProgramPlanId(programPlansListBind.ProgramPlanId);


            ProjectPlanResourceController projectPlanResourceController = ControllerFactory.CreateProjectPlanResourceController();
            projectPlanResourcesList = projectPlanResourceController.GetAllProjectPlanResourcesByProgramPlanId(programPlansListBind.ProgramPlanId);



            foreach (var item in projectPlanResourcesList)
            {
                for (int i = 0; i < chkList.Items.Count; i++)
                {
                    if (chkList.Items[i].Value == item.ResourcePersonId.ToString())
                    {
                        chkList.Items[i].Selected = true;
                    }
                }
            }

            txtManger.Text = systemUser.Name;
            txtProgramName.Text = programPlansListBind.ProgramName;
            txtDate.Text = programPlansListBind.Date.ToString("yyyy-MM-dd");
            txtBudget.Text = programPlansListBind.ApprovedAmount.ToString();
            txtFemaleCount.Text = programPlansListBind.FemaleCount.ToString();
            txtMaleCount.Text = programPlansListBind.MaleCount.ToString();
            txtTotalCount.Text = (programPlansListBind.FemaleCount + programPlansListBind.MaleCount).ToString();
            txtLocation.Text = programPlansListBind.Location.ToString();
            txtActualOutcome.Text = programPlansListBind.Outcome.ToString();
            txtActualOutput.Text = programPlansListBind.ActualOutput.ToString();
            txtExpenditure.Text = programPlansListBind.ActualAmount.ToString();
            txtEstimateAmount.Text = programPlansListBind._ProgramTarget.EstimatedAmount.ToString();

            txtEmployeeName.Text = employeeDetailsFromProgramPlan.EmployeeName;
            txtEmployeeDivison.Text = employeeDetailsFromProgramPlan.DivisionName;


            if (programPlansListBind.FinancialSource != "" && programPlansListBind.FinancialSource != null)
            {
                gvFileResourses.DataSource = programPlansList;
                gvFileResourses.DataBind();
            }
            else
            {
                lblListOfUploadedFiles.Text = "N/A";
            }




        }

        protected void btnRejectReason_Click(object sender, EventArgs e)
        {
            int programPlanId = Convert.ToInt32(ViewState["ProgramPlanId"]);

            ProgramPlanApprovalDetailsController programPlanApprovalDetailsController = ControllerFactory.CreateProgramPlanApprovalDetailsController();

            ProgramPlanApprovalDetails programPlanApprovalDetails = new ProgramPlanApprovalDetails();

            programPlanApprovalDetails.ProgramPlanId = programPlanId;
            programPlanApprovalDetails.ProjectStatus = 2015;

            programPlanApprovalDetails.Recommendation1By = Convert.ToInt32(Session["DepUnitPositionId"]);
            programPlanApprovalDetails.Recommendation1Date = DateTime.Now;

            programPlanApprovalDetails.Recommendation2By = 0; ;
            //  programPlanApprovalDetails.Recommendation2Date =;

            programPlanApprovalDetails.RejectReason = txtrejectReason.Text;

            int response = programPlanApprovalDetailsController.Save(programPlanApprovalDetails);

            if (response != 0)
            {

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Succesfully Rejected!', 'success');window.setTimeout(function(){window.location='PlanningRecommendation1.aspx'},2500);", true);

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);
            }
        }

        protected void btnSendToRecommendation_Click(object sender, EventArgs e)
        {
            int programPlanId = Convert.ToInt32(ViewState["ProgramPlanId"]);

            ProgramPlanApprovalDetailsController programPlanApprovalDetailsController = ControllerFactory.CreateProgramPlanApprovalDetailsController();

            ProgramPlanApprovalDetails programPlanApprovalDetails = new ProgramPlanApprovalDetails();

            programPlanApprovalDetails.ProgramPlanId = programPlanId;
            programPlanApprovalDetails.ProjectStatus = 2016;

            programPlanApprovalDetails.Recommendation1By = Convert.ToInt32(Session["DepUnitPositionId"]);
            programPlanApprovalDetails.Recommendation1Date = DateTime.Now;

            programPlanApprovalDetails.Recommendation2By = Convert.ToInt32(Session["DepUnitParentId"]); ;
            //  programPlanApprovalDetails.Recommendation2Date =;

            programPlanApprovalDetails.RejectReason = "";

            int response = programPlanApprovalDetailsController.Save(programPlanApprovalDetails);

            if (response != 0)
            {

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Succesfully Sent To Recommendation!', 'success');window.setTimeout(function(){window.location='PlanningRecommendation1.aspx'},2500);", true);

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);
            }
        }

        protected void btnView_Click1(object sender, EventArgs e)
        {

        }
    }
}