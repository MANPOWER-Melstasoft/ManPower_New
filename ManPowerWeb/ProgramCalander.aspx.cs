
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
    public partial class ProgramCalander : System.Web.UI.Page
    {
        List<ProgramPlan> planList = new List<ProgramPlan>();
        List<ProgramPlan> planListFilter = new List<ProgramPlan>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                calanderBind();
            }


        }


        private void calanderBind()
        {

            Calendar1.FirstDayOfWeek = FirstDayOfWeek.Sunday;
            Calendar1.NextPrevFormat = NextPrevFormat.FullMonth;
            Calendar1.TitleFormat = TitleFormat.MonthYear;
            Calendar1.ShowGridLines = true;
            Calendar1.DayStyle.Height = new Unit(100);
            Calendar1.DayStyle.Width = new Unit(200);
            Calendar1.DayStyle.HorizontalAlign = HorizontalAlign.Center;
            Calendar1.DayStyle.VerticalAlign = VerticalAlign.Middle;
            Calendar1.OtherMonthDayStyle.BackColor = System.Drawing.Color.AliceBlue;
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {

            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            planList = programPlanController.GetAllProgramPlan();

            Literal literal1 = new Literal();
            literal1.Text = "<br/>";
            e.Cell.Controls.Add(literal1);
            Label label1 = new Label();
            DateTime dates = e.Day.Date;
            string datesString = dates.ToShortDateString();
            planListFilter = planList.Where(u => u.Date.ToShortDateString() == datesString).ToList();

            if (planListFilter.Count > 0)
            {
                label1.Text = planListFilter[0].Output.ToString();
                if (planListFilter[0].ProjectStatusId == 4)
                {
                    label1.ForeColor = System.Drawing.Color.Red;

                }
                label1.ForeColor = System.Drawing.Color.Black;

            }
            label1.Font.Size = new FontUnit(FontSize.Small);
            e.Cell.Controls.Add(label1);
        }

        protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {

        }
    }
}