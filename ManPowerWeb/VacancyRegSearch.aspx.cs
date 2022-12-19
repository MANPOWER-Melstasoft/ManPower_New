using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class VacancyRegSearch : System.Web.UI.Page
    {
        int currentYear = DateTime.Today.Year;
        string[] career = { "Management", "Skilled", "Non-Skilled", "Technical", "Non-Technical" };
        int[] year = { DateTime.Today.Year, (DateTime.Today.Year + 1), (DateTime.Today.Year + 2 )};

        List<CompanyVecansyRegistationDetails> cc = new List<CompanyVecansyRegistationDetails>();
        List<CompanyVecansyRegistationDetails> newList = new List<CompanyVecansyRegistationDetails>();

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

            cc = companyVecansyRegistationDetailsController.GetAllCompanyVecansyRegistationDetails();

            ViewState["cc"] = cc;
            GridView1.DataSource = cc;
            GridView1.DataBind();

            ddlYear.DataSource = year; 
            ddlYear.DataBind();

            ddlPosition.DataSource = career;
            ddlPosition.DataBind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            cc = (List<CompanyVecansyRegistationDetails>)ViewState["cc"];
            GridView1.DataSource = cc.Where(u => u.CareerPath == ddlPosition.SelectedValue && u.VDate.Year == int.Parse(ddlYear.SelectedValue));
            GridView1.DataBind();
        }

        protected void isClicked(object sender, EventArgs e)
        {
            Response.Redirect("VacancyReg.aspx");
        }

        protected void viewDetails(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = (GridViewRow)((LinkButton)sender).NamingContainer;
            int index = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            string url = "VacancyRegView.aspx?" + "id=" +cc[index].CompanyVacansyRegistationDetailsId;
            Response.Redirect(url);
        }
    }
}