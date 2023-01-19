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
                CereatedDate = DateTime.Now,
                //JobPlacementDate = jobPlacememntDate.ToString(),
                //RefferalsDate = jobRefferalsDate.ToString(),
                RefferalRemarks = jobRefferalRemark.Text,
                CareerGuidance = careerGuidance.Text,
            };

            jobRefferalsController.SaveJobRefferals(jobRefferals);
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
            careerKeyTestResults.HeldDate = DateTime.Parse(TxtHeldDate.Text).Date;

            int response = careerKeyTestResultsController.Save(careerKeyTestResults);

            if (response != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success')", true);
                carrerTestClear();
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



        //----------------------------------------------------- End Carrer Refferal ---------------------------------------------------------------------------------------

        //----------------------------------------------------- start training Refferal ---------------------------------------------------------------------------------------

        protected void btn2Submit_Click(object sender, EventArgs e)
        {
            TrainingRefferalsController trainingRefferalsController = ControllerFactory.CreateTrainingRefferalController();

            TrainingRefferals trainingRefferals = new TrainingRefferals
            {
                BeneficiaryId = Convert.ToInt32(BenficiaryId),
                Date = DateTime.Now,
                InstituteName = institute.Text,
                TrainingCourse = course.Text,
                ContactPerson = contactPersonName.Text,
                ContactNo = contactNo.Text,
                RefferalsDate = Convert.ToDateTime(trainingRefferalDate),

            };

            trainingRefferalsController.Save(trainingRefferals);
        }



        //----------------------------------------------------- start training Refferal ---------------------------------------------------------------------------------------

    }
}