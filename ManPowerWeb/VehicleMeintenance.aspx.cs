using Antlr.Runtime;
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
    
    public partial class VehicleMeintenance : System.Web.UI.Page
    {

        string[] cat = { "Repare", "Service" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataSource();
            }
        }

        private void BindDataSource()
        {

            //VehicleMeintenance vehicleMeintenance = new VehicleMeintenance();
            //Vehi companyVecansyRegistationDetailsController = ControllerFactory.CreateCompanyVecansyRegistationDetailsController();

            //cc = companyVecansyRegistationDetailsController.GetAllCompanyVecansyRegistationDetails();

            //ViewState["cc"] = cc;
            //GridView1.DataSource = cc;
            //GridView1.DataBind();

            //ddlYear.DataSource = year;
            //ddlYear.DataBind();

            //ddlPosition.DataSource = career;
            //ddlPosition.DataBind();

            ddlCategory.DataSource = cat;
            ddlCategory.DataBind();

        }
    }
}