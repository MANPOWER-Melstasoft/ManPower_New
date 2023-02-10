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
        List<HolidaySheet> holidaySheetsList = new List<HolidaySheet>();
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

            bool validation = false;

            int response = 0;

            staffLeave.NoOfLeaves = int.Parse(txtNoOfDates.Text);

            if (DateTime.Parse(txtDateCommencing.Text) > DateTime.Now)
            {
                staffLeave.LeaveDate = DateTime.Parse(txtDateCommencing.Text);
                validation = true;

            }
            else
            {
                lblDate.Text = "Invalid Date";
            }



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
            staffLeave.ResumingDate = DateTime.Parse(txtDateResuming.Text);
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

                        staffLeave.LeaveDocument = uploadFile.FileName;

                    }
                }
            }
            else
            {
                staffLeave.LeaveDocument = "";
            }

            if (validation)
            {
                response = staffLeaveController.saveStaffLeave(staffLeave);

            }

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

        protected void txtNoOfDates_TextChanged(object sender, EventArgs e)
        {

            int dayCount = CheckDate(DateTime.Parse(txtDateCommencing.Text)) + Convert.ToInt32(txtNoOfDates.Text);
            txtDateResuming.Text = DateTime.Parse(txtDateCommencing.Text).AddDays(dayCount).ToString("yyyy-MM-dd");

        }

        protected int CheckDate(DateTime day)
        {
            holidaySheetsList = ControllerFactory.CreateHolidaySheetController().getAllHolidays();
            holidaySheetsList = holidaySheetsList.Where(x => x.HolidayDate.Month == day.Month && x.HolidayDate.Year == day.Year).ToList();
            int dayCount = 0;

            foreach (var holiday in holidaySheetsList)
            {
                if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday || day == holiday.HolidayDate)
                {
                    dayCount++;
                }
            }

            return dayCount;


        }
    }
}