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
    public partial class ViewNewlyAddedProgramTarget : System.Web.UI.Page
    {


        List<ProgramTarget> programTargetsList = new List<ProgramTarget>();
        List<DepartmentUnitPositions> DepartmentUnitPositionsList = new List<DepartmentUnitPositions>();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDataSource();
            }
        }

        private void bindDataSource()
        {
            int systemUserId = Convert.ToInt32(Session["UserId"]);

            DepartmentUnitPositionsList = ControllerFactory.CreateDepartmentUnitPositionsController().GetAllUsersBySystemUserId(systemUserId);

            int departmentUnitPositionId = DepartmentUnitPositionsList[0].DepartmetUnitPossitionsId;

            programTargetsList = ControllerFactory.CreateProgramTargetController().GetAllProgramTarget(false, false, true, false);

            gvProgramTargetNotification.DataSource = programTargetsList.Where(x => x.IsRecommended == 2 && x._ProgramAssignee[0].DepartmentUnitPossitionsId == departmentUnitPositionId && x._ProgramAssignee[0].Is_View == 0);
            gvProgramTargetNotification.DataBind();

        }
    }
}