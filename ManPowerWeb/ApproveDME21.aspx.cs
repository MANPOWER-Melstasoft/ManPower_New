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
    public partial class ApproveDME21 : System.Web.UI.Page
    {
        public int positionID;
        List<TaskAllocation> taskAllocationList = new List<TaskAllocation>();
        List<SystemUser> systemUserList = new List<SystemUser>();
        protected void Page_Load(object sender, EventArgs e)
        {
            positionID = Convert.ToInt32(Session["DepUnitPositionId"]);
            BindDataSource();

        }

        public void BindDataSource()
        {
            TaskAllocationController allocation = ControllerFactory.CreateTaskAllocationController();

            SystemUserController SystemUser = ControllerFactory.CreateSystemUserController();

            taskAllocationList = allocation.GetTaskAllocationDme21Approve(positionID);
            systemUserList = SystemUser.GetAllSystemUser(false, false, false);

            foreach (var item in taskAllocationList)
            {
                item._SystemUser = systemUserList.Where(x => x.SystemUserId == item._DepartmentUnitPositions.SystemUserId).Single();
            }

            gvDME21Approve.DataSource = taskAllocationList;
            gvDME21Approve.DataBind();
        }

        protected void btnAction_Click(object sender, EventArgs e)
        {

            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            string url = "ApproveDME21Render.aspx?" + "taskAllocationID=" + taskAllocationList[rowIndex].TaskAllocationId;
            Response.Redirect(url);
        }
    }
}