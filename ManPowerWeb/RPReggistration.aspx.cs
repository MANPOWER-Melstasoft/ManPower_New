using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class RPReggistration : System.Web.UI.Page
    {
        string[] gen = { "Male", "Female" };
        string[] scl = { "School", "Non School" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataSource();
            }
        }

        private void BindDataSource()
        {
            ddl1.DataSource = gen;
            ddl1.DataBind();

            ddl2.DataSource = scl;
            ddl2.DataBind();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            InduvidualBeneficiaryController induvidualBeneficiaryController = ControllerFactory.CreateInduvidualBeneficiaryController();
            InduvidualBeneficiary induvidualBeneficiary = new InduvidualBeneficiary();

            induvidualBeneficiary.BeneficiaryTypeId = 1;
            induvidualBeneficiary.District = "";
            induvidualBeneficiary.DivisionalSecretery = "";
            induvidualBeneficiary.BeneficiaryNic = nic.Text;
            induvidualBeneficiary.InduvidualBeneficiaryName = name.Text;
            induvidualBeneficiary.BeneficiaryGender = ddl1.SelectedItem.Text;
            induvidualBeneficiary.DateOfBirth = Convert.ToDateTime(dob.Text);
            induvidualBeneficiary.PersonalAddress = address.Text;
            induvidualBeneficiary.SchoolName = sclName.Text;
            induvidualBeneficiary.AddressOfSchool = sclAddress.Text;
            induvidualBeneficiary.SchoolGrade = grade.Text;
            induvidualBeneficiary.ParentNic = parentNic.Text;
            induvidualBeneficiary.BeneficiaryEmail = email.Text;
            induvidualBeneficiary.JobPreference = jobType.Text;
            induvidualBeneficiary.ContactNumber = contact.Text;
            induvidualBeneficiary.WhatsappNumber = whatsapp.Text;

            int result1 = induvidualBeneficiaryController.SaveInduvidualBeneficiary(induvidualBeneficiary);

            if (result1 == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Something went wrong');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Added Succesfully');", true);
                nic.Text = "";
                name.Text = "";
                dob.Text = "";
                address.Text = "";
                sclName.Text = "";
                sclAddress.Text = "";
                grade.Text = "";
                parentNic.Text = "";
                email.Text = "";
                jobType.Text = "";
                contact.Text = "";
                whatsapp.Text = "";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            nic.Text = "";
            name.Text = "";
            dob.Text = "";
            address.Text = "";
            sclName.Text = "";
            sclAddress.Text = "";
            grade.Text = "";
            parentNic.Text = "";
            email.Text = "";
            jobType.Text = "";
            contact.Text = "";
            whatsapp.Text = "";
        }
    }
}