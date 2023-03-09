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
    public partial class MaintenanceApproval : System.Web.UI.Page
    {
        List<VehicleMeintenance> vehicleMeintenances = new List<VehicleMeintenance>();
        List<VehicleMeintenance> searchList = new List<VehicleMeintenance>();
        List<VehicleMeintenance> UserSearchList = new List<VehicleMeintenance>();
        List<MaintenanceCategory> categries = new List<MaintenanceCategory>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                BindDataSource();
            }
        }

        protected void BindDataSource()
        {
            VehicleMaintenanceController vehicleMaintenanceController = ControllerFactory.CreateVehicleMaintenanceController();
            vehicleMeintenances = vehicleMaintenanceController.GetAllVehicleMeintenance();

            MaintenanceCategoryController maintenanceCategoryController = ControllerFactory.CreateMaintenanceCategoryController();
            categries = maintenanceCategoryController.GetAllMaintenanceCategory();

            ddlCategory.DataSource = categries;
            ddlCategory.DataTextField = "MaintenanceCategoryName";
            ddlCategory.DataValueField = "MaintenanceCategoryId";
            ddlCategory.DataBind();



            foreach (var i in vehicleMeintenances.Where(u => u.IsApproved == 1 && u.ApprovedBy == Convert.ToInt32(Session["UserId"])))
            {
                searchList.Add(i);
            }

            ViewState["searchList"] = searchList;
            GridView1.DataSource = searchList;
            GridView1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime searchDate = Convert.ToDateTime(date.Text);
            if (searchDate == null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter a Date to proceed');", true);
            }
            else
            {
                UserSearchList = (List<VehicleMeintenance>)ViewState["searchList"];
                GridView1.DataSource = UserSearchList.Where(u => u.RequestDate.Date == searchDate.Date && u.CategoryId == int.Parse(ddlCategory.SelectedValue));
                GridView1.DataBind();
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}