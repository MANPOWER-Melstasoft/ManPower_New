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
using System.Xml.Linq;

namespace ManPowerWeb
{
    public partial class FuelDetailsReport : System.Web.UI.Page
    {

        FuelDetailsController fuelDetailsController = ControllerFactory.CreateFuelDetailsController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                bindDataSource();
            }
        }

        private void bindDataSource()
        {
            EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
            List<Employee> employees = employeeController.GetAllEmployees(true);

            ddlEmployee.DataSource = employees;
            ddlEmployee.DataTextField = "NameWithInitials";
            ddlEmployee.DataValueField = "EmployeeId";
            ddlEmployee.DataBind();
            ddlEmployee.Items.Insert(0, new ListItem("-- Select Employee --", ""));
        }



        protected void btnGetAll_Click(object sender, EventArgs e)
        {
            List<FuelDetailsDomain> fuelDetails = new List<FuelDetailsDomain>();
            fuelDetails = fuelDetailsController.GetAllWithFuleTypeDetails(true);
            gvFuelDetails.DataSource = fuelDetails;
            gvFuelDetails.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<FuelDetailsDomain> fuelDetails = new List<FuelDetailsDomain>();
            fuelDetails = fuelDetailsController.GetAllWithFuleTypeDetails(true);
            bool flag = false;

            if (ddlEmployee.SelectedValue != "")
            {
                fuelDetails = fuelDetails.Where(x => x.EmployeeId == Convert.ToInt32(ddlEmployee.SelectedValue)).ToList();
                flag = true;
            }

            if (txtVehicleNumber.Text != "")
            {
                fuelDetails = fuelDetails.Where(x => x.VehicleNumber.Trim().ToLower().Replace(" ", string.Empty) == txtVehicleNumber.Text.Trim().ToLower().Replace(" ", string.Empty)).ToList();
                flag = true;

            }

            if (txtStartDate.Text != "" && txtEndDate.Text != "")
            {
                fuelDetails = fuelDetails.Where(x => x.CreatedDate <= DateTime.Parse(txtEndDate.Text) && x.CreatedDate >= DateTime.Parse(txtStartDate.Text)).ToList();
                flag = true;
            }

            if (!flag)
            {
                gvFuelDetails.DataSource = null;

            }
            else
            {
                gvFuelDetails.DataSource = fuelDetails;

            }

            gvFuelDetails.DataBind();

        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            ddlEmployee.ClearSelection();
            txtEndDate.Text = null;
            txtStartDate.Text = null;
            txtVehicleNumber.Text = null;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btnRun_ServerClick(object sender, EventArgs e)
        {
            List<FuelDetailsDomain> fuelDetails = new List<FuelDetailsDomain>();
            fuelDetails = fuelDetailsController.GetAllWithFuleTypeDetails(true);
            gvFuelDetails.DataSource = fuelDetails;
            gvFuelDetails.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Fuel Details Report" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gvFuelDetails.GridLines = GridLines.Both;
            gvFuelDetails.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            gvFuelDetails.HeaderStyle.ForeColor = System.Drawing.Color.White;
            gvFuelDetails.RowStyle.BackColor = System.Drawing.Color.LightGray;
            gvFuelDetails.RowStyle.ForeColor = System.Drawing.Color.Black;

            //tblTaSummary.HeaderStyle.Font.Bold = true;
            gvFuelDetails.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }
    }
}