using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
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
        List<DistrictTASummaryReport> districtTASummariesList = new List<DistrictTASummaryReport>();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataSource();
        }

        public void BindDataSource()
        {
            DistrictTASummaryController districtTASummaryController = ControllerFactory.CreateDistrictTASummaryController();

            districtTASummariesList = districtTASummaryController.GetDistrictTASummaryReport();

            gvTASummary.DataSource = districtTASummariesList;
            gvTASummary.DataBind();
        }
    }
}