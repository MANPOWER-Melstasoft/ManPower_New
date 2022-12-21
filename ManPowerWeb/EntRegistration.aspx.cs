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
    public partial class EntRegistration : System.Web.UI.Page
    {
        string[] loan = { "Yes", "No" };
        List<BusinessType> business = new List<BusinessType>();
        List<MarketType> mType = new List<MarketType>();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataSource();
            }
        }

        private void BindDataSource()
        {
            BusinessTypeController businessTypeController = ControllerFactory.CreateBusinessTypeController();
            business = businessTypeController.GetAllBusinessType();

            MarketTypeController marketTypeController = ControllerFactory.CreateMarketTypeController();
            mType = marketTypeController.GetAllMarketType();

            businessType.DataSource = business;
            businessType.DataValueField = "BusinessTypeId";
            businessType.DataTextField = "BusinessTypeName";
            businessType.DataBind();

            marketType.DataSource = mType;
            marketType.DataValueField = "MarketTypeId";
            marketType.DataTextField = "MarketTypeName";
            marketType.DataBind();

            bankLoan.DataSource = loan;
            bankLoan.DataBind();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            EntrepreneurController entrepreneurctrl = ControllerFactory.CreateEntrepreneurController();
            Entrepreneur entrepreneur = new Entrepreneur();

            entrepreneur.MarketTypeId = int.Parse(marketType.SelectedValue);
            entrepreneur.BusinessTypeId = int.Parse(businessType.SelectedValue);
            entrepreneur.NatureOfBusiness = nature.Text;
            entrepreneur.BusinessStartDate = Convert.ToDateTime(sDate.Text);
            entrepreneur.AvgMonthlyIncome = double.Parse(income.Text);
            entrepreneur.NumberOfWorkers = int.Parse(workers.Text);
            entrepreneur.District = "";
            entrepreneur.DivisionalSecretery = "";
            entrepreneur.ContactNumber = int.Parse(contact.Text);
            entrepreneur.EntEmail = email.Text;
            entrepreneur.EntBrn = regNo.Text;

            int result1 = entrepreneurctrl.SaveEntrepreneur(entrepreneur);

            if (result1 == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Something went wrong');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Added Succesfully');", true);
                nature.Text = "";
                sDate.Text = "";
                income.Text = "";
                workers.Text = "";
                contact.Text = "";
                email.Text = "";
                regNo.Text = "";
                district.Text = "";
                ds.Text = "";
                date.Text = "";
                fType.Text = "";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            nature.Text = "";
            sDate.Text = "";
            income.Text = "";
            workers.Text = "";
            contact.Text = "";
            email.Text = "";
            regNo.Text = "";
            district.Text = "";
            ds.Text = "";
            date.Text = "";
            fType.Text = "";
        }
    }
}