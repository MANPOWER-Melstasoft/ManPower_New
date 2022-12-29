using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ManPowerWeb
{
    public partial class MaintenanceRequest : System.Web.UI.Page
    {
        List<MaintenanceCategory> maintenanceCategories = new List<MaintenanceCategory>();
        List<SystemUser> listUsers = new List<SystemUser>();
        int empId;
        string name;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                dataSource();
            }
        }

        private void dataSource()
        {

            MaintenanceCategoryController maintenanceCategory = ControllerFactory.CreateMaintenanceCategoryController();
            maintenanceCategories = maintenanceCategory.GetAllMaintenanceCategory();

            ddlCategory.DataSource = maintenanceCategories;
            ddlCategory.DataTextField = "MaintenanceCategoryName";
            ddlCategory.DataValueField = "MaintenanceCategoryId";
            ddlCategory.DataBind();

            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            listUsers = systemUserController.GetAllSystemUser(true, false, false);

            foreach (var i in listUsers.Where(u => u.SystemUserId == Convert.ToInt32(Session["UserId"])))
            {
                name = i.Name;
            }

            requestedBy.Text = name;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            listUsers = systemUserController.GetAllSystemUser(true, false, false);

            foreach (var i in listUsers.Where(u => u.SystemUserId == Convert.ToInt32(Session["UserId"])))
            {
                empId = i.EmpNumber;
            }

            VehicleMeintenance vehicleRequest = new VehicleMeintenance();
            VehicleMaintenanceController vehicleMaintenance = ControllerFactory.CreateVehicleMaintenanceController();

            vehicleRequest.FileNo = fielNo.Text;
            vehicleRequest.RequestDate = Convert.ToDateTime(date.Text);
            vehicleRequest.CategoryId = int.Parse(ddlCategory.SelectedValue);
            vehicleRequest.ApprovedDate = DateTime.Today;
            vehicleRequest.ApprovedBy = 0;
            vehicleRequest.RequestedBy = Convert.ToInt32(Session["UserId"]);
            vehicleRequest.VehicleNumber = vNo.Text;
            vehicleRequest.RequestDescription = description.Text;
            vehicleRequest.IsApproved = 0;
            vehicleRequest.EstimatedCost = 0;
            vehicleRequest.EmpId = 25;
            vehicleRequest.RejectedReason = "";


            if (Uploader.HasFile)
            {
                HttpFileCollection uploadFiles = Request.Files;
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile uploadFile = uploadFiles[i];
                    if (uploadFile.ContentLength > 0)
                    {
                        uploadFile.SaveAs(Server.MapPath("~/SystemDocuments/Quatations/") + uploadFile.FileName);
                        lblListOfUploadedFiles.Text += String.Format("{0}<br />", uploadFile.FileName);
                        vehicleRequest.Attachment = uploadFile.FileName;

                    }
                }
            }

            int result1 = vehicleMaintenance.SaveVehicleMeintenance(vehicleRequest);

            if (result1 == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Something went wrong');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Added Succesfully');", true);
                fielNo.Text = null;
                date.Text = null;
                requestedBy.Text = null;
                vNo.Text = null;
                description.Text = null;
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            fielNo.Text = null;
            date.Text = null;
            requestedBy.Text = null;
            vNo.Text = null;
            description.Text = null;
        }

        protected void isClicked(object sender, EventArgs e)
        {
            Response.Redirect("VehicleMeintenanceSearch.aspx");
        }
    }
}