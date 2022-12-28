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
    public partial class MaintenanceApprovalView : System.Web.UI.Page
    {
        List<VehicleMeintenance> vehicleMeintenances = new List<VehicleMeintenance>();
        List<SystemUser> systemUsers = new List<SystemUser>();
        List<SystemUser> fiterList = new List<SystemUser>();

        protected void Page_Load(object sender, EventArgs e)
        {
            VehicleMaintenanceController vehicleMaintenanceController = ControllerFactory.CreateVehicleMaintenanceController();
            vehicleMeintenances = vehicleMaintenanceController.GetAllVehicleMeintenance();

            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            systemUsers = systemUserController.GetAllSystemUser(false, false, false);

            string id = Request.QueryString["id"];

            foreach (var j in systemUsers.Where(u => u.SystemUserId == Convert.ToInt32(Session["UserId"])))
            {
                foreach (var i in vehicleMeintenances.Where(u => u.VehicleMeintenanceId == int.Parse(id)))
                {
                    fielNo.Text = i.FileNo;
                    date.Text = i.RequestDate.ToString();
                    requestedBy.Text = i.RequestDate.ToString();
                    vNo.Text = i.VehicleNumber;
                    description.Text = i.RequestDescription.ToString();

                    if(i.CategoryId == 1)
                    {
                        category.Text = "Repare";
                    }
                    else
                    {
                        category.Text = "Service";
                    }

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
                    }

                }
            }

        }

        protected void isClicked(object sender, EventArgs e)
        {
            Response.Redirect("MaintenanceApproval.aspx");
        }

        protected void Accept(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            VehicleMaintenanceController vehicleMaintenanceController = ControllerFactory.CreateVehicleMaintenanceController();
            int result = vehicleMaintenanceController.UpdateApprovalStatus(int.Parse(id), 2, Convert.ToInt32(Session["UserId"]),"");

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

        protected void Reject(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            VehicleMaintenanceController vehicleMaintenanceController = ControllerFactory.CreateVehicleMaintenanceController();
            int result = vehicleMaintenanceController.UpdateApprovalStatus(int.Parse(id), 3, Convert.ToInt32(Session["UserId"]),rejectReason.Text);

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