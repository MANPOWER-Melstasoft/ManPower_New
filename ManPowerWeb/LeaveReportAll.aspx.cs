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
	public partial class LeaveReportAll : System.Web.UI.Page
	{
		static List<StaffLeave> StaffLeaveList;
		static List<StaffLeave> SearchList;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

			if (!IsPostBack)
			{
				BindDataSource();
				BindDdlDistict();
			}

		}

		public void BindDataSource()
		{
			StaffLeaveController staffLeaveController = ControllerFactory.CreateStaffLeaveControllerImpl();
			StaffLeaveList = staffLeaveController.getStaffLeavesSummary(true);

			LeaveTypeController leaveTypeController = ControllerFactory.CreateLeaveTypeController();
			List<LeaveType> LeaveTypeList = leaveTypeController.GetAllLeaveTypes();

			try
			{
				StaffLeaveList = StaffLeaveList.Where(x => x.LeaveStatusId == 4).ToList();

				//foreach (var item in StaffLeaveList)
				//{
				//    item.leaveType = LeaveTypeList.Where(x => x.LeaveTypeId == item.LeaveTypeId).Single();
				//}

			}
			catch (Exception ex)
			{
				StaffLeaveList.Clear();
			}
			finally
			{
				gvLeaveReport.DataSource = StaffLeaveList;
				gvLeaveReport.DataBind();
			}

		}

		private void BindDdlDistict()
		{
			DepartmentUnitController DUController = ControllerFactory.CreateDepartmentUnitController();
			List<DepartmentUnit> DepartmentUnit = DUController.GetAllDepartmentUnit(false, false);

			ddlDistrict.DataSource = DepartmentUnit;
			ddlDistrict.DataValueField = "DepartmentUnitId";
			ddlDistrict.DataTextField = "Name";
			ddlDistrict.DataBind();
			ddlDistrict.Items.Insert(0, new ListItem("All", ""));
		}

		protected void btnView_Click(object sender, EventArgs e)
		{
			int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
			int pagesize = gvLeaveReport.PageSize;
			int pageindex = gvLeaveReport.PageIndex;
			rowIndex = (pagesize * pageindex) + rowIndex;
			Response.Redirect("LeaveReportView.aspx?EmpId=" + StaffLeaveList[rowIndex].EmployeeId);

		}

		public override void VerifyRenderingInServerForm(Control control)
		{

		}

		protected void btnExportExcel_Click(object sender, EventArgs e)
		{
			Response.Clear();
			Response.Buffer = true;
			Response.ClearContent();
			Response.ClearHeaders();
			Response.Charset = "";
			string FileName = "Leave Report" + DateTime.Now + ".xls";
			StringWriter strwritter = new StringWriter();
			HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.ContentType = "application/vnd.ms-excel";
			Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
			gvLeaveReport.GridLines = GridLines.Both;
			//tblTaSummary.HeaderStyle.Font.Bold = true;
			gvLeaveReport.RenderControl(htmltextwrtter);
			Response.Write(strwritter.ToString());
			Response.End();
		}

		protected void btnSearch_Click(object sender, EventArgs e)
		{
			if (ddlDistrict.SelectedIndex != 0)
			{
				SearchList = StaffLeaveList.Where(x => x.district.Name == ddlDistrict.SelectedItem.ToString()).ToList();
			}
			else if (ddlDistrict.SelectedIndex == 0)
			{
				SearchList = StaffLeaveList;
			}

			if (empName.Text != "" && ddlDistrict.SelectedIndex == 0)
			{
				SearchList = StaffLeaveList.Where(x => x._EMployeeDetails.NameWithInitials.ToLower() == empName.Text.ToLower()).ToList();
			}
			else if (empName.Text != "" && ddlDistrict.SelectedIndex != 0)
			{
				SearchList = SearchList.Where(x => x._EMployeeDetails.NameWithInitials.ToLower() == empName.Text.ToLower()).ToList();
			}

			if (empID.Text != "" && empName.Text == "" && ddlDistrict.SelectedIndex == 0)
			{
				SearchList = StaffLeaveList.Where(u => u._EMployeeDetails.EmployeeId.ToString() == empID.Text).ToList();
			}
			else if (empID.Text != "" && empName.Text != "" && ddlDistrict.SelectedIndex != 0 || empID.Text != "" && empName.Text != "" && ddlDistrict.SelectedIndex == 0 || empID.Text != "" && empName.Text == "" && ddlDistrict.SelectedIndex != 0)
			{
				SearchList = SearchList.Where(u => u._EMployeeDetails.EmployeeId.ToString() == empID.Text).ToList();
			}

			gvLeaveReport.DataSource = SearchList;
			gvLeaveReport.DataBind();
		}

		protected void btnReset_Click(object sender, EventArgs e)
		{
			ddlDistrict.ClearSelection();
			empName.Text = null;
			empID.Text = null;
			BindDataSource();
		}

	}
}