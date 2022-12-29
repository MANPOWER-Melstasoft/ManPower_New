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
    public partial class EntView : System.Web.UI.Page
    {
        List<Entrepreneur> entrepreneurs = new List<Entrepreneur>();

        protected void Page_Load(object sender, EventArgs e)
        {
            EntrepreneurController entrepreneurctrl = ControllerFactory.CreateEntrepreneurController();
            entrepreneurs = entrepreneurctrl.GetAllEntrepreneur();
            string id = Request.QueryString["id"];

            foreach (var i in entrepreneurs.Where(u => u.BenificiaryId == int.Parse(id)))
            {
                regNo.Text = i.EntBrn;
                contact.Text = i.ContactNumber.ToString();
                email.Text = i.EntEmail;
                nature.Text = i.NatureOfBusiness;
                sDate.Text = i.BusinessStartDate.ToString();
                income.Text = i.AvgMonthlyIncome.ToString();
                workers.Text = i.NumberOfWorkers.ToString();
                district.Text = i.District;
                ds.Text = i.DivisionalSecretery;
                
                if(i.MarketTypeId == 1)
                {
                    marketType.Text = "Local";
                }
                else if (i.MarketTypeId == 2)
                {
                    marketType.Text = "Foreign";
                }
                else if (i.MarketTypeId == 3)
                {
                    marketType.Text = "Local & Foreign";
                }



                if (i.BusinessTypeId == 1)
                {
                    businessType.Text = "Agriculture";
                }
                else if (i.BusinessTypeId == 2)
                {
                    businessType.Text = "Poduction";
                }
                else if (i.BusinessTypeId == 3)
                {
                    businessType.Text = "Service";
                }


            }
        }

        protected void isClicked(object sender, EventArgs e)
        {
            Response.Redirect("EntRegistrationSearch.aspx");
        }
    }
}