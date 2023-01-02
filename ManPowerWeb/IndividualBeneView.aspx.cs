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

        protected void Page_Load(object sender, EventArgs e)
        {
            InduvidualBeneficiaryController beneficiaryController = ControllerFactory.CreateInduvidualBeneficiaryController();
            beneficiaries = beneficiaryController.GetAllInduvidualBeneficiary();

            string id = Request.QueryString["id"];

            foreach (var i in beneficiaries.Where(u => u.BeneficiaryId == int.Parse(id)))
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

        protected void isClicked(object sender, EventArgs e)
        {
            Response.Redirect("IndividualBeneSearch.aspx");
        }
    }
}