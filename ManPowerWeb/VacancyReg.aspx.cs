using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ManPowerWeb
{
    public partial class VacancyReg : System.Web.UI.Page
    {
        string[] career = { "Management", "Skilled", "Non-Skilled", "Technical", "Non-Technical" };
        string[] levelsDD = { "Top Level", "Middle Level", "Lower Level" };
        List<CompanyVecansyRegistationDetails> list = new List<CompanyVecansyRegistationDetails>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataSource();
            }
        }

        private void BindDataSource()
        {
            ddlPositions.DataSource = career;
            ddlPositions.DataBind();

            ddlLevel.DataSource = levelsDD;
            ddlLevel.DataBind();
        }


    protected void btnSave_Click(object sender, EventArgs e)
        {
            CompanyVecansyRegistationDetails companyVecansyRegistationDetails = new CompanyVecansyRegistationDetails();
            CompanyVecansyRegistationDetailsController companyVecansyRegistationDetailsController = ControllerFactory.CreateCompanyVecansyRegistationDetailsController();
     
            companyVecansyRegistationDetails.VDate = Convert.ToDateTime(date.Text);
            companyVecansyRegistationDetails.VAddress = address.Text;
            companyVecansyRegistationDetails.WebSiteLink = link.Text;
            companyVecansyRegistationDetails.BusinessRegistationNumber = regNo.Text;
            companyVecansyRegistationDetails.JobPosition = position.Text;
            companyVecansyRegistationDetails.CareerPath = ddlPositions.SelectedValue;
            companyVecansyRegistationDetails.SalaryLevel = salary.Text;
            companyVecansyRegistationDetails.NumberOfVacancy = int.Parse(NoOfVacancy.Text);
            companyVecansyRegistationDetails.ContactPersonName = name.Text;
            companyVecansyRegistationDetails.ContactPersonPosition = position.Text;
            companyVecansyRegistationDetails.ContactNumber = contact.Text;
            companyVecansyRegistationDetails.WhatsappNumber = whatsapp.Text;
            companyVecansyRegistationDetails.VLevels = ddlLevel.SelectedValue;
            companyVecansyRegistationDetails.ContactPersonEmail = email.Text;


            int result1 = companyVecansyRegistationDetailsController.SaveCompanyVecansyRegistationDetails(companyVecansyRegistationDetails);

            if (result1 == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Added Succesfully!', 'success');window.setTimeout(function(){window.location='VacancyReg.aspx'},2500);", true);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            date.Text = null;
            address.Text = null;
            link.Text = null;
            regNo.Text = null;
            position.Text = null;
            salary.Text = null;
            NoOfVacancy.Text = null;
            name.Text = null;
            position.Text = null;
            contact.Text = null;
            whatsapp.Text = null;
            email.Text = null;
            position.Text = null;
        }

        protected void isClicked(object sender, EventArgs e)
        {
            Response.Redirect("VacancyRegSearch.aspx");
        }
    }
}