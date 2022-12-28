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
    public partial class DMe21FrontRender : System.Web.UI.Page
    {
        public int taskAllocationId;

        List<TaskAllocationDetail> listTaskAllocationDetail = new List<TaskAllocationDetail>();
        protected void Page_Load(object sender, EventArgs e)
        {
            taskAllocationId = Convert.ToInt32(Request.QueryString["taskAllocationID"]);
            BindDataSource();
        }

        public void BindDataSource()
        {
            TaskAllocationDetailController taskAllocationDetailController = ControllerFactory.CreateTaskAllocationDetailController();

            listTaskAllocationDetail = taskAllocationDetailController.GetAllTaskAllocationDetailByTaskAllocationId(taskAllocationId);

            gvDme21Render.DataSource = listTaskAllocationDetail;
            gvDme21Render.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string url = "Dme21Front.aspx";
            Response.Redirect(url);
        }
    }
}