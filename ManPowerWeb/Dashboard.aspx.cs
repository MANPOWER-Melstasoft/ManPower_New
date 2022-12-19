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
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                if (!IsPostBack)
                {
                    BindCardData();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void BindCardData()
        {
            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            List<SystemUser> systemUserList = systemUserController.GetAllSystemUser(false, false, false);
            lblNumberOfEmp.Text = systemUserList.Count.ToString();

            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            List<ProgramTarget> programTargetsList = programTargetController.GetAllProgramTarget(false, false, false, false);
            int mCount = 0;
            foreach (var i in programTargetsList)
            {
                if (i.TargetMonth == DateTime.Today.Month)
                {
                    mCount++;
                }
            }
            lblThisMonthTarget.Text = mCount.ToString();
        }


    }
}