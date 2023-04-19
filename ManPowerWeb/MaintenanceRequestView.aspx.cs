using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ManPowerWeb
{
    public partial class MaintenanceRequestView : System.Web.UI.Page
    {
        List<VehicleMeintenance> vehicleMeintenances = new List<VehicleMeintenance>();
        List<SystemUser> systemUsers = new List<SystemUser>();
        List<SystemUser> fiterList = new List<SystemUser>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                dataSource();
                selection.Visible = false;
                btnChange2.Visible = false;
                reject.Visible = false;
            }
        }

        private void dataSource()
        {
            MaintenanceCategoryController maintenanceCategoryController = ControllerFactory.CreateMaintenanceCategoryController();

            VehicleMaintenanceController vehicleMaintenanceController = ControllerFactory.CreateVehicleMaintenanceController();
            vehicleMeintenances = vehicleMaintenanceController.GetAllVehicleMeintenance();

            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            systemUsers = systemUserController.GetAllSystemUser(false, false, false).Where(u => u.UserTypeId != 3).ToList();

            string id = Request.QueryString["id"];

            foreach (var i in vehicleMeintenances.Where(u => u.VehicleMeintenanceId == int.Parse(id)))
            {
                fielNo.Text = i.FileNo;
                date.Text = i.RequestDate.ToString();
                category.Text = i.CategoryId.ToString();
                requestedBy.Text = i.RequestDate.ToString();
                vNo.Text = i.VehicleNumber;
                description.Text = i.RequestDescription.ToString();
                txtMeter.Text = i.VehicleMeter;
                txtMiladge.Text = i.Mileage;

                MaintenanceCategory maintenanceCategory = maintenanceCategoryController.GetMaintenanceCategory(i.CategoryId);
                category.Text = maintenanceCategory.MaintenanceCategoryName;

                if (i.IsApproved == 0)
                {
                    approval.Text = "Not Approved";
                }
                else if (i.IsApproved == 1)
                {
                    approval.Text = "Pending Approval";
                }

                else if (i.IsApproved == 2)
                {
                    approval.Text = "Request Approved";
                }

                else if (i.IsApproved == 3)
                {
                    approval.Text = "Request Rejected";
                    reject.Visible = true;
                }

                if (i.IsApproved == 1 || i.IsApproved == 2 || i.IsApproved == 3)
                {
                    appBtn.Enabled = false;
                }

            }

            ddlOfficer.DataSource = systemUsers;
            ddlOfficer.DataTextField = "Name";
            ddlOfficer.DataValueField = "SystemUserId";
            ddlOfficer.DataBind();
        }

        protected void isClicked(object sender, EventArgs e)
        {
            Response.Redirect("VehicleMeintenanceSearch.aspx");
        }

        protected void approvalButton(object sender, EventArgs e)
        {
            selection.Visible = true;
            btnChange2.Visible = true;
            btnChange1.Visible = false;
        }

        protected void sendToApproval(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            VehicleMaintenanceController vehicleMaintenanceController = ControllerFactory.CreateVehicleMaintenanceController();
            int result = vehicleMaintenanceController.UpdateApprovalStatus(int.Parse(id), 1, int.Parse(ddlOfficer.SelectedValue), "");

            if (result == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Something Went Wrong !');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sending to Recommondation..');", true);
                Response.Redirect("VehicleMeintenanceSearch.aspx");
            }
        }
    }
}