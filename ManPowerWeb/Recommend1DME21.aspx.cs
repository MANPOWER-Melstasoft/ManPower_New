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
    public partial class Recommend1_DME21 : System.Web.UI.Page
    {
        public int positionID;
        List<TaskAllocation> taskAllocationList = new List<TaskAllocation>();

        protected void Page_Load(object sender, EventArgs e)
        {
            positionID = Convert.ToInt32(Session["DepUnitPositionId"]);
            BindDataSource();

        }

        public void BindDataSource()
        {
            TaskAllocationController allocation = ControllerFactory.CreateTaskAllocationController();

            taskAllocationList = allocation.GetRecommend1TaskAllocation(positionID);

            gvDME21Recommend1.DataSource = taskAllocationList;
            gvDME21Recommend1.DataBind();
        }

        protected void btnAction_Click(object sender, EventArgs e)
        {

            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            string url = "Recommend1dme21Render.aspx?" + "taskAllocationID=" + taskAllocationList[rowIndex].TaskAllocationId;
            Response.Redirect(url);
        }
    }
}