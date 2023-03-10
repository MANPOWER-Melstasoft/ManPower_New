
using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ManPowerWeb
{
    public partial class ProgramCalander : System.Web.UI.Page
    {
        List<ProgramPlan> planList = new List<ProgramPlan>();
        List<ProgramPlan> planListFilter = new List<ProgramPlan>();
        List<TaskAllocationDetail> taskAllocationDetail = new List<TaskAllocationDetail>();
        List<TaskAllocationDetail> taskAllocationDetailFilter = new List<TaskAllocationDetail>();
        List<ProgramPlan> programPlans = new List<ProgramPlan>();
        List<ProgramPlan> programPlansFilterWithSystemUser = new List<ProgramPlan>();
        List<ProgramPlan> programPlansFilterWithProgramPlanId = new List<ProgramPlan>();
        List<ProgramAssignee> programAssignees = new List<ProgramAssignee>();
        int PrTargetId;
        string prName;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

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
            e.Day.IsSelectable = false;
            TaskAllocationDetailController taskAllocationDetailController = ControllerFactory.CreateTaskAllocationDetailController();
            taskAllocationDetail = taskAllocationDetailController.GetAllTaskAllocationDetail(true, false, true);
            Literal literal1 = new Literal();
            literal1.Text = "<br/>";
            e.Cell.Controls.Add(literal1);
            Label label1 = new Label();
            DateTime dates = e.Day.Date;
            string datesString = dates.ToShortDateString();
            taskAllocationDetailFilter = taskAllocationDetail.Where(x => x.StartTime.ToShortDateString() == datesString && x._TaskAllocation.DepartmetUnitPossitionsId == Convert.ToInt32(Session["DepUnitPositionId"])).ToList();

            if (taskAllocationDetailFilter.Count > 0)
            {
                //label1.Text = taskAllocationDetailFilter[0].TaskDescription;
                ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();



                programPlans = programPlanController.GetAllProgramPlan();




                foreach (TaskAllocationDetail row in taskAllocationDetailFilter)
                {
                    label1.Font.Size = new FontUnit(FontSize.Small);

                    if (row.TaskTypeId == 1 && row._ProjectTask.Count > 0)
                    {
                        programPlansFilterWithProgramPlanId = programPlans.Where(x => x.ProgramPlanId == row._ProjectTask[0].ProgramPlanId).ToList();
                        HyperLink the_url = new HyperLink();
                        PrTargetId = programPlansFilterWithProgramPlanId[0].ProgramTargetId;
                        prName = programPlansFilterWithProgramPlanId[0].ProgramName;

                        the_url.NavigateUrl = "planningEdit.aspx?ProgramTargetId=" + PrTargetId + "&ProgramName=" + prName + "&ProgramplanId=" + row._ProjectTask[0].ProgramPlanId;

                        the_url.Text = row.TaskDescription;

                        e.Cell.Controls.Add(the_url);
                        Label lblSpace = new Label();
                        lblSpace.Text = "<br/>";
                        e.Cell.Controls.Add(lblSpace);

                    }
                    else
                    {
                        Label lblProgram = new Label();
                        Label lblSpace = new Label();
                        lblSpace.Text = "<br/>";
                        lblProgram.Text = row.TaskDescription;
                        lblProgram.Font.Size = new FontUnit(FontSize.Small);
                        lblProgram.Font.Bold = true;
                        e.Cell.Controls.Add(lblProgram);
                        e.Cell.Controls.Add(lblSpace);

                    }
                }

                //if (taskAllocationDetailFilter[0] == 4)
                //{
                //    label1.ForeColor = System.Drawing.Color.Red;

                //}
                //label1.ForeColor = System.Drawing.Color.Black;

            }



        }

        protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {

        }
    }
}