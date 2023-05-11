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
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {

                bindDataToDropdown();
            }
        }


        private void bindDataToDropdown()
        {
            FuelTypeController fuelTypeController = ControllerFactory.CreateFuelTypeController();
            List<FuelType> fuelTypeList = fuelTypeController.GetFuelTypes();
            ddlFuelType.DataSource = fuelTypeList;
            ddlFuelType.DataTextField = "FuelTypeName";
            ddlFuelType.DataValueField = "FuelTypeId";
            ddlFuelType.DataBind();
            ddlFuelType.Items.Insert(0, new ListItem("-- Select Fule Type --", ""));

            //Bind To Employee Dropdown

            EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
            List<Employee> employees = employeeController.GetAllEmployees(true);

            ddlEmployee.DataSource = employees;
            ddlEmployee.DataTextField = "NameWithInitials";
            ddlEmployee.DataValueField = "EmployeeId";
            ddlEmployee.DataBind();
            ddlEmployee.Items.Insert(0, new ListItem("-- Select Employee --", ""));


        }

        private void clear()
        {
            txtVehicleNumber.Text = null;
            txtDate.Text = null; ;
            txtLiter.Text = null;
            txtOrderNumber.Text = null;
            ddlFuelType.ClearSelection();
            ddlEmployee.ClearSelection();
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

            fuelDetailsDomain.FuelTypeId = Convert.ToInt32(ddlFuelType.SelectedValue);

            fuelDetailsDomain.EmployeeId = Convert.ToInt32(ddlEmployee.SelectedValue);

            fuelDetailsDomain.EmployeeName = ddlEmployee.SelectedItem.ToString();


            FuelDetailsController fuelDetailsController = ControllerFactory.CreateFuelDetailsController();
            int output = fuelDetailsController.Save(fuelDetailsDomain);

            if (output != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Saved Succesfully!', 'success')", true);
                clear();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);
            }
        }
    }
}