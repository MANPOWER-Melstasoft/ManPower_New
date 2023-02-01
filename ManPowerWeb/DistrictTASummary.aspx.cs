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
    public partial class DistrictTASummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataSource();
        }

        public void BindDataSource()
        {
            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();

            DataTable programTargetReport = programTargetController.getProgramTragetReport();

            gvTASummary.DataSource = programTargetReport;
            gvTASummary.DataBind();
        }
    }
}