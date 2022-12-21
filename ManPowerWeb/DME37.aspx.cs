using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class DME37 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            CompanyVecansyRegistationDetails companyVecansyRegistationDetails = new CompanyVecansyRegistationDetails();
            CompanyVecansyRegistationDetailsController companyVecansyRegistationDetailsController = ControllerFactory.CreateCompanyVecansyRegistationDetailsController();


            companyVecansyRegistationDetails.CompanyVacansyRegistationDetailsId = 1;
            companyVecansyRegistationDetails.VDate = DateTime.Today;
            companyVecansyRegistationDetails.VAddress = txtAddress.Text;
            companyVecansyRegistationDetails.WebSiteLink = txtWebSite.Text;
            companyVecansyRegistationDetails.BusinessRegistationNumber = txtRegNo.Text;
            companyVecansyRegistationDetails.JobPosition = txtVacancyType.Text;
            companyVecansyRegistationDetails.CareerPath = ddlCareerPath.Text;
            companyVecansyRegistationDetails.SalaryLevel = txtSalaryLevel.Text;
            companyVecansyRegistationDetails.NumberOfVacancy = Convert.ToInt32(txtNumberOfVacancies.Text);
            companyVecansyRegistationDetails.ContactPersonName = txtName.Text;
            companyVecansyRegistationDetails.ContactPersonPosition = txtPosition.Text;
            companyVecansyRegistationDetails.ContactNumber = txtContact.Text;
            companyVecansyRegistationDetails.WhatsappNumber = txtWhatsapp.Text;
            companyVecansyRegistationDetails.VLevels = ddlLevel.Text;
            companyVecansyRegistationDetails.ContactPersonEmail = txtEmail.Text;


            companyVecansyRegistationDetailsController.SaveCompanyVecansyRegistationDetails(companyVecansyRegistationDetails);

            //give a alert here

            Response.Redirect("DME37Search.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DME37Search.aspx");
        }
    }
}