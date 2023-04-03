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
        List<DepartmentUnit> listDistrict = new List<DepartmentUnit>();
        List<DepartmentUnit> listDSDivision = new List<DepartmentUnit>();



        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                BindDataSource();
                ddlDsDivision.Enabled = false;
                ddlDistrict.Enabled = false;
                bindVacancyType();

            }
        }

        private void BindDataSource()
        {
            ddlPositions.DataSource = career;
            ddlPositions.DataBind();

            ddlLevel.DataSource = levelsDD;
            ddlLevel.DataBind();
        }

        private void bindVacancyType()
        {
            VacancyPositionController vacancyPositionController = ControllerFactory.CreateVacancyPositionController();
            List<VacancyPosition> listVacancy = new List<VacancyPosition>();

            listVacancy = vacancyPositionController.getVacancyPositionList();
            ddlvanacnyType.DataSource = listVacancy.Where(x => x.IsActive == 1);
            ddlvanacnyType.DataValueField = "Id";
            ddlvanacnyType.DataTextField = "VacancyPositionName";
            ddlvanacnyType.DataBind();
            ddlvanacnyType.Items.Insert(0, new ListItem("Select Job Position", ""));

        }

        protected void rbDepartmentLocationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbDepartmentLocationType.SelectedValue == "1")
            {
                BindDistrict();
                ddlDistrict.Enabled = true;
                ddlDsDivision.Enabled = false;
            }
            if (rbDepartmentLocationType.SelectedValue == "2")
            {
                BindDistrict();
                ddlDsDivision.Enabled = true;
                ddlDistrict.Enabled = true;

            }
            if (rbDepartmentLocationType.SelectedValue == "3")
            {
                ddlDsDivision.Enabled = false;
                ddlDistrict.Enabled = false;
            }

        }
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbDepartmentLocationType.SelectedValue == "2")
            {
                BindDSDivision();
            }
            else
            {
                ddlDsDivision.Items.Clear();

            }


        }
        private void BindDistrict()
        {
            DepartmentUnitTypeController _DepartmentUnitTypeController = ControllerFactory.CreateDepartmentUnitTypeController();
            listDistrict = _DepartmentUnitTypeController.GetDepartmentUnitType(2, true)._DepartmentUnit;
            ddlDistrict.DataSource = listDistrict;
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataValueField = "DepartmentUnitId";

            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("Select District", ""));
        }

        private void BindDSDivision()
        {
            DepartmentUnitTypeController _DepartmentUnitTypeController = ControllerFactory.CreateDepartmentUnitTypeController();
            listDSDivision = _DepartmentUnitTypeController.GetDepartmentUnitType(3, true)._DepartmentUnit;

            if (ddlDistrict.SelectedValue != "")
            {
                ddlDsDivision.DataSource = listDSDivision.Where(u => u.ParentId.ToString() == ddlDistrict.SelectedValue);
                ddlDsDivision.DataTextField = "Name";
                ddlDsDivision.DataValueField = "DepartmentUnitId";
                ddlDsDivision.DataBind();
                ddlDsDivision.Items.Insert(0, new ListItem("Select Division", ""));

            }
            else
            {
                ddlDsDivision.Items.Clear();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            CompanyVecansyRegistationDetails companyVecansyRegistationDetails = new CompanyVecansyRegistationDetails();
            CompanyVecansyRegistationDetailsController companyVecansyRegistationDetailsController = ControllerFactory.CreateCompanyVecansyRegistationDetailsController();

            companyVecansyRegistationDetails.VDate = Convert.ToDateTime(date.Text);
            companyVecansyRegistationDetails.VAddress = address.Text;
            companyVecansyRegistationDetails.WebSiteLink = link.Text;
            companyVecansyRegistationDetails.BusinessRegistationNumber = regNo.Text;
            companyVecansyRegistationDetails.JobPosition = ddlvanacnyType.SelectedItem.Text;
            companyVecansyRegistationDetails.CareerPath = ddlPositions.SelectedValue;
            companyVecansyRegistationDetails.SalaryLevel = salary.Text;
            companyVecansyRegistationDetails.NumberOfVacancy = int.Parse(NoOfVacancy.Text);
            companyVecansyRegistationDetails.ContactPersonName = name.Text;
            companyVecansyRegistationDetails.ContactPersonPosition = position.Text;
            companyVecansyRegistationDetails.ContactNumber = contact.Text;
            companyVecansyRegistationDetails.WhatsappNumber = whatsapp.Text;
            companyVecansyRegistationDetails.VLevels = ddlLevel.SelectedValue;
            companyVecansyRegistationDetails.ContactPersonEmail = email.Text;

            if (rbDepartmentLocationType.SelectedValue == "2")
            {
                if (ddlDsDivision.SelectedValue != "")
                {
                    companyVecansyRegistationDetails.VDsId = Convert.ToInt32(ddlDsDivision.SelectedValue);

                }
                else
                {
                    companyVecansyRegistationDetails.VDistrictId = 0;
                }
            }

            if (rbDepartmentLocationType.SelectedValue == "1")
            {
                companyVecansyRegistationDetails.VDistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
            }

            if (rbDepartmentLocationType.SelectedValue == "3")
            {
                companyVecansyRegistationDetails.VDsId = 0;
                companyVecansyRegistationDetails.VDistrictId = 0;
            }


            companyVecansyRegistationDetails.CompanyName = txtName.Text;


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