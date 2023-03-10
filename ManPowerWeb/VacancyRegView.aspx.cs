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
    public partial class VacancyRegView : System.Web.UI.Page
    {
        List<CompanyVecansyRegistationDetails> cc = new List<CompanyVecansyRegistationDetails>();
        List<CompanyVecansyRegistationDetails> obj = new List<CompanyVecansyRegistationDetails>();
        //CompanyVecansyRegistationDetails obj = new CompanyVecansyRegistationDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            CompanyVecansyRegistationDetails companyVecansyRegistationDetails = new CompanyVecansyRegistationDetails();
            CompanyVecansyRegistationDetailsController companyVecansyRegistationDetailsController = ControllerFactory.CreateCompanyVecansyRegistationDetailsController();

            cc = companyVecansyRegistationDetailsController.GetAllCompanyVecansyRegistationDetails();

            string id = Request.QueryString["id"];

            foreach (var i in cc.Where(u => u.CompanyVacansyRegistationDetailsId == int.Parse(id)))
            {
                date.Text = i.VDate.ToString();
                address.Text = i.VAddress;
                link.Text = i.WebSiteLink;
                regNo.Text = i.BusinessRegistationNumber;
                vanacnyType.Text = i.JobPosition;
                salary.Text = i.SalaryLevel;
                NoOfVacancy.Text = i.NumberOfVacancy.ToString();
                name.Text = i.ContactPersonName;
                position.Text = i.ContactPersonPosition;
                contact.Text = i.ContactNumber;
                whatsapp.Text = i.WhatsappNumber;
                email.Text = i.ContactPersonEmail;
                highestPsition.Text = i.CareerPath;
                level.Text = i.VLevels;
            }

        }
        protected void isClicked(object sender, EventArgs e)
        {
            Response.Redirect("VacancyRegSearch.aspx");
        }
    }
}