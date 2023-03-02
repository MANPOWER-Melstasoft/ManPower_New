using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class IndividualBeneView : System.Web.UI.Page
    {
        List<InduvidualBeneficiary> beneficiaries = new List<InduvidualBeneficiary>();
        public static string BenficiaryId;
        CareerKeyTestResults careerKeyTestResults = new CareerKeyTestResults();
        List<DepartmentUnit> listDistrict = new List<DepartmentUnit>();
        List<DepartmentUnit> listDSDivision = new List<DepartmentUnit>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                BenficiaryId = Request.QueryString["id"];

                BindVacancies();
                BindJobcategory();
                BindJobGridView();
                bindCarrierGrid();
                GridView2DataBind();
                bindDistrictDivision();
                BindVacanciePosition();
                bindProgramPlan();

                InduvidualBeneficiaryController beneficiaryController = ControllerFactory.CreateInduvidualBeneficiaryController();
                beneficiaries = beneficiaryController.GetAllInduvidualBeneficiary(true);

                foreach (var i in beneficiaries.Where(u => u.BeneficiaryId == int.Parse(BenficiaryId)))
                {
                    nic.Text = i.BeneficiaryNic;
                    name.Text = i.InduvidualBeneficiaryName;
                    gender.Text = i.BeneficiaryGender;
                    dob.Text = i.DateOfBirth.ToString();
                    address.Text = i.PersonalAddress;
                    email.Text = i.BeneficiaryEmail;
                    jobType.Text = i.JobPreference;
                    contact.Text = i.ContactNumber;
                    whatsapp.Text = i.WhatsappNumber;


                    if (String.IsNullOrEmpty(i.SchoolName))
                    {
                        sclName.Text = "-";
                        sclAddress.Text = "-";
                        grade.Text = "-";
                        parentNic.Text = "-";
                    }
                    else
                    {
                        sclName.Text = i.SchoolName;
                        sclAddress.Text = i.AddressOfSchool;
                        grade.Text = i.SchoolGrade;
                        parentNic.Text = i.ParentNic;
                    }

                }
            }

        }

        protected void isClicked(object sender, EventArgs e)
        {
            Response.Redirect("IndividualBeneSearch.aspx");
        }


        private void bindProgramPlan()
        {
            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            List<ProgramPlan> programPlansList = new List<ProgramPlan>();

            ProgramAssigneeController programAssigneeController = ControllerFactory.CreateProgramAssigneeController();
            List<ProgramAssignee> programAssigneesList = programAssigneeController.GetAllProgramAssignee(true, true, false);

            foreach (var items in programAssigneesList)
            {
                if (items._DepartmentUnitPositions.SystemUserId == Convert.ToInt32(Session["UserId"]))
                {
                    List<ProgramPlan> programPlan = programPlanController.GetProgramPlanByProgramTargetId(items.ProgramTargetId);
                    programPlansList.AddRange(programPlan);
                }
            }

            //-----------------bind tab 1 program plan dropdown-----------------------

            ddlProgramPlanCarrerKey.DataSource = programPlansList;
            ddlProgramPlanCarrerKey.DataValueField = "ProgramPlanId";
            ddlProgramPlanCarrerKey.DataTextField = "ProgramName";
            ddlProgramPlanCarrerKey.DataBind();
            ddlProgramPlanCarrerKey.Items.Insert(0, new ListItem("-- select Program Plan --", ""));

            //-------------bind tab 3 program plan dropdown-----------------------

            ddlJobProgramPlan.DataSource = programPlansList;
            ddlJobProgramPlan.DataValueField = "ProgramPlanId";
            ddlJobProgramPlan.DataTextField = "ProgramName";
            ddlJobProgramPlan.DataBind();
            ddlJobProgramPlan.Items.Insert(0, new ListItem("-- select Program Plan --", ""));

            //---------bind tab 2 program plan dropdown-----------------

            ddlTrainningProgramplan.DataSource = programPlansList;
            ddlTrainningProgramplan.DataValueField = "ProgramPlanId";
            ddlTrainningProgramplan.DataTextField = "ProgramName";
            ddlTrainningProgramplan.DataBind();
            ddlTrainningProgramplan.Items.Insert(0, new ListItem("-- select Program Plan --", ""));


        }

        //-----------------------------------------------------Start Job Refferal ---------------------------------------------------------------------------------------


        private void bindDistrictDivision()
        {
            DepartmentUnitTypeController _DepartmentUnitTypeController = ControllerFactory.CreateDepartmentUnitTypeController();
            listDistrict = _DepartmentUnitTypeController.GetDepartmentUnitType(2, true)._DepartmentUnit;


            listDistrict = _DepartmentUnitTypeController.GetDepartmentUnitType(2, true)._DepartmentUnit;
            ddlDistrict.DataSource = listDistrict;
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataValueField = "DepartmentUnitId";

            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("-- select District --", ""));
        }

        protected void ddlDsDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindVacancies();
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDistrict.SelectedValue != "")
            {
                DepartmentUnitTypeController _DepartmentUnitTypeController = ControllerFactory.CreateDepartmentUnitTypeController();
                listDSDivision = _DepartmentUnitTypeController.GetDepartmentUnitType(3, true)._DepartmentUnit;
                ddlDsDivision.DataSource = listDSDivision.Where(u => u.ParentId.ToString() == ddlDistrict.SelectedValue);
                ddlDsDivision.DataTextField = "Name";
                ddlDsDivision.DataValueField = "DepartmentUnitId";
                ddlDsDivision.DataBind();
                ddlDsDivision.Items.Insert(0, new ListItem("-- select Division --", ""));
            }
            else
            {
                ddlDsDivision.Items.Clear();
            }


            BindVacancies();
        }
        protected void submitJobRefferal(object sender, EventArgs e)
        {
            JobRefferalsController jobRefferalsController = ControllerFactory.CreateJobRefferalsController();

            JobRefferals jobRefferals = new JobRefferals();

            jobRefferals.BeneficiaryId = Convert.ToInt32(BenficiaryId);
            jobRefferals.VacancyRegistrationId = Convert.ToInt32(ddlCompanyVacancies.SelectedValue.ToString());
            jobRefferals.JobCategoryId = Convert.ToInt32(ddlJobCategory.SelectedValue.ToString());
            jobRefferals.CereatedDate = DateTime.Today;
            if (jobPlacememntDate.Text != "")
            {
                jobRefferals.JobPlacementDate = DateTime.Parse(jobPlacememntDate.Text).Date;

            }
            jobRefferals.RefferalsDate = DateTime.Parse(jobRefferalsDate.Text).Date;
            jobRefferals.RefferalRemarks = jobRefferalRemark.Text;
            jobRefferals.CareerGuidance = careerGuidance.Text;
            if (ddlJobProgramPlan.SelectedValue != "")
            {
                jobRefferals.ProgramPlanId = Convert.ToInt32(ddlJobProgramPlan.SelectedValue);

            }
            jobRefferals.CreatedUser = Session["Name"].ToString();



            int output = jobRefferalsController.SaveJobRefferals(jobRefferals);
            if (output != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success')", true);
                JobRefferalClear();
                BindJobGridView();
            }
        }

        private void JobRefferalClear()
        {
            ddlCompanyVacancies.SelectedIndex = 0;
            ddlJobCategory.SelectedIndex = 0;
            jobPlacememntDate.Text = null;
            jobRefferalsDate.Text = null;
            jobRefferalRemark.Text = null;
            careerGuidance.Text = null;
        }

        protected void BindVacancies()
        {
            CompanyVecansyRegistationDetailsController companyVecansyRegistationDetailsController = ControllerFactory.CreateCompanyVecansyRegistationDetailsController();

            List<CompanyVecansyRegistationDetails> companyVecansyRegistationDetailsList = companyVecansyRegistationDetailsController.GetAllCompanyVecansyRegistationDetails();

            if (ddlDsDivision.SelectedValue != "")
            {
                if (ddlPositionType.SelectedValue != "")
                {
                    ddlCompanyVacancies.DataSource = companyVecansyRegistationDetailsList.Where(x => x.VDistrictId == Convert.ToInt32(ddlDistrict.SelectedValue) && x.VDsId == Convert.ToInt32(ddlDsDivision.SelectedValue) && x.JobPosition == ddlPositionType.SelectedItem.Text).ToList();

                }
                else
                {
                    ddlCompanyVacancies.DataSource = companyVecansyRegistationDetailsList.Where(x => x.VDistrictId == Convert.ToInt32(ddlDistrict.SelectedValue) && x.VDsId == Convert.ToInt32(ddlDsDivision.SelectedValue)).ToList();

                }
            }
            else if (ddlDistrict.SelectedValue != "")
            {
                if (ddlPositionType.SelectedValue != "")
                {
                    ddlCompanyVacancies.DataSource = companyVecansyRegistationDetailsList.Where(x => x.VDistrictId == Convert.ToInt32(ddlDistrict.SelectedValue) && x.JobPosition == ddlPositionType.SelectedItem.Text).ToList();

                }
                else
                {
                    ddlCompanyVacancies.DataSource = companyVecansyRegistationDetailsList.Where(x => x.VDistrictId == Convert.ToInt32(ddlDistrict.SelectedValue)).ToList();

                }

            }
            else
            {
                if (ddlPositionType.SelectedValue != "")
                {
                    ddlCompanyVacancies.DataSource = companyVecansyRegistationDetailsList.Where(x => x.JobPosition == ddlPositionType.SelectedItem.Text);

                }
                else
                {
                    ddlCompanyVacancies.DataSource = companyVecansyRegistationDetailsList;

                }
            }


            ddlCompanyVacancies.DataValueField = "CompanyVacansyRegistationDetailsId";
            ddlCompanyVacancies.DataTextField = "CompanyName";
            ddlCompanyVacancies.DataBind();
            ddlCompanyVacancies.Items.Insert(0, new ListItem("-- select vacancy --", ""));
        }

        private void BindVacanciePosition()
        {
            VacancyPositionController vacancyPositionController = ControllerFactory.CreateVacancyPositionController();
            List<VacancyPosition> listVacancy = new List<VacancyPosition>();

            listVacancy = vacancyPositionController.getVacancyPositionList();
            ddlPositionType.DataSource = listVacancy.Where(x => x.IsActive == 1);
            ddlPositionType.DataValueField = "Id";
            ddlPositionType.DataTextField = "VacancyPositionName";
            ddlPositionType.DataBind();
            ddlPositionType.Items.Insert(0, new ListItem("-- select Job Position --", ""));

        }

        protected void ddlPositionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindVacancies();
        }

        protected void BindJobcategory()
        {
            JobCategoryController jobCategoryController = ControllerFactory.CreateJobCategoryController();
            List<JobCategory> jobCategoriesList = jobCategoryController.GetAllJobCategory();

            ddlJobCategory.DataSource = jobCategoriesList;
            ddlJobCategory.DataValueField = "JobCategoryId";
            ddlJobCategory.DataTextField = "Title";
            ddlJobCategory.DataBind();
            ddlJobCategory.Items.Insert(0, new ListItem("-- select job category --", ""));
        }



        protected void BindJobGridView()
        {
            JobRefferalsController jobRefferalsController = ControllerFactory.CreateJobRefferalsController();
            List<JobRefferals> jobRefferalsList = jobRefferalsController.GetAllJobRefferals();

            jobRefferalsList = jobRefferalsList.Where(x => x.BeneficiaryId == Convert.ToInt32(BenficiaryId)).ToList();

            GridView3.DataSource = jobRefferalsList;
            GridView3.DataBind();
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int minID = int.Parse(GridView3.DataKeys[e.Row.RowIndex].Value.ToString());
                GridView gvPlanDetails = e.Row.FindControl("childgridView3") as GridView;

                //gvMIND.DataSource = ControllerFactory.CreateMinDetailControllerr().GetMinDetails(minID);
                List<JobPlacementFeedback> jobPlacementFeedbacksList = ControllerFactory.CreateJobPlacementFeedbackController().GetAllJobPlacementFeedback();
                jobPlacementFeedbacksList = jobPlacementFeedbacksList.Where(x => x.JobRefferalsId == minID).ToList();

                gvPlanDetails.DataSource = jobPlacementFeedbacksList;
                gvPlanDetails.DataBind();
            }
        }

        protected void childgridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView childgridView3 = gvRow.FindControl("childgridView3") as GridView;

            childgridView3.EditIndex = e.NewEditIndex;
            childgridView3.DataSource = ControllerFactory.CreateJobPlacementFeedbackController().GetAllJobPlacementFeedback();
            childgridView3.DataBind();
        }

        protected void childgridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView childgridView3 = gvRow.FindControl("childgridView3") as GridView;

            childgridView3.EditIndex = -1;

            childgridView3.DataSource = ControllerFactory.CreateJobPlacementFeedbackController().GetAllJobPlacementFeedback();
            childgridView3.DataBind();
        }

        protected void childgridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView childgridView3 = gvRow.FindControl("childgridView3") as GridView;

            Label id = childgridView3.Rows[e.RowIndex].FindControl("lblID") as Label;
            TextBox txtRemarks = childgridView3.Rows[e.RowIndex].FindControl("txtRemarks") as TextBox;
            RadioButtonList rbStillworking = childgridView3.Rows[e.RowIndex].FindControl("rbStillworking") as RadioButtonList;
            //TextBox city = GridView1.Rows[e.RowIndex].FindControl("txt_City") as TextBox;

            JobPlacementFeedbackController jobPlacementFeedbackController = ControllerFactory.CreateJobPlacementFeedbackController();
            JobPlacementFeedback jobPlacementFeedback = new JobPlacementFeedback();
            jobPlacementFeedback.StillWorking = Convert.ToInt32(rbStillworking.Text);
            jobPlacementFeedback.CreatedDate = DateTime.Now;
            jobPlacementFeedback.JobPlacementFeedbackId = Convert.ToInt32(id.Text);
            jobPlacementFeedback.Remarks = txtRemarks.Text;

            int response = jobPlacementFeedbackController.Update(jobPlacementFeedback);

            if (response != 0)
            {
                childgridView3.EditIndex = -1;

                childgridView3.DataSource = ControllerFactory.CreateJobPlacementFeedbackController().GetAllJobPlacementFeedback();
                childgridView3.DataBind();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success')", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);
            }
        }

        protected void btnAddFeedBackJob_Click(object sender, EventArgs e)
        {


            jobRefferals.Visible = false;
            jobFeedback.Visible = true;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            JobRefferalsController jobRefferalsController = ControllerFactory.CreateJobRefferalsController();
            List<JobRefferals> jobRefferalsList = jobRefferalsController.GetAllJobRefferals();

            CareerKeyTestResultsController careerKeyTestResultsController = ControllerFactory.CreateCareerKeyTestResultsController();
            List<CareerKeyTestResults> careerKeyTestResultsList = careerKeyTestResultsController.GetAllCareerKeyTestResults(false);

            ViewState["jobparentid"] = jobRefferalsList[rowIndex].JobRefferalsId;


        }

        protected void btnSubmitJobFeedback_Click(object sender, EventArgs e)
        {
            CareerGuidanceFeedbackController careerGuidanceFeedbackController = ControllerFactory.CreateCareerGuidanceFeedbackController();
            CareerGuidanceFeedback careerGuidanceFeedback = new CareerGuidanceFeedback();

            JobPlacementFeedbackController jobPlacementFeedbackController = ControllerFactory.CreateJobPlacementFeedbackController();

            JobPlacementFeedback jobPlacementFeedback = new JobPlacementFeedback();

            jobPlacementFeedback.Remarks = txtRemarksJob.Text;
            jobPlacementFeedback.JobRefferalsId = Convert.ToInt32(ViewState["jobparentid"]);
            jobPlacementFeedback.CreatedDate = DateTime.Now.Date;
            jobPlacementFeedback.ResignedDate = DateTime.Now.Date; // must changed here
            jobPlacementFeedback.CreatedUser = Session["Name"].ToString();
            jobPlacementFeedback.StillWorking = 1;
            jobPlacementFeedback.IsActive = 1;

            int output = jobPlacementFeedbackController.SaveJobPlacementFeedback(jobPlacementFeedback);
            if (output != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success')", true);
                JobRefferalClear();
                jobRefferals.Visible = true;
                jobFeedback.Visible = false;
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something went wrong!', 'error')", true);


            }
        }

        protected void ddlJobProgramPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlJobProgramPlan.SelectedValue != "")
            {
                lblJobProgramPlanDetails.Visible = true;

                ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
                ProgramPlan programPlanDetails = programPlanController.GetProgramPlanById(Convert.ToInt32(ddlJobProgramPlan.SelectedValue));
                lblJobProgramPlanDetails.Text = "Date :" + programPlanDetails.Date.ToShortDateString() + " Location : " + programPlanDetails.Location;
            }
            else
            {
                lblJobProgramPlanDetails.Visible = false;

            }
        }
        //----------------------------------------------------- End Job Refferal ---------------------------------------------------------------------------------------





        //----------------------------------------------------- Start Carrer Refferal ---------------------------------------------------------------------------------------
        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            CareerKeyTestResultsController careerKeyTestResultsController = ControllerFactory.CreateCareerKeyTestResultsController();
            careerKeyTestResults.R = Convert.ToInt32(txtR.Text);
            careerKeyTestResults.A = Convert.ToInt32(txtA.Text);
            careerKeyTestResults.E = Convert.ToInt32(txtE.Text);
            careerKeyTestResults.S = Convert.ToInt32(txtS.Text);
            careerKeyTestResults.C = Convert.ToInt32(txtC.Text);
            careerKeyTestResults.I = Convert.ToInt32(txtI.Text);
            careerKeyTestResults.Guidence = txtGuidance.Text;
            careerKeyTestResults.Date = DateTime.Today;
            careerKeyTestResults.HeldDate = DateTime.Parse(TxtHeldDate.Text).Date;
            careerKeyTestResults.CreatedUser = Session["Name"].ToString();
            careerKeyTestResults.BeneficiaryId = Convert.ToInt32(BenficiaryId);




            int response = careerKeyTestResultsController.Save(careerKeyTestResults);

            if (response != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success')", true);
                carrerTestClear();
                bindCarrierGrid();
            }
        }

        private void carrerTestClear()
        {
            txtR.Text = null;
            txtA.Text = null;
            txtE.Text = null;
            txtS.Text = null;
            txtC.Text = null;
            txtI.Text = null;
            txtGuidance.Text = null;
            TxtHeldDate.Text = null;
        }

        private void bindCarrierGrid()
        {
            CareerKeyTestResultsController careerKeyTestResultsController = ControllerFactory.CreateCareerKeyTestResultsController();
            List<CareerKeyTestResults> careerKeyTestResultsList = careerKeyTestResultsController.GetAllCareerKeyTestResults(false);

            careerKeyTestResultsList = careerKeyTestResultsList.Where(x => x.BeneficiaryId == Convert.ToInt32(BenficiaryId)).ToList();

            gvAnnaualPlan.DataSource = careerKeyTestResultsList;
            gvAnnaualPlan.DataBind();

        }
        protected void gvAnnaualPlan_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int minID = int.Parse(gvAnnaualPlan.DataKeys[e.Row.RowIndex].Value.ToString());
                GridView gvPlanDetails = e.Row.FindControl("gvPlanDetails") as GridView;

                //gvMIND.DataSource = ControllerFactory.CreateMinDetailControllerr().GetMinDetails(minID);
                List<CareerGuidanceFeedback> careerGuidanceFeedbacks = ControllerFactory.CreateCareerGuidanceFeedbackController().GetAllCareerKeyTestResults(false);
                careerGuidanceFeedbacks = careerGuidanceFeedbacks.Where(x => x.CareerKeyTestResultsId == minID).ToList();

                gvPlanDetails.DataSource = careerGuidanceFeedbacks;
                gvPlanDetails.DataBind();
            }
        }

        protected void gvPlanDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView gvPlanDetails = gvRow.FindControl("gvPlanDetails") as GridView;

            gvPlanDetails.EditIndex = e.NewEditIndex;
            gvPlanDetails.DataSource = ControllerFactory.CreateCareerGuidanceFeedbackController().GetAllCareerKeyTestResults(false);
            gvPlanDetails.DataBind();


        }

        protected void gvPlanDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView gvPlanDetails = gvRow.FindControl("gvPlanDetails") as GridView;

            gvPlanDetails.EditIndex = -1;

            gvPlanDetails.DataSource = ControllerFactory.CreateCareerGuidanceFeedbackController().GetAllCareerKeyTestResults(false);
            gvPlanDetails.DataBind();
        }

        protected void gvPlanDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView gvPlanDetails = gvRow.FindControl("gvPlanDetails") as GridView;

            Label id = gvPlanDetails.Rows[e.RowIndex].FindControl("lblID") as Label;
            TextBox txtInJob = gvPlanDetails.Rows[e.RowIndex].FindControl("txtInJob") as TextBox;
            //TextBox city = GridView1.Rows[e.RowIndex].FindControl("txt_City") as TextBox;

            CareerGuidanceFeedbackController careerGuidanceFeedbackController = ControllerFactory.CreateCareerGuidanceFeedbackController();
            CareerGuidanceFeedback careerGuidanceFeedback = new CareerGuidanceFeedback();
            careerGuidanceFeedback.InJob = txtInJob.Text;
            careerGuidanceFeedback.Date = DateTime.Now;
            careerGuidanceFeedback.Id = Convert.ToInt32(id.Text);

            int response = careerGuidanceFeedbackController.Update(careerGuidanceFeedback);

            if (response != 0)
            {
                gvPlanDetails.EditIndex = -1;

                gvPlanDetails.DataSource = ControllerFactory.CreateCareerGuidanceFeedbackController().GetAllCareerKeyTestResults(false);
                gvPlanDetails.DataBind();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success')", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);
            }




        }

        private void CareerRefferalFeedbackClear()
        {
            txtInJob.Text = null;
            txtRemarksFeedCareer.Text = null;
            txtParentId.Text = null;
            txtTraining.Text = null;
        }


        protected void ddlProgramPlanCarrerKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProgramPlanCarrerKey.SelectedValue != "")
            {
                lblProgramPlanDetails.Visible = true;

                ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
                ProgramPlan programPlanDetails = programPlanController.GetProgramPlanById(Convert.ToInt32(ddlProgramPlanCarrerKey.SelectedValue));
                lblProgramPlanDetails.Text = "Date :" + programPlanDetails.Date.ToShortDateString() + " Location : " + programPlanDetails.Location;
            }
            else
            {
                lblProgramPlanDetails.Visible = false;

            }

        }

        //----------------------------------------------------- End Carrer Refferal ---------------------------------------------------------------------------------------







        //----------------------------------------------------- start training Refferal ---------------------------------------------------------------------------------------

        protected void btn2Submit_Click(object sender, EventArgs e)
        {
            TrainingRefferalsController trainingRefferalsController = ControllerFactory.CreateTrainingRefferalController();

            TrainingRefferals trainingRefferals = new TrainingRefferals();

            trainingRefferals.BeneficiaryId = Convert.ToInt32(BenficiaryId);
            trainingRefferals.Date = DateTime.Now;
            trainingRefferals.InstituteName = institute.Text;
            trainingRefferals.TrainingCourse = course.Text;
            trainingRefferals.ContactPerson = contactPersonName.Text;
            trainingRefferals.ContactNo = contactNo.Text;
            trainingRefferals.RefferalsDate = DateTime.Parse(trainingRefferalDate.Text);
            trainingRefferals.CreatedUser = Session["Name"].ToString();

            int output = trainingRefferalsController.Save(trainingRefferals);

            if (output != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success')", true);
                TrainingRefferalClear();
                GridView2DataBind();
            }
        }

        private void TrainingRefferalClear()
        {
            institute.Text = null;
            course.Text = null;
            contactPersonName.Text = null;
            contactNo.Text = null;
            trainingRefferalDate.Text = null;
        }

        protected void btnAddCarrier_Click(object sender, EventArgs e)
        {
            string feedbackCarrier = txtFeedbackCarrier.Text;
            //  int id = int.Parse((sender as Button).CommandArgument);
        }

        protected void btnAddPlan_Click(object sender, EventArgs e)
        {

            //  ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#exampleModalCenter').modal('show');</script>", false);

            careerkey.Visible = false;
            careerkeyfeddback.Visible = true;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            CareerKeyTestResultsController careerKeyTestResultsController = ControllerFactory.CreateCareerKeyTestResultsController();
            List<CareerKeyTestResults> careerKeyTestResultsList = careerKeyTestResultsController.GetAllCareerKeyTestResults(false);

            int parentid = careerKeyTestResultsList[rowIndex].Id;
            txtParentId.Text = parentid.ToString();

        }

        protected void Button1Feed_Click(object sender, EventArgs e)
        {

            CareerGuidanceFeedbackController careerGuidanceFeedbackController = ControllerFactory.CreateCareerGuidanceFeedbackController();
            CareerGuidanceFeedback careerGuidanceFeedback = new CareerGuidanceFeedback();

            careerGuidanceFeedback.CareerKeyTestResultsId = Convert.ToInt32(txtParentId.Text);
            careerGuidanceFeedback.InJob = txtInJob.Text;
            careerGuidanceFeedback.InTraining = txtTraining.Text;
            careerGuidanceFeedback.Remarks = txtRemarksFeedCareer.Text;
            careerGuidanceFeedback.CreatedUser = Session["Name"].ToString();
            careerGuidanceFeedback.Date = DateTime.Today;
            int output = careerGuidanceFeedbackController.Save(careerGuidanceFeedback);
            if (output != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success')", true);
                CareerRefferalFeedbackClear();
                careerkey.Visible = true;
                careerkeyfeddback.Visible = false;
            }

        }

        protected void btnTrainingFeed_Click(object sender, EventArgs e)
        {
            TrainingRefferalFeedbackController trainingRefferalFeedbackController = ControllerFactory.CreateTrainingRefferalFeedbackController();
            TrainingRefferalFeedback trainingRefferalFeedback = new TrainingRefferalFeedback();

            trainingRefferalFeedback.TrainingRefferalId = Convert.ToInt32(txtTrainingId.Text);
            trainingRefferalFeedback.Date = DateTime.Today;
            trainingRefferalFeedback.TrainingInstitute = txtTrainingInstitute.Text;
            trainingRefferalFeedback.InTraining = txtInTraining.Text;
            trainingRefferalFeedback.TrainingCompleted = txtTrainingcompleted.Text;
            trainingRefferalFeedback.CreatedUser = Session["Name"].ToString();
            trainingRefferalFeedback.Remarks = txtTrainingRemark.Text;
            trainingRefferalFeedback.IsActive = 1;
            int output = trainingRefferalFeedbackController.Save(trainingRefferalFeedback);
            if (output != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success')", true);
                TrainingRefferalFeedbackClear();
                GridView2DataBind();
                trainingDiv.Visible = true;
                trainingDivFeedback.Visible = false;
            }
        }

        private void TrainingRefferalFeedbackClear()
        {
            txtTrainingInstitute.Text = null;
            txtInTraining.Text = null;
            txtTrainingcompleted.Text = null;
            txtTrainingRemark.Text = null;
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int minID = int.Parse(GridView2.DataKeys[e.Row.RowIndex].Value.ToString());
                GridView ChildGridView2 = e.Row.FindControl("ChildGridView2") as GridView;

                //gvMIND.DataSource = ControllerFactory.CreateMinDetailControllerr().GetMinDetails(minID);
                List<TrainingRefferalFeedback> trainingRefferalFeedbacks = ControllerFactory.CreateTrainingRefferalFeedbackController().GetAllTrainingRefferalFeedback(false);
                trainingRefferalFeedbacks = trainingRefferalFeedbacks.Where(x => x.TrainingRefferalId == minID).ToList();

                ChildGridView2.DataSource = trainingRefferalFeedbacks;
                ChildGridView2.DataBind();
            }
        }

        public void GridView2DataBind()
        {
            TrainingRefferalsController trainingRefferalsController = ControllerFactory.CreateTrainingRefferalController();
            List<TrainingRefferals> trainingRefferalsList = trainingRefferalsController.GetAllTrainingRefferals(false);

            trainingRefferalsList = trainingRefferalsList.Where(x => x.BeneficiaryId == Convert.ToInt32(BenficiaryId)).ToList();

            GridView2.DataSource = trainingRefferalsList;
            GridView2.DataBind();
        }

        protected void btnAddTrainingFeedback_Click(object sender, EventArgs e)
        {
            trainingDiv.Visible = false;
            trainingDivFeedback.Visible = true;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            TrainingRefferalsController trainingRefferalsController = ControllerFactory.CreateTrainingRefferalController();
            List<TrainingRefferals> trainingRefferalsList = trainingRefferalsController.GetAllTrainingRefferals(false);

            int parentid = trainingRefferalsList[rowIndex].Id;
            txtTrainingId.Text = parentid.ToString();
        }

        protected void ddlTrainningProgramplan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTrainningProgramplan.SelectedValue != "")
            {
                lblTrainningProgramDetails.Visible = true;

                ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
                ProgramPlan programPlanDetails = programPlanController.GetProgramPlanById(Convert.ToInt32(ddlTrainningProgramplan.SelectedValue));
                lblTrainningProgramDetails.Text = "Date :" + programPlanDetails.Date.ToShortDateString() + " Location : " + programPlanDetails.Location;
            }
            else
            {
                lblTrainningProgramDetails.Visible = false;

            }
        }

        protected void ChildGridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView ChildGridView2 = gvRow.FindControl("ChildGridView2") as GridView;

            ChildGridView2.EditIndex = -1;

            ChildGridView2.DataSource = ControllerFactory.CreateTrainingRefferalFeedbackController().GetAllTrainingRefferalFeedback(false);
            ChildGridView2.DataBind();
        }

        protected void ChildGridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView gvPlanDetails = gvRow.FindControl("ChildGridView2") as GridView;

            Label id = gvPlanDetails.Rows[e.RowIndex].FindControl("lblID") as Label;
            TextBox txtTrainingInstitute = gvPlanDetails.Rows[e.RowIndex].FindControl("txtTrainingInstitute") as TextBox;
            TextBox InTraining = gvPlanDetails.Rows[e.RowIndex].FindControl("txtInTraining") as TextBox;
            TextBox TrainingCompleted = gvPlanDetails.Rows[e.RowIndex].FindControl("txtTrainingCompleted") as TextBox;
            TextBox Remarks = gvPlanDetails.Rows[e.RowIndex].FindControl("txtRemarks") as TextBox;
            //TextBox city = GridView1.Rows[e.RowIndex].FindControl("txt_City") as TextBox;



            TrainingRefferalFeedbackController trainingRefferalFeedbackController = ControllerFactory.CreateTrainingRefferalFeedbackController();
            TrainingRefferalFeedback trainingRefferalFeedback = new TrainingRefferalFeedback();
            trainingRefferalFeedback.Date = DateTime.Now;
            trainingRefferalFeedback.Id = Convert.ToInt32(id.Text);
            trainingRefferalFeedback.TrainingInstitute = txtTrainingInstitute.Text;
            trainingRefferalFeedback.InTraining = InTraining.Text;
            trainingRefferalFeedback.TrainingCompleted = TrainingCompleted.Text;
            trainingRefferalFeedback.Remarks = Remarks.Text;
            trainingRefferalFeedback.CreatedUser = Session["Name"].ToString();


            int response = trainingRefferalFeedbackController.Update(trainingRefferalFeedback);

            if (response != 0)
            {
                gvPlanDetails.EditIndex = -1;

                gvPlanDetails.DataSource = ControllerFactory.CreateTrainingRefferalFeedbackController().GetAllTrainingRefferalFeedback(false);
                gvPlanDetails.DataBind();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success')", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);
            }
        }

        protected void ChildGridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView ChildGridView2 = gvRow.FindControl("ChildGridView2") as GridView;

            ChildGridView2.EditIndex = e.NewEditIndex;
            ChildGridView2.DataSource = ControllerFactory.CreateTrainingRefferalFeedbackController().GetAllTrainingRefferalFeedback(false);
            ChildGridView2.DataBind();
        }




        //protected void btnAddPlan_Click(object sender, EventArgs e)
        //{
        //    int id = int.Parse((sender as Button).CommandArgument);

        //    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);

        //    int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
        //}



        //----------------------------------------------------- End training Refferal ---------------------------------------------------------------------------------------




    }
}