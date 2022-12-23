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
    public partial class LeaveBalance : System.Web.UI.Page
    {
        DataTable leaveTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportController reportController = ControllerFactory.CreateReportController();
            leaveTable = reportController.GetLeaveBalance();





        }
    }
}