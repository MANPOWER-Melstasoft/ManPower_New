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
    public partial class FuelDetailsReport : System.Web.UI.Page
    {

        FuelDetailsController fuelDetailsController = ControllerFactory.CreateFuelDetailsController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetAll_Click(object sender, EventArgs e)
        {
            List<FuelDetailsDomain> fuelDetails = new List<FuelDetailsDomain>();
            fuelDetails = fuelDetailsController.GetAllWithFuleTypeDetails(true);
            gvFuelDetails.DataSource = fuelDetails;
            gvFuelDetails.DataBind();
        }
    }
}