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
    public partial class ProgramTargetView : System.Web.UI.Page
    {
        ProgramTarget pt = new ProgramTarget();
        Program p = new Program();
        ProgramAssignee pa = new ProgramAssignee();

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            ProgramAssigneeController programAssigneeController = ControllerFactory.CreateProgramAssigneeController();
            pa = programAssigneeController.GetProgramAssignee(int.Parse(id),true,false,false);

            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            pt = programTargetController.GetProgramTarget(int.Parse(id),false, false, true, false) ;

            ProgramController programCntroller = ControllerFactory.CreateProgramController();
            p = programCntroller.GetProgram(pt.ProgramId,false);

            if (pt.ProgramTypeId == 1)
            {
                type.Text = "Online";
            }
            else
            {
                type.Text = "Physical";
            }

            year.Text = pt.TargetYear.ToString();
            programName.Text = p.ProgramName;
            txtInstructions.Text = pt.Instractions;
            txtDescription.Text = pt.Description;
            txtVote.Text = pt.VoteNumber;
            month.Text = pt.TargetMonth.ToString();
            txtPhysicalCount.Text = pt.NoOfProjects.ToString();
            txtFinancialCount.Text = pt.EstimatedAmount.ToString();
            txtOutput.Text = pt.Output.ToString();
            txtOutcome.Text = pt.Outcome.ToString();
            txtRemarks.Text = pt.Remarks;
        }

        protected void ToAnnualTarget(object sender, EventArgs e)
        {
            Response.Redirect("AnnualTarget.aspx");
        }

        protected void ToUpcommingProgram(object sender, EventArgs e)
        {
            Response.Redirect("UpcomingPrograms.aspx");
        }
    }
}