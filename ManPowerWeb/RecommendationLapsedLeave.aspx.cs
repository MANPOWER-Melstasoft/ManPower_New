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
    public partial class RecommendationLapsedLeave : System.Web.UI.Page
    {

        static List<StaffLeave> staffLeaveList = new List<StaffLeave>();
        List<StaffLeave> staffLeaveSearchList = new List<StaffLeave>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                bindDataSource();
            }
        }

        private void bindDataSource()
        {

            StaffLeaveController staffLeaveController = ControllerFactory.CreateStaffLeaveControllerImpl();
            staffLeaveList = staffLeaveController.getStaffLeaves(true);

            int userType = Convert.ToInt32(Session["UserTypeId"]);
            int designationId = Convert.ToInt32(Session["DesignationId"]);

            try
            {
                if (designationId == 35)
                {
                    staffLeaveList = staffLeaveList.Where(x => x.LeaveStatusId == 7).ToList();
                }
                else if (designationId == 34)
                {
                    staffLeaveList = staffLeaveList.Where(x => x.LeaveStatusId == 8).ToList();
                }
                else if (designationId == 5)
                {
                    staffLeaveList = staffLeaveList.Where(x => x.LeaveStatusId == 9).ToList();
                }
                else if (designationId == 3)
                {
                    staffLeaveList = staffLeaveList.Where(x => x.LeaveStatusId == 10).ToList();
                }
                else
                {
                    staffLeaveList.Clear();
                }
                ViewState["staffLeaveList"] = staffLeaveList.ToList();
            }
            catch
            {
                staffLeaveList.Clear();
                ViewState["staffLeaveList"] = staffLeaveList.ToList();
            }
            finally
            {
                gvApproveLeave.DataSource = staffLeaveList;
                gvApproveLeave.DataBind();
            }

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = gvApproveLeave.PageSize;
            int pageindex = gvApproveLeave.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;

            //StaffLeaveController staffLeaveController = ControllerFactory.CreateStaffLeaveControllerImpl();
            //staffLeaveList = staffLeaveController.getStaffLeaves(true);

            Response.Redirect("RecommendationLeaveView.aspx?EmpId=" + staffLeaveList[rowIndex].EmployeeId.ToString() + "&Id=" + staffLeaveList[rowIndex].StaffLeaveId);


        }

        protected void gvApproveLeave_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = DateTime.Parse(e.Row.Cells[0].Text).ToShortDateString();
                e.Row.Cells[1].Text = DateTime.Parse(e.Row.Cells[1].Text).ToShortDateString();
            }
        }

        protected void gvApproveLeave_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvApproveLeave.PageIndex = e.NewPageIndex;
            this.bindDataSource();
        }
    }
}