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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVacancies();
                BindJobcategory();
                BindJobGridView();
                bindCarrierGrid();

                InduvidualBeneficiaryController beneficiaryController = ControllerFactory.CreateInduvidualBeneficiaryController();
                beneficiaries = beneficiaryController.GetAllInduvidualBeneficiary();

                BenficiaryId = Request.QueryString["id"];

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



        //-----------------------------------------------------Start Job Refferal ---------------------------------------------------------------------------------------

        protected void submitJobRefferal(object sender, EventArgs e)
        {
            JobRefferalsController jobRefferalsController = ControllerFactory.CreateJobRefferalsController();

            JobRefferals jobRefferals = new JobRefferals
            {
                BeneficiaryId = Convert.ToInt32(BenficiaryId),
                VacancyRegistrationId = Convert.ToInt32(ddlCompanyVacancies.SelectedValue.ToString()),
                JobCategoryId = Convert.ToInt32(ddlJobCategory.SelectedValue.ToString()),
                CereatedDate = DateTime.Today,
                JobPlacementDate = DateTime.Parse(jobPlacememntDate.Text).Date,
                RefferalsDate = DateTime.Parse(jobRefferalsDate.Text).Date,
                RefferalRemarks = jobRefferalRemark.Text,
                CareerGuidance = careerGuidance.Text,
                CreatedUser = Session["Name"].ToString(),

            };

            int output = jobRefferalsController.SaveJobRefferals(jobRefferals);
            if (output != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success')", true);
                JobRefferal();
            }
        }

        private void JobRefferal()
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

            ddlCompanyVacancies.DataSource = companyVecansyRegistationDetailsList;
            ddlCompanyVacancies.DataValueField = "CompanyVacansyRegistationDetailsId";
            ddlCompanyVacancies.DataTextField = "JobDispalyName";
            ddlCompanyVacancies.DataBind();
            ddlCompanyVacancies.Items.Insert(0, new ListItem("-- select vacancy --", ""));
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvJob.PageIndex = e.NewPageIndex;
            BindJobGridView();

        }

        protected void BindJobGridView()
        {
            JobRefferalsController jobRefferalsController = ControllerFactory.CreateJobRefferalsController();
            List<JobRefferals> jobRefferalsList = jobRefferalsController.GetAllJobRefferals();

            gvJob.DataSource = jobRefferalsList;
            gvJob.DataBind();
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


        protected void gvAnnaualPlan_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int minID = int.Parse(gvAnnaualPlan.DataKeys[e.Row.RowIndex].Value.ToString());
                GridView gvPlanDetails = e.Row.FindControl("gvPlanDetails") as GridView;

                //gvMIND.DataSource = ControllerFactory.CreateMinDetailControllerr().GetMinDetails(minID);
                gvPlanDetails.DataSource = ControllerFactory.CreateCareerGuidanceFeedbackController().GetAllCareerKeyTestResults(false);
                gvPlanDetails.DataBind();
            }
        }

        protected void gvPlanDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView gvPlanDetails = gvRow.FindControl("gvPlanDetails") as GridView;

            gvPlanDetails.EditIndex = e.NewEditIndex;
            gvPlanDetails.DataSource = ControllerFactory.CreateCareerKeyTestResultsController().GetAllCareerKeyTestResults(false);
            gvPlanDetails.DataBind();


        }

        protected void gvPlanDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView gvPlanDetails = gvRow.FindControl("gvPlanDetails") as GridView;

            gvPlanDetails.EditIndex = -1;

            gvPlanDetails.DataSource = ControllerFactory.CreateCareerKeyTestResultsController().GetAllCareerKeyTestResults(false);
            gvPlanDetails.DataBind();
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

        private void bindCarrierGrid()
        {
            CareerKeyTestResultsController careerKeyTestResultsController = ControllerFactory.CreateCareerKeyTestResultsController();
            List<CareerKeyTestResults> careerKeyTestResultsList = careerKeyTestResultsController.GetAllCareerKeyTestResults(false);

            gvAnnaualPlan.DataSource = careerKeyTestResultsList;
            gvAnnaualPlan.DataBind();

        }


        protected void btnAddCarrier_Click(object sender, EventArgs e)
        {
            string feedbackCarrier = txtFeedbackCarrier.Text;
            //  int id = int.Parse((sender as Button).CommandArgument);
        }

        protected void btnAddPlan_Click(object sender, EventArgs e)
        {

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

        private void CareerRefferalFeedbackClear()
        {
            txtInJob.Text = null;
            txtRemarksFeedCareer.Text = null;
            txtParentId.Text = null;
            txtTraining.Text = null;
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