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
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportController reportController = ControllerFactory.CreateReportController();
            int employeId = Convert.ToInt32(Request.QueryString["EmpId"]);
            leaveListFromTable = reportController.GetLeaveBalanceByEmployeeId(employeId);

            if (!IsPostBack)
            {
                bindData();
                ViewState["PreviousPage"] = Request.UrlReferrer;
            }

        }

        private void bindData()
        {
            gvLeaveBalance.DataSource = leaveListFromTable;
            int sumEntiletment = 0;
            int sumApprovedLeaves = 0;
            int sumPendingApproval = 0;
            int sumLeaveBalance = 0;

            foreach (var leave in leaveListFromTable)
            {
                sumEntiletment += Convert.ToInt32(leave.Entitlement);
                sumApprovedLeaves += Convert.ToInt32(leave.ApprovedLeaves);
                sumPendingApproval += Convert.ToInt32(leave.PendingApproval);
                sumLeaveBalance += Convert.ToInt32(leave.LeaveBalannce);
            }
            gvLeaveBalance.Columns[0].FooterText = "Summary";
            gvLeaveBalance.Columns[1].FooterText = sumEntiletment.ToString();
            gvLeaveBalance.Columns[2].FooterText = sumApprovedLeaves.ToString();
            gvLeaveBalance.Columns[3].FooterText = sumPendingApproval.ToString();
            gvLeaveBalance.Columns[4].FooterText = sumLeaveBalance.ToString();

            gvLeaveBalance.DataBind();


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