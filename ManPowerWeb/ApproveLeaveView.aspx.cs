using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class ApproveLeaveView : System.Web.UI.Page
    {

        StaffLeave staffLeave = new StaffLeave();
        List<LeaveType> leavesTypeList = new List<LeaveType>();

        protected void Page_Load(object sender, EventArgs e)
        {
            int employeId = Convert.ToInt32(Request.QueryString["EmpId"]);
            int Id = Convert.ToInt32(Request.QueryString["Id"]);


            StaffLeaveController staffLeaveController = ControllerFactory.CreateStaffLeaveControllerImpl();
            staffLeave = staffLeaveController.getStaffLeaveById(Id);

            LeaveTypeController leaveTypeController = ControllerFactory.CreateLeaveTypeController();
            leavesTypeList = leaveTypeController.GetAllLeaveTypes();

            leavesTypeList = leavesTypeList.Where(x => x.IsActive == 1).ToList();

            ddlLeaveType.DataSource = leavesTypeList;
            ddlLeaveType.DataValueField = "LeaveTypeId";
            ddlLeaveType.DataTextField = "Name";
            ddlLeaveType.DataBind();

            txtDateCommencing.Text = staffLeave.LeaveDate.ToShortDateString();
            txtNoOfDates.Text = staffLeave.NoOfLeaves.ToString();
            txtDateResuming.Text = staffLeave.ResumingDate.ToShortDateString();
            ddlLeaveType.SelectedValue = staffLeave.LeaveTypeId.ToString();
            ddlDayType.Text = staffLeave.DayTypeId.ToString();
            txtLeaveReason.Text = staffLeave.ReasonForLeave;







        }

        protected void btnViewLeave_Click(object sender, EventArgs e)
        {
            int employeId = Convert.ToInt32(Request.QueryString["EmpId"]);
            Response.Redirect("LeaveBalance.aspx?EmpId=" + employeId);

        }
    }
}