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
    public partial class DME23UsersRender : System.Web.UI.Page
    {

        public int depId;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            bindDataSource();
            depId = Convert.ToInt32(Request.QueryString["departmentUnitPositionId"]);
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