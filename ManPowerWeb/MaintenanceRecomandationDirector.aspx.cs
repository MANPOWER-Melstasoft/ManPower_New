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
	public partial class MaintenanceRecomandationAD : System.Web.UI.Page
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

		protected void btnSearch_Click(object sender, EventArgs e)
		{
			UserSearchList = (List<VehicleMeintenance>)ViewState["searchList"];


			if (ddlCategory.SelectedValue != "")
			{
				UserSearchList = UserSearchList.Where(x => x.CategoryId == Convert.ToInt32(ddlCategory.SelectedValue)).ToList();
			}

			if (date.Text != "")
			{
				UserSearchList = UserSearchList.Where(u => u.RequestDate.Date == DateTime.Parse(date.Text)).ToList();
			}
			GridView1.DataSource = UserSearchList;
			GridView1.DataBind();
		}

		protected void btnReset_Click(object sender, EventArgs e)
		{
			ddlCategory.ClearSelection();
			date.Text = null;
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
			ddlCategory.Items.Insert(0, new ListItem("-- Select --", ""));


			if (Convert.ToInt32(Session["DesignationId"]) == 5)
			{
				searchList = vehicleMeintenances.Where(x => /*x.RecommendDBy == Convert.ToInt32(Session["EmpNumber"]) &&*/ x.IsApproved > 2 && x.IsApproved != 6).ToList();
			}

			ViewState["searchList"] = searchList;
			GridView1.DataSource = searchList;
			GridView1.DataBind();

		}
	}
}