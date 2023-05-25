using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
	public partial class MaintenanceRecomandView : System.Web.UI.Page
	{
		List<VehicleMeintenance> vehicleMeintenances = new List<VehicleMeintenance>();
		List<SystemUser> systemUsers = new List<SystemUser>();
		List<SystemUser> fiterList = new List<SystemUser>();
		List<MaintenanceCategory> maintenanceCategories = new List<MaintenanceCategory>();


		protected void Page_Load(object sender, EventArgs e)
		{
			this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

			if (!IsPostBack)
			{

				dropDownBind();



				VehicleMaintenanceController vehicleMaintenanceController = ControllerFactory.CreateVehicleMaintenanceController();
				vehicleMeintenances = vehicleMaintenanceController.GetAllVehicleMeintenance();

				SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
				systemUsers = systemUserController.GetAllSystemUser(false, false, false);

				string id = Request.QueryString["id"];




				VehicleMeintenance i = vehicleMeintenances.Where(u => u.VehicleMeintenanceId == int.Parse(id)).Single();

				txtFielNo.Text = i.FileNo;
				date.Text = i.RequestDate.ToString();
				requestedBy.Text = i.Employee.NameWithInitials.ToString();
				vNo.Text = i.VehicleNumber;
				description.Text = i.RequestDescription.ToString();
				txtMeter.Text = i.VehicleMeter;
				txtMiladge.Text = i.Mileage;
				ddlCategory.SelectedValue = i.CategoryId.ToString();
				txtMeter.Text = i.VehicleMeter;
				txtPrevMeter.Text = i.VehiclePrevMeter;


				Label2.Text = i.Attachment;
				UploadDoclink.HRef = "/SystemDocuments/Quatations/" + i.Attachment;

				if (ddlCategory.SelectedValue == "4" && i.InsuranceStartDate.Year != 1 && i.InsuranceEndDate.Year != 1)
				{
					txtStartDate.Text = i.InsuranceStartDate.ToShortDateString();
					txtEndDate.Text = i.InsuranceEndDate.ToShortDateString();
				}

				if (i.IsEngineerRecommendation == "1")
				{
					chkEnginerrReommendation.Checked = true;
					rowEngFileUploader.Visible = true;

					if (i.Attachment != "")
					{
						Label1.Text = i.EngineerFileAttachment;
						Doclink.HRef = "/SystemDocuments/Quatations/" + i.EngineerFileAttachment;
					}
				}
				else
				{
					chkEnginerrReommendation.Checked = false;
				}

				if (i.IsApproved == 0)
				{

					approval.Text = "Not Recommended";
				}
				else if (i.IsApproved == 1)
				{
					approval.Text = "Pending Recommendation To Transport Officer";
					butonA.Visible = true;
					butonR.Visible = true;
				}

				else if (i.IsApproved == 2)
				{
					approval.Text = "Pending Recommendation To Assistant Director";
				}

				else if (i.IsApproved == 3)
				{
					approval.Text = "Pending Recommendation To Director";
				}

				else if (i.IsApproved == 4)
				{
					approval.Text = "Request Approved";
				}

				else if (i.IsApproved == 5)
				{
					approval.Text = "Request Rejected By TO";
				}

				else if (i.IsApproved == 6)
				{
					approval.Text = "Request Rejected By AD";
				}


				else if (i.IsApproved == 7)
				{
					approval.Text = "Request Rejected By Director";
				}

				else if (i.IsApproved == 8)
				{
					approval.Text = "Pending Approval from DG";
				}


				else if (i.IsApproved == 9)
				{
					approval.Text = "Request Rejected By DG";
				}


			}




		}

		protected void isClicked(object sender, EventArgs e)
		{
			Response.Redirect("MaintenanceRecomand.aspx");
		}

		private void dropDownBind()
		{
			MaintenanceCategoryController maintenanceCategoryController = ControllerFactory.CreateMaintenanceCategoryController();
			MaintenanceCategoryController maintenanceCategory = ControllerFactory.CreateMaintenanceCategoryController();
			maintenanceCategories = maintenanceCategory.GetAllMaintenanceCategory();

			ddlCategory.DataSource = maintenanceCategories;
			ddlCategory.DataTextField = "MaintenanceCategoryName";
			ddlCategory.DataValueField = "MaintenanceCategoryId";
			ddlCategory.DataBind();
			ddlCategory.Items.Insert(0, new ListItem("-- Select --", ""));
		}

		protected void Accept(object sender, EventArgs e)
		{
			string id = Request.QueryString["id"];
			string fileNo = txtFielNo.Text;


			SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
			List<SystemUser> listSystemUser = systemUserController.GetAllSystemUser(false, false, false);
			SystemUser systemUsersobj = new SystemUser();
			if (listSystemUser.Any(u => u.UserTypeId != 3 && u.DesignationId == 33))
			{
				systemUsersobj = listSystemUser.Where(u => u.UserTypeId != 3 && u.DesignationId == 33).Single();
			}

			VehicleMaintenanceController vehicleMaintenanceController = ControllerFactory.CreateVehicleMaintenanceController();
			int result = vehicleMaintenanceController.UpdateRecommandationTOStatus(int.Parse(id), 2, fileNo, systemUsersobj.EmpNumber, "");

			if (result == 1)
			{
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Sending to Recommendation to Assitant Director..!', 'success');window.setTimeout(function(){window.location='MaintenanceRecomand.aspx'},2500);", true);
			}
			else
			{
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);

			}

		}

		protected void Reject(object sender, EventArgs e)
		{
			string id = Request.QueryString["id"];
			string fileNo = txtFielNo.Text;

			SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
			List<SystemUser> listSystemUser = systemUserController.GetAllSystemUser(false, false, false);
			SystemUser systemUsersobj = new SystemUser();
			if (listSystemUser.Any(u => u.UserTypeId != 3 && u.DesignationId == 33))
			{
				systemUsersobj = listSystemUser.Where(u => u.UserTypeId != 3 && u.DesignationId == 33).Single();
			}

			VehicleMaintenanceController vehicleMaintenanceController = ControllerFactory.CreateVehicleMaintenanceController();
			int result = vehicleMaintenanceController.UpdateRecommandationTOStatus(int.Parse(id), 5, fileNo, systemUsersobj.EmpNumber, rejectReason.Text);

			if (result == 1)
			{
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Request Rejected..!', 'success');window.setTimeout(function(){window.location='MaintenanceRecomand.aspx'},2500);", true);
			}
			else
			{
				ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);

			}

		}

	}
}