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
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataSource();
        }

        private void BindDataSource()
        {
            CompanyVecansyRegistationDetails companyVecansyRegistationDetails = new CompanyVecansyRegistationDetails();
            CompanyVecansyRegistationDetailsController companyVecansyRegistationDetailsController = ControllerFactory.CreateCompanyVecansyRegistationDetailsController();

            comapnyVacancyReg = companyVecansyRegistationDetailsController.GetAllCompanyVecansyRegistationDetails();
            gv1.DataSource = comapnyVacancyReg;
            gv1.DataBind();


        }

        protected void btnAddVacancy_Click(object sender, EventArgs e)
        {
            Response.Redirect("DME37.aspx");
        }
    }
}