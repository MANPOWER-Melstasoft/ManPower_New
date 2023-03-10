using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class EntRegistrationSearch : System.Web.UI.Page
    {
        List<BusinessType> business = new List<BusinessType>();
        List<MarketType> mType = new List<MarketType>();
        List<Entrepreneur> entrepreneurs = new List<Entrepreneur>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

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

            EntrepreneurController entrepreneurctrl = ControllerFactory.CreateEntrepreneurController();

            entrepreneurs = entrepreneurctrl.GetAllEntrepreneur();

            ViewState["entrepreneurs"] = entrepreneurs;
            GridView1.DataSource = entrepreneurs;
            GridView1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            entrepreneurs = (List<Entrepreneur>)ViewState["entrepreneurs"];
            GridView1.DataSource = entrepreneurs.Where(u => u.MarketTypeId == int.Parse(marketType.SelectedValue) && u.BusinessTypeId == int.Parse(businessType.SelectedValue));
            GridView1.DataBind();
        }

        protected void isClicked(object sender, EventArgs e)
        {
            Response.Redirect("EntRegistration.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text == "1")
                {
                    e.Row.Cells[0].Text = "Agriculture";
                }
                else if (e.Row.Cells[0].Text == "2")
                {
                    e.Row.Cells[0].Text = "Production";
                }
                else if (e.Row.Cells[0].Text == "3")
                {
                    e.Row.Cells[0].Text = "Service";
                }

                if (e.Row.Cells[1].Text == "1")
                {
                    e.Row.Cells[1].Text = "Local";
                }
                else if (e.Row.Cells[1].Text == "2")
                {
                    e.Row.Cells[1].Text = "Foreign";
                }
                else if (e.Row.Cells[1].Text == "3")
                {
                    e.Row.Cells[1].Text = "Local and Foreign";
                }

            }
        }
    }
}