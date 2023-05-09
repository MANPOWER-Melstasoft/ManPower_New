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
    public partial class RecommendationLapsedLeaveView : System.Web.UI.Page
    {
        static StaffLeave staffLeave = new StaffLeave();
        List<LeaveType> leavesTypeList = new List<LeaveType>();
        int employeId, Id;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                employeId = Convert.ToInt32(Request.QueryString["EmpId"]);
                Id = Convert.ToInt32(Request.QueryString["Id"]);

                BindData();

            }
        }

        private void BindData()
        {
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

            if (staffLeave.LeaveStatusId == 7)
            {
                btnModalReject.Visible = true;
                btnApprove.Text = "Send to Recommendation Assistance Director";
                btnApprove.Visible = true;
            }
            else if (staffLeave.LeaveStatusId == 8)
            {
                btnModalReject.Visible = true;
                btnApprove.Text = "Send to Recommendation Director";
                btnApprove.Visible = true;
            }
            else if (staffLeave.LeaveStatusId == 9)
            {
                btnModalReject.Visible = true;
                btnApprove.Text = "Send to Recommendation DG";
                btnApprove.Visible = true;
            }
            else if (staffLeave.LeaveStatusId == 10)
            {
                btnModalReject.Visible = true;
                btnApprove.Text = "Send to Approval";
                btnApprove.Visible = true;
            }
            else
            {
                btnModalReject.Visible = false;
                btnApprove.Visible = false;
            }

            staffLeaveDocumentsController staffLeaveDocumentsController = ControllerFactory.CreateStaffLeaveDocumentsController();
            List<StaffLeaveDocuments> staffLeaveDocuments = staffLeaveDocumentsController.GetAllDocumentsByLeaveId(Id);

            gvDocument.DataSource = staffLeaveDocuments;
            gvDocument.DataBind();
        }


        protected void btnViewLeave_Click(object sender, EventArgs e)
        {
            int employeId = Convert.ToInt32(Request.QueryString["EmpId"]);
            Response.Redirect("LeaveBalance.aspx?EmpId=" + employeId);

        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            StaffLeave staffLeaveNew = new StaffLeave();
            staffLeaveNew.RecommendedBy = Convert.ToInt32(Session["UserId"]);
            staffLeaveNew.RecomennededDate = DateTime.Now;
            staffLeaveNew.StaffLeaveId = Convert.ToInt32(Request.QueryString["Id"]);
            //staffLeaveNew.LeaveStatusId = 3;
            staffLeaveNew.RejectReason = "";

            if (staffLeave.LeaveStatusId == 7)
            {
                staffLeaveNew.LeaveStatusId = 8;
            }
            else if (staffLeave.LeaveStatusId == 8)
            {
                staffLeaveNew.LeaveStatusId = 9;
            }
            else if (staffLeave.LeaveStatusId == 9)
            {
                staffLeaveNew.LeaveStatusId = 10;
            }
            else if (staffLeave.LeaveStatusId == 10)
            {
                staffLeaveNew.LeaveStatusId = 3;
            }


            StaffLeaveController staffLeaveController = ControllerFactory.CreateStaffLeaveControllerImpl();

            int response = staffLeaveController.updateStaffLeaves(staffLeaveNew);

            if (response != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Succesfully Sent To Recommendation!', 'success');window.setTimeout(function(){window.location='RecommendationLapsedLeave.aspx'},2500);", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error');window.setTimeout(function(){window.location='RecommendationLapsedLeave.aspx'},2500);", true);


            }


        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            StaffLeave staffLeave = new StaffLeave();
            staffLeave.RecommendedBy = -1;
            staffLeave.RecomennededDate = DateTime.Now;
            staffLeave.StaffLeaveId = Convert.ToInt32(Request.QueryString["Id"]);
            staffLeave.LeaveStatusId = 5;
            staffLeave.RejectReason = txtrejectReason.Text;

            StaffLeaveController staffLeaveController = ControllerFactory.CreateStaffLeaveControllerImpl();

            int response = staffLeaveController.updateStaffLeaves(staffLeave);

            if (response != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Succesfully Rejected!', 'success');window.setTimeout(function(){window.location='RecommendationLapsedLeave.aspx'},2500);", true);

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error');window.setTimeout(function(){window.location='RecommendationLapsedLeave.aspx'},2500);", true);

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecommendationLapsedLeave.aspx");

        }

    }
}