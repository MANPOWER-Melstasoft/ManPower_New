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
    public partial class DME37Search : System.Web.UI.Page
    {
        List<CompanyVecansyRegistationDetails> comapnyVacancyReg = new List<CompanyVecansyRegistationDetails>();
        List<CompanyVecansyRegistationDetails> comapnyVacancyRegListState = new List<CompanyVecansyRegistationDetails>();
        bool isClicked = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataSource();

            }
        }

        private void BindDataSource()
        {
            CompanyVecansyRegistationDetails companyVecansyRegistationDetails = new CompanyVecansyRegistationDetails();
            CompanyVecansyRegistationDetailsController companyVecansyRegistationDetailsController = ControllerFactory.CreateCompanyVecansyRegistationDetailsController();

            comapnyVacancyReg = companyVecansyRegistationDetailsController.GetAllCompanyVecansyRegistationDetails();
            ViewState["comapnyVacancyRegList"] = comapnyVacancyReg;
            gv1.DataSource = comapnyVacancyReg;
            gv1.DataBind();


        }

        protected void btnAddVacancy_Click(object sender, EventArgs e)
        {
            Response.Redirect("DME37.aspx");
        }

        protected void gv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv1.PageIndex = e.NewPageIndex;
            if (isClicked == true)
            {
                bindDataSerach();
                isClicked = false;

            }
            else
            {
                BindDataSource();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            isClicked = true;
            bindDataSerach();


        }
        private void bindDataSerach()
        {
            comapnyVacancyRegListState = (List<CompanyVecansyRegistationDetails>)ViewState["comapnyVacancyRegList"];

            gv1.DataSource = comapnyVacancyRegListState.Where(u => u.VDate.Year.ToString() == ddlYear.SelectedValue && u.VDate.Month.ToString() == ddlMonth.SelectedValue).ToList();
            gv1.DataBind();
        }
    }
}