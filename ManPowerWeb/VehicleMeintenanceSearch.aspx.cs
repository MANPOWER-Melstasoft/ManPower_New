using Antlr.Runtime;
using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{

    public partial class VehicleMeintenanceSearch : System.Web.UI.Page
    {
        List<VehicleMeintenance> vehicleMeintenances = new List<VehicleMeintenance>();
        List<VehicleMeintenance> searchList = new List<VehicleMeintenance>();
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
            vehicleMeintenances = vehicleMaintenanceController.GetAllVehicleMeintenance().Where(u => u.RequestedBy == Convert.ToInt32(Session["UserId"])).ToList();

            MaintenanceCategoryController maintenanceCategoryController = ControllerFactory.CreateMaintenanceCategoryController();
            categries = maintenanceCategoryController.GetAllMaintenanceCategory();

            ddlCategory.DataSource = categries;
            ddlCategory.DataTextField = "MaintenanceCategoryName";
            ddlCategory.DataValueField = "MaintenanceCategoryId";
            ddlCategory.DataBind();

            ViewState["vehicleMeintenances"] = vehicleMeintenances;
            GridView1.DataSource = vehicleMeintenances;
            GridView1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (date.Text == null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter a Date to proceed');", true);
            }
            else
            {
                DateTime searchDate = Convert.ToDateTime(date.Text);
                searchList = (List<VehicleMeintenance>)ViewState["vehicleMeintenances"];
                GridView1.DataSource = searchList.Where(u => u.RequestDate.Date == searchDate.Date && u.CategoryId == int.Parse(ddlCategory.SelectedValue));
                GridView1.DataBind();
            }
        }

        protected void isClicked(object sender, EventArgs e)
        {
            Response.Redirect("MaintenanceRequest.aspx");
        }

        protected void reset(object sender, EventArgs e)
        {
            Response.Redirect("VehicleMeintenanceSearch.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[3].Text == "0")
                {
                    e.Row.Cells[3].Text = "Pending Recommendation";
                }
                else if (e.Row.Cells[3].Text == "1")
                {
                    e.Row.Cells[3].Text = "Pending Approvals";
                }
                else if (e.Row.Cells[3].Text == "2")
                {
                    e.Row.Cells[3].Text = "Approved";
                }
                else if (e.Row.Cells[3].Text == "3")
                {
                    e.Row.Cells[3].Text = "Rejected";
                }

            }
        }
    }
}