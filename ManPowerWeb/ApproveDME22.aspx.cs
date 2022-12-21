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
    public partial class ApproveDME22 : System.Web.UI.Page
    {

        public int positionID = 4;
        List<TaskAllocation> taskAllocationList = new List<TaskAllocation>();
        List<SystemUser> systemUserList = new List<SystemUser>();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataSource();
        }

        public void BindDataSource()
        {
            TaskAllocationController allocation = ControllerFactory.CreateTaskAllocationController();

            SystemUserController SystemUser = ControllerFactory.CreateSystemUserController();

            taskAllocationList = allocation.GetTaskAllocationDme22Approve(positionID);
            systemUserList = SystemUser.GetAllSystemUser(false, false, false);

            foreach (var item in taskAllocationList)
            {
                item._SystemUser = systemUserList.Where(x => x.SystemUserId == item._DepartmentUnitPositions.SystemUserId).Single();
            }

            gvDME22Approve.DataSource = taskAllocationList;
            gvDME22Approve.DataBind();
        }

        protected void btnAction_Click(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            string url = "ApproveDME22Render.aspx?" + "taskAllocationID=" + taskAllocationList[rowIndex].TaskAllocationId;
            Response.Redirect(url);
        }
    }
}