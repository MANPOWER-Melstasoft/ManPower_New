﻿using Antlr.Runtime;
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
        List<VehicleMeintenance> UserSearchList = new List<VehicleMeintenance>();


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
            ddlCategory.Items.Insert(0, new ListItem("-- Select --", ""));


            ViewState["vehicleMeintenances"] = vehicleMeintenances;
            GridView1.DataSource = vehicleMeintenances;
            GridView1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            UserSearchList = (List<VehicleMeintenance>)ViewState["vehicleMeintenances"];


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


                //

                if (e.Row.Cells[3].Text == "0")
                {

                    e.Row.Cells[3].Text = "Not Recommended";
                }
                else if (e.Row.Cells[3].Text == "1")
                {
                    e.Row.Cells[3].Text = "Pending Recommendation To Transport Officer";
                }

                else if (e.Row.Cells[3].Text == "2")
                {
                    e.Row.Cells[3].Text = "Pending Recommendation To Assistant Director";
                }

                else if (e.Row.Cells[3].Text == "3")
                {
                    e.Row.Cells[3].Text = "Pending Approval To Director";
                }

                else if (e.Row.Cells[3].Text == "4")
                {
                    e.Row.Cells[3].Text = "Request Approved";
                }

                else if (e.Row.Cells[3].Text == "5")
                {
                    e.Row.Cells[3].Text = "Request Rejected By TO";
                }

                else if (e.Row.Cells[3].Text == "6")
                {
                    e.Row.Cells[3].Text = "Request Rejected By AD";
                }


                else if (e.Row.Cells[3].Text == "7")
                {
                    e.Row.Cells[3].Text = "Request Rejected By Director";
                }

            }
        }
    }
}