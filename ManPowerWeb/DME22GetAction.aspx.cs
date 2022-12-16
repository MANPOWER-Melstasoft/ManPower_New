using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class DME22GetAction : System.Web.UI.Page
    {
        private string selectedYear = DateTime.Now.AddMonths(1).ToString("yyyy");
        private string monthName = DateTime.Now.AddMonths(1).ToString("MMMM");
        List<TaskAllocationDetail> taskallocationDetailList = new List<TaskAllocationDetail>();
        public int taskAllocationId;

        TaskAllocationDetailController taskAllocationDetail = ControllerFactory.CreateTaskAllocationDetailController();
        public string Year { get { return selectedYear; } }
        public string Month { get { return monthName; } }

        public string Remark;
        protected void Page_Load(object sender, EventArgs e)
        {
            taskAllocationId = Convert.ToInt32(Request.QueryString["taskAllocationId"]);

            if (!IsPostBack)
            {
                BindDataSource();
            }
        }

        public void BindDataSource()
        {
            taskallocationDetailList = taskAllocationDetail.GetAllTaskAllocationDetailByTaskAllocationId(taskAllocationId);

            DME22GetActionGridView.DataSource = taskallocationDetailList;
            DME22GetActionGridView.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            //int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            //int taskAllocationDetailID = taskallocationDetailList[rowIndex].TaskAllocationDetailId;

            //TaskAllocationDetail taskAllocationDetailObject = new TaskAllocationDetail();
            taskallocationDetailList = taskAllocationDetail.GetAllTaskAllocationDetailByTaskAllocationId(taskAllocationId);

            for (int rowIndex = 0; rowIndex < DME22GetActionGridView.Rows.Count; rowIndex++)
            {

                taskallocationDetailList[rowIndex].TaskAllocationDetailId = taskallocationDetailList[rowIndex].TaskAllocationDetailId;
                taskallocationDetailList[rowIndex].TaskTypeId = taskallocationDetailList[rowIndex].TaskTypeId;
                taskallocationDetailList[rowIndex].TaskAllocationId = taskallocationDetailList[rowIndex].TaskAllocationId;
                taskallocationDetailList[rowIndex].TaskDescription = taskallocationDetailList[rowIndex].TaskDescription;
                taskallocationDetailList[rowIndex].WorkLocation = taskallocationDetailList[rowIndex].WorkLocation;
                taskallocationDetailList[rowIndex].Isconmpleated = int.Parse(((DropDownList)DME22GetActionGridView.Rows[rowIndex].FindControl("ddlStatus")).SelectedValue);
                taskallocationDetailList[rowIndex].NotCompleatedReason = ((TextBox)DME22GetActionGridView.Rows[rowIndex].FindControl("txtRemark")).Text; ;
                taskallocationDetailList[rowIndex].StartTime = taskallocationDetailList[rowIndex].StartTime;
                taskallocationDetailList[rowIndex].EndTime = taskallocationDetailList[rowIndex].EndTime;
                taskallocationDetailList[rowIndex].TaskRemarks = taskallocationDetailList[rowIndex].TaskRemarks;
                taskallocationDetailList[rowIndex].TaskAmendments = "";

                taskAllocationDetail.UpdateTaskAllocationDetail(taskallocationDetailList[rowIndex]);
            }

            string url = "DME22.aspx";
            Response.Redirect(url);
        }


    }
}