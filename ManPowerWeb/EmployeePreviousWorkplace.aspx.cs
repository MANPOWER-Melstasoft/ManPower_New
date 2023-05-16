using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ManPowerWeb
{
	public partial class EmployeePreviousWorkplaces : System.Web.UI.Page
	{
		static List<EmployeePreviousWorkplace> mainList;
		static List<EmployeePreviousWorkplace> filterList;


		protected void Page_Load(object sender, EventArgs e)
		{
			this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

			if (!IsPostBack)
			{
				BindDataSource();
			}
		}

		private void BindDataSource()
		{
			EmployeePreviousWorkplaceController main = ControllerFactory.CreateEmployeePreviousWorkplaceController();
			List<EmployeePreviousWorkplace> mainListIn = main.GetAllEmployeePreviousWorkplaces(false);
			mainList = new List<EmployeePreviousWorkplace>();

			foreach (var item in mainListIn)
			{
				if (item.EmployeeId != 0)
				{
					mainList.Add(item);
				}
			}

			btnExcell.Visible = true;
			filterList = mainList;
			gvPreviousWorkplace.DataSource = filterList;
			gvPreviousWorkplace.DataBind();

		}

		public override void VerifyRenderingInServerForm(Control control)
		{

		}
		protected void btnExportExcel_Click(object sender, EventArgs e)
		{
			gvPreviousWorkplace.DataSource = filterList;
			gvPreviousWorkplace.DataBind();

			Response.Clear();
			Response.Buffer = true;
			Response.ClearContent();
			Response.ClearHeaders();
			Response.Charset = "";
			string FileName = "Employee Previous WorkPlaces" + DateTime.Now + ".xls";
			StringWriter strwritter = new StringWriter();
			HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.ContentType = "application/vnd.ms-excel";
			Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
			gvPreviousWorkplace.GridLines = GridLines.Both;
			//tblTaSummary.HeaderStyle.Font.Bold = true;
			gvPreviousWorkplace.RenderControl(htmltextwrtter);
			Response.Write(strwritter.ToString());
			Response.End();
		}

		protected void btnSearch_Click(object sender, EventArgs e)
		{
			if (txtName.Text != "")
			{
				filterList = mainList.Where(x => x.employee.LastName.ToLower() == txtName.Text.ToLower()).ToList();
			}


			if (txtEmpID.Text != "")
			{
				filterList = mainList.Where(x => x.employee.EmployeeId.ToString() == txtName.Text).ToList();
			}

			if (txtName.Text == "" && txtEmpID.Text == "")
			{
				BindDataSource();
			}

			gvPreviousWorkplace.DataSource = filterList;
			gvPreviousWorkplace.DataBind();
		}

	}
}