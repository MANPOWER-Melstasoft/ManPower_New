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
    public partial class ApplyLeaves : System.Web.UI.Page
    {
        List<LeaveType> leavesTypeList = new List<LeaveType>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }
        }
        private void bindData()
        {
            LeaveTypeController leaveTypeController = ControllerFactory.CreateLeaveTypeController();
            leavesTypeList = leaveTypeController.GetAllLeaveTypes();

            leavesTypeList = leavesTypeList.Where(x => x.IsActive == 1).ToList();

            ddlLeaveType.DataSource = leavesTypeList;
            ddlLeaveType.DataValueField = "LeaveTypeId";
            ddlLeaveType.DataTextField = "Name";
            ddlLeaveType.DataBind();
        }

        protected void btnApplyLeave_Click(object sender, EventArgs e)
        {
            StaffLeaveController staffLeaveController = ControllerFactory.CreateStaffLeaveControllerImpl();
            StaffLeave staffLeave = new StaffLeave();



            staffLeave.NoOfLeaves = int.Parse(txtNoOfDates.Text);

            staffLeave.LeaveDate = DateTime.Parse(txtDateCommencing.Text);
            staffLeave.CreatedDate = DateTime.Now;
            staffLeave.DayTypeId = int.Parse(ddlDayType.SelectedValue);

            //must change
            staffLeave.EmployeeId = Convert.ToInt32(Session["EmpNumber"]);

            if (ddlDayType.SelectedValue == "3")
            {
                staffLeave.IsHalfDay = 0;
            }
            else
            {
                staffLeave.IsHalfDay = 1;
            }

            staffLeave.NoOfLeaves = int.Parse(txtNoOfDates.Text);
            staffLeave.ReasonForLeave = txtLeaveReason.Text;
            staffLeave.ResumingDate = DateTime.Now;
            staffLeave.LeaveTypeId = int.Parse(ddlLeaveType.SelectedValue);
            staffLeave.LeaveStatusId = 1;


            if (Uploader.HasFile)
            {
                HttpFileCollection uploadFiles = Request.Files;
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile uploadFile = uploadFiles[i];
                    if (uploadFile.ContentLength > 0)
                    {
                        uploadFile.SaveAs(Server.MapPath("~/SystemDocuments/StaffLeaveResources/") + uploadFile.FileName);
                        lblListOfUploadedFiles.Text += String.Format("{0}<br />", uploadFile.FileName);

                        // staffLeave.(column database)  programPlan.FinancialSource = uploadFile.FileName;

                    }
                }
            }

            int response = staffLeaveController.saveStaffLeave(staffLeave);

            if (response != 0)
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success')", true);
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);
            }


        }

        protected void btnLeaveBalance_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaveBalance.aspx?EmpId=" + Convert.ToInt32(Session["EmpNumber"]));

        }
    }
}