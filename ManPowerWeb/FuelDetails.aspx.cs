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
    public partial class FuelDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDataSource();

                bindDataToDropdown();
            }
        }


        private void bindDataToDropdown()
        {
            FuelTypeController fuelTypeController = ControllerFactory.CreateFuelTypeController();
            List<FuelType> fuelTypeList = fuelTypeController.GetFuelTypes();
            ddlFuelType.DataSource = fuelTypeList;
            ddlFuelType.DataTextField = "FuelTypeId";
            ddlFuelType.DataValueField = "Value";
            ddlFuelType.DataBind();
            ddlFuelType.Items.Insert(0, new ListItem("-- Select Fule Type --", ""));
            //

        }
        private void bindDataSource()
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            FuelDetailsDomain fuelDetailsDomain = new FuelDetailsDomain();

            fuelDetailsDomain.VehicleNumber = txtVehicleNumber.Text;
            fuelDetailsDomain.CreatedDate = DateTime.Parse(txtDate.Text);

            // Get Liter 
            fuelDetailsDomain.LitersCount = txtLiter.Text;

            //Get OrderNumber
            fuelDetailsDomain.OrderNumber = txtOrderNumber.Text;

            fuelDetailsDomain.FuelTypeId = 1;


            FuelDetailsController fuelDetailsController = ControllerFactory.CreateFuelDetailsController();
            fuelDetailsController.Save(fuelDetailsDomain);





        }
    }
}