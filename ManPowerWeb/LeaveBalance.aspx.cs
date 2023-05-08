using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class LeaveBalance : System.Web.UI.Page
    {
        List<Report> leaveListFromTable = new List<Report>();
        int employeId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            employeId = Convert.ToInt32(Request.QueryString["EmpId"]);

            if (!IsPostBack)
            {
                bindData();
                bindDataPre();
                ViewState["PreviousPage"] = Request.UrlReferrer;
            }

        }

        private void bindData()
        {
            int year = DateTime.Today.Year;
            ReportController reportController = ControllerFactory.CreateReportController();
            leaveListFromTable = reportController.GetLeaveBalanceEmpAndYear(employeId, year);

            gvLeaveBalance.DataSource = leaveListFromTable;
            double sumEntiletment = 0;
            double sumApprovedLeaves = 0;
            double sumPendingApproval = 0;
            double sumLeaveBalance = 0;

            foreach (var leave in leaveListFromTable)
            {
                sumEntiletment += float.Parse(leave.Entitlement);
                sumApprovedLeaves += leave.ApprovedLeaves;
                sumPendingApproval += leave.PendingApproval;
                sumLeaveBalance += leave.LeaveBalannce;
            }
            gvLeaveBalance.Columns[0].FooterText = "Summary";
            gvLeaveBalance.Columns[1].FooterText = sumEntiletment.ToString();
            gvLeaveBalance.Columns[2].FooterText = sumApprovedLeaves.ToString();
            gvLeaveBalance.Columns[3].FooterText = sumPendingApproval.ToString();
            gvLeaveBalance.Columns[4].FooterText = sumLeaveBalance.ToString();

            gvLeaveBalance.DataBind();


        }

        private void bindDataPre()
        {
            int year = DateTime.Today.Year;
            year--;

            ReportController reportController = ControllerFactory.CreateReportController();
            leaveListFromTable = reportController.GetLeaveBalanceEmpAndYear(employeId, year);

            gvPreLeave.DataSource = leaveListFromTable;
            double sumEntiletment = 0;
            double sumApprovedLeaves = 0;
            double sumPendingApproval = 0;
            double sumLeaveBalance = 0;

            foreach (var leave in leaveListFromTable)
            {
                sumEntiletment += float.Parse(leave.Entitlement);
                sumApprovedLeaves += leave.ApprovedLeaves;
                sumPendingApproval += leave.PendingApproval;
                sumLeaveBalance += leave.LeaveBalannce;
            }
            gvPreLeave.Columns[0].FooterText = "Summary";
            gvPreLeave.Columns[1].FooterText = sumEntiletment.ToString();
            gvPreLeave.Columns[2].FooterText = sumApprovedLeaves.ToString();
            gvPreLeave.Columns[3].FooterText = sumPendingApproval.ToString();
            gvPreLeave.Columns[4].FooterText = sumLeaveBalance.ToString();

            gvPreLeave.DataBind();


        }

        protected void gvLeaveBalance_RowDataBound(object sender, GridViewRowEventArgs e)
        {



            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            // Response.Redirect("ApproveLeaveView.aspx");
            if (ViewState["PreviousPage"] != null)
            {
                Response.Redirect(ViewState["PreviousPage"].ToString());
            }
        }
    }
}