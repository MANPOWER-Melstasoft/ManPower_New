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

            staffLeave.NoOfLeaves = float.Parse(txtNoOfDates.Text);

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

            staffLeave.NoOfLeaves = float.Parse(txtNoOfDates.Text);
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
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Leave Apply Succesfully!', 'success');window.setTimeout(function(){window.location='ApplyLeaves.aspx'},2500);", true);
                //Response.Redirect(Request.RawUrl);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error');window.setTimeout(function(){window.location='ApplyLeaves.aspx'},2500);", true);

            }


        }

        protected void btnLeaveBalance_Click(object sender, EventArgs e)
        {


            Response.Redirect("LeaveBalance.aspx?EmpId=" + Convert.ToInt32(Session["EmpNumber"]));

        }

        protected void txtNoOfDates_TextChanged(object sender, EventArgs e)
        {

            float dayCount = float.Parse(txtNoOfDates.Text);

            dayCount = dayCount + CheckDate(DateTime.Parse(txtDateCommencing.Text), DateTime.Parse(txtDateCommencing.Text).AddDays(dayCount));

            //int resumingday = CheckResumingDate(DateTime.Parse(txtDateCommencing.Text).AddDays(dayCount));

            txtDateResuming.Text = CheckResumingDate(DateTime.Parse(txtDateCommencing.Text).AddDays(dayCount)).ToString("yyyy-MM-dd");
        }

        protected int CheckDate(DateTime Startday, DateTime Endday)
        {
            holidaySheetsList = ControllerFactory.CreateHolidaySheetController().getAllHolidays();

            int dayCount = 0;

            for (DateTime i = Startday; i <= Endday; i = i.AddDays(1))
            {
                if (i.DayOfWeek == DayOfWeek.Saturday || i.DayOfWeek == DayOfWeek.Sunday)
                {
                    dayCount++;
                }
                else
                {
                    holidaySheetsList = holidaySheetsList.Where(x => x.HolidayDate.Month == Startday.Month && x.HolidayDate.Year == Startday.Year).ToList();
                    foreach (var holiday in holidaySheetsList)
                    {
                        if (i == holiday.HolidayDate)
                        {
                            dayCount++;
                        }
                    }
                }
            }
            return dayCount;


        }
        protected DateTime CheckResumingDate(DateTime day)
        {
            if (day.DayOfWeek == DayOfWeek.Saturday)
            {
                day = day.AddDays(2);
            }
            if (day.DayOfWeek == DayOfWeek.Sunday)
            {
                day = day.AddDays(1);

            }

            holidaySheetsList = ControllerFactory.CreateHolidaySheetController().getAllHolidays();

            if (holidaySheetsList.Where(x => x.HolidayDate == day).Count() > 0)
            {
                day = day.AddDays(1);
            }
            return day;

        }
    }
}