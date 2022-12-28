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
    public partial class Recommend2DME21 : System.Web.UI.Page
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

            taskAllocationList = allocation.GetRecommend2TaskAllocation(positionID);

            gvDME21Recommend2.DataSource = taskAllocationList;
            gvDME21Recommend2.DataBind();
        }

        protected void btnAction_Click(object sender, EventArgs e)
        {

            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            string url = "Recommend2dme21Render.aspx?" + "taskAllocationID=" + taskAllocationList[rowIndex].TaskAllocationId;
            Response.Redirect(url);
        }
    }
}