using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class AnnualTargetRecomendationView : System.Web.UI.Page
    {
        int ProgramTargetId;

        List<ProgramTarget> programTargetsList = new List<ProgramTarget>();
        List<ProgramTarget> myList = new List<ProgramTarget>();
        List<ProgramType> listProgramType = new List<ProgramType>();
        List<Possitions> PositionList = new List<Possitions>();
        List<Program> program = new List<Program>();
        List<DepartmentUnitPositions> listUser = new List<DepartmentUnitPositions>();
        protected void Page_Load(object sender, EventArgs e)
        {

            ProgramTypeController programTypeController = ControllerFactory.CreateProgramTypeController();
            listProgramType = programTypeController.GetAllProgramType(false);
            ddlProgramType.DataSource = listProgramType;
            ddlProgramType.DataTextField = "ProgramTypeName";
            ddlProgramType.DataValueField = "ProgramTypeId";
            ddlProgramType.DataBind();

            bindData();
            int status = Convert.ToInt32(Request.QueryString["Status"]);
            if (status == 1)
            {
                btnAccept.Visible = true;
                btnModalReject.Visible = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            Response.Redirect("AnnualTargetRecomendation.aspx");

        }
        private void bindData()
        {
            ProgramTargetId = Convert.ToInt32(Request.QueryString["ProgramTargetId"]);

            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            programTargetsList = programTargetController.GetAllProgramTarget(true, true, true, true);



            ProgramController programController = ControllerFactory.CreateProgramController();
            program = programController.GetAllProgram(false, false);
            ddlProgram.DataSource = program;
            ddlProgram.DataTextField = "ProgramName";
            ddlProgram.DataValueField = "ProgramId";
            ddlProgram.DataBind();

            foreach (var i in programTargetsList.Where(u => u.ProgramTargetId == ProgramTargetId))
            {
                myList.Add(i);
            }

            ddlYear.SelectedValue = Convert.ToString(myList[0].TargetYear);
            ddlMonth.Text = myList[0].TargetMonth.ToString();
            txtDescription.Text = myList[0].Description;
            ddlMonth.Text = myList[0].TargetMonth.ToString();
            txtInstructions.Text = myList[0].Instractions.ToString();
            txtOutcome.Text = myList[0].Outcome.ToString();
            txtOutput.Text = myList[0].Output.ToString();
            txtPhysicalCount.Text = myList[0].NoOfProjects.ToString();
            ddlProgramType.SelectedValue = myList[0].ProgramTypeId.ToString();
            ddlProgram.SelectedValue = myList[0].ProgramId.ToString();

            txtVote.Text = myList[0].VoteNumber;

        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            int TargetResponse = programTargetController.UpdateProgramTargetApproval(ProgramTargetId, 2, "");

            if (TargetResponse != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success')", true);


            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);
            }

            Response.Redirect("AnnualTargetRecomendation.aspx");


        }


        protected void btnReject_Click1(object sender, EventArgs e)
        {
            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            int TargetResponse = programTargetController.UpdateProgramTargetApproval(ProgramTargetId, 3, txtrejectReason.Text);

            if (TargetResponse != 0)
            {

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Rejected Succesfully!', 'success')", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);
            }

            Response.Redirect("AnnualTargetRecomendation.aspx");

        }
    }
}