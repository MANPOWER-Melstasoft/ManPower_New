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
    public partial class AddDME21 : System.Web.UI.Page
    {
        List<TaskType> taskTypeList = new List<TaskType>();
        protected void Page_Load(object sender, EventArgs e)
        {
            TaskTypeController taskTypeController = ControllerFactory.CreateTaskTypeController();
            taskTypeList = taskTypeController.GetAllTaskType(false);
            ddlWorkType.DataSource = taskTypeList;
            ddlWorkType.DataBind();
        }
    }
}