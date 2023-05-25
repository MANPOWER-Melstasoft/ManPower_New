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
	public partial class LeaveReportView : System.Web.UI.Page
	{
		static int Id;
		static List<StaffLeave> StaffLeaveList = new List<StaffLeave>();

		protected void Page_Load(object sender, EventArgs e)
		{
			this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

			if (!IsPostBack)
			{
				if (Request.QueryString["EmpId"] != null)
				{
					Id = Convert.ToInt32(Request.QueryString["EmpId"]);
					BindData();
					lblEmpId.Text = Id.ToString();
				}
				else
				{
					Response.Redirect("404.aspx");
				}
			}
		}

		public void BindData()
		{
			StaffLeaveController staffLeaveController = ControllerFactory.CreateStaffLeaveControllerImpl();
			StaffLeaveList = staffLeaveController.getStaffLeaves(true);

			LeaveTypeController leaveTypeController = ControllerFactory.CreateLeaveTypeController();
			List<LeaveType> LeaveTypeList = leaveTypeController.GetAllLeaveTypes();

			try
			{
				StaffLeaveList = StaffLeaveList.Where(x => x.LeaveStatusId == 4 && x.EmployeeId == Id).ToList();

				foreach (var item in StaffLeaveList)
				{
					item.leaveType = LeaveTypeList.Where(x => x.LeaveTypeId == item.LeaveTypeId).Single();
				}

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

		protected void btnisClicked_Click(object sender, EventArgs e)
		{
			Response.Redirect("LeaveReportAll.aspx");

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


	}
}