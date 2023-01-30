using ManPowerCore.Common;
using ManPowerCore.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class DME23 : System.Web.UI.Page
    {
        private string officerName;
        private string userId;

        public int depId;

        public string OfficerName { get { return officerName; } }
        public string UserId { get { return userId; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            officerName = Session["Name"].ToString();
            userId = Session["UserId"].ToString();
            depId = Convert.ToInt32(Session["DepUnitPositionId"]);

            bindDataSource();
        }

        private void bindDataSource()
        {
            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();

            DataTable programPlan = programPlanController.getProgramPlan(depId);

            gvDme23.DataSource = programPlan;
            gvDme23.DataBind();
        }
    }
}