using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class VehicleMaintenanceReport : System.Web.UI.Page
    {
        VehicleMaintenanceController vehicleMaintenanceController = ControllerFactory.CreateVehicleMaintenanceController();

        SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            BindDataSource();

        }

        public void BindDataSource()
        {
            List<VehicleMeintenance> vehicleMeintenanceList = vehicleMaintenanceController.GetAllVehicleMeintenance();

            List<SystemUser> systemUserList = systemUserController.GetAllSystemUser(false, false, false);

            foreach (var item in vehicleMeintenanceList)
            {
                item.RequestBy = systemUserList.Where(x => x.SystemUserId == item.RequestedBy).Single();

                item.RecommendBy = systemUserList.Where(x => x.SystemUserId == item.RecomandBy).Single();

                item.ApproveBy = systemUserList.Where(x => x.SystemUserId == item.ApprovedBy).Single();
            }

            vehicleMeintenanceList = vehicleMeintenanceList.Where(x => x.IsApproved == 2).ToList();

            gvVehicleMaintReport.DataSource = vehicleMeintenanceList;
            gvVehicleMaintReport.DataBind();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            BindDataSource();

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Vehicle Maintenance Report" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gvVehicleMaintReport.GridLines = GridLines.Both;
            //tblTaSummary.HeaderStyle.Font.Bold = true;
            gvVehicleMaintReport.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
    }
}