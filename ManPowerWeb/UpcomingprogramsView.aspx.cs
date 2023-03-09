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
    public partial class UpcomingprogramsView : System.Web.UI.Page
    {
        List<ProgramPlan> pp = new List<ProgramPlan>();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            ProgramPlanController controller = ControllerFactory.CreateProgramPlanController();
            pp = controller.GetAllProgramPlan(false, false, false, false, false, false);

            string id = Request.QueryString["id"];

            foreach (var i in pp.Where(u => u.ProgramPlanId == int.Parse(id)))
            {
                pName.Text = i.ProgramName;
                place.Text = i.Location;
                date.Text = Convert.ToString(i.Date);
                officer.Text = i.Coordinater;
                male.Text = Convert.ToString(i.MaleCount);
                female.Text = Convert.ToString(i.FemaleCount);
                total.Text = Convert.ToString(i.TotalEstimatedAmount);
                finSource.Text = i.FinancialSource;
                outcome1.Text = Convert.ToString(i.Outcome);
                output1.Text = Convert.ToString(i.Output);
                output2.Text = Convert.ToString(i.ActualOutput);
                amt1.Text = Convert.ToString(i.ApprovedAmount);
                amt2.Text = Convert.ToString(i.ActualAmount);

                if (i.IsApproved == 1)
                {
                    approval.Text = "Yes";
                }
                else
                {
                    approval.Text = "No";
                }

            }
        }

        protected void isClicked(object sender, EventArgs e)
        {
            Response.Redirect("CompletedPrograms.aspx");
        }
    }
}