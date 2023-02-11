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
            ddlLeaveType.Items.Insert(0, new ListItem("Select Leave Type", ""));

            txtDateCommencing.Text = staffLeave.LeaveDate.ToShortDateString();
            txtNoOfDates.Text = staffLeave.NoOfLeaves.ToString();
            txtDateResuming.Text = staffLeave.ResumingDate.ToShortDateString();
            ddlLeaveType.SelectedValue = staffLeave.LeaveTypeId.ToString();
            ddlDayType.Text = staffLeave.DayTypeId.ToString();
            txtLeaveReason.Text = staffLeave.ReasonForLeave;

            if (staffLeave.ApprovedBy == 0)
            {
                btnApprove.Visible = true;
                btnModalReject.Visible = true;


            }
            else
            {
                btnApprove.Visible = false;
                btnModalReject.Visible = false;
            }

        }

        protected void btnViewLeave_Click(object sender, EventArgs e)
        {
            int employeId = Convert.ToInt32(Request.QueryString["EmpId"]);
            Response.Redirect("LeaveBalance.aspx?EmpId=" + employeId);

        }

        //protected void btnReject_Click(object sender, EventArgs e)
        //{
        //    StaffLeave staffLeave = new StaffLeave();
        //    staffLeave.ApprovedBy = -1;
        //    staffLeave.ApprovedDate = DateTime.Now;
        //    staffLeave.StaffLeaveId = Convert.ToInt32(Request.QueryString["Id"]);

        //    StaffLeaveController staffLeaveController = ControllerFactory.CreateStaffLeaveControllerImpl();

        //    int response = staffLeaveController.updateStaffLeaves(staffLeave);

        //    if (response != 0)
        //    {
        //        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Succesfully Rejected!', 'success');window.setTimeout(function(){window.location='ApproveLeave.aspx'},2500);", true);

        //    }
        //    else
        //    {
        //        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);

        //    }



        //}

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            StaffLeave staffLeave = new StaffLeave();
            staffLeave.ApprovedBy = Convert.ToInt32(Session["UserId"]);
            staffLeave.ApprovedDate = DateTime.Now;
            staffLeave.StaffLeaveId = Convert.ToInt32(Request.QueryString["Id"]);

            StaffLeaveController staffLeaveController = ControllerFactory.CreateStaffLeaveControllerImpl();

            int response = staffLeaveController.updateStaffLeaves(staffLeave);

            if (response != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Approved Succesfully!', 'success');window.setTimeout(function(){window.location='ApproveLeave.aspx'},2500);", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);


            }


        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            StaffLeave staffLeave = new StaffLeave();
            staffLeave.ApprovedBy = -1;
            staffLeave.ApprovedDate = DateTime.Now;
            staffLeave.StaffLeaveId = Convert.ToInt32(Request.QueryString["Id"]);

            StaffLeaveController staffLeaveController = ControllerFactory.CreateStaffLeaveControllerImpl();

            int response = staffLeaveController.updateStaffLeaves(staffLeave);

            if (response != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Succesfully Rejected!', 'success');window.setTimeout(function(){window.location='ApproveLeave.aspx'},2500);", true);

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("approveleave.aspx");

        }
    }
}