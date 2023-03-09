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
    public partial class DME23Users : System.Web.UI.Page
    {
        List<SystemUser> systemUserList = new List<SystemUser>();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataSource();
        }

        public void BindDataSource()
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();

            systemUserList = systemUserController.GetAllSystemUser(true, false, false);

            systemUserList = systemUserList.Where(x => x.UserTypeId == 3).ToList();

            gvDME23Users.DataSource = systemUserList;
            gvDME23Users.DataBind();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            string url = "DME23UsersRender.aspx?" + "departmentUnitPositionId=" + systemUserList[rowIndex]._DepartmentUnitPositions.DepartmetUnitPossitionsId;
            Response.Redirect(url);
        }
    }
}