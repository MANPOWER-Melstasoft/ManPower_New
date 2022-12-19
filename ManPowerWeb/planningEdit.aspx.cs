using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ManPowerWeb
{
    public partial class planningEdit : System.Web.UI.Page
    {
        List<ResourcePerson> resourcePeopleList = new List<ResourcePerson>();
        List<ProgramTarget> programTargets = new List<ProgramTarget>();
        int programTargetId;
        string programTargetName;
        int programPlanId;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                if (Request.QueryString["ProgramTargetId"] != null)
                {
                    programTargetId = Convert.ToInt32(Request.QueryString["ProgramTargetId"]);
                }
                if (Request.QueryString["ProgramName"] != null)
                {
                    programTargetName = Request.QueryString["ProgramName"];
                }
                if (Request.QueryString["ProgramplanId"] != null)
                {
                    programPlanId = Convert.ToInt32(Request.QueryString["ProgramplanId"]);

                }


                dataSource();

            }

        }
        private void dataSource()
        {

            ResourcePersonController resourcePersonController = ControllerFactory.CreateResourcePersonController();
            resourcePeopleList = resourcePersonController.GetAllResourcePerson();



            ViewState["programTargetId"] = programTargetId;

            txtProgramName.Text = programTargetName;
            txtManger.Text = programPlanId.ToString();
            ddlResourcePerson.DataSource = resourcePeopleList;
            ddlResourcePerson.DataValueField = "ResoursePersonId";
            ddlResourcePerson.DataTextField = "Name";
            ddlResourcePerson.DataBind();
        }



        protected void btnSave_Click1(object sender, EventArgs e)
        {
            ProgramPlan programPlan = new ProgramPlan();
            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();


            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            programTargets = programTargetController.GetAllProgramTargetWithPlan();

            programPlanId = Convert.ToInt32(Request.QueryString["ProgramplanId"]);
            programPlanId = Convert.ToInt32(Request.QueryString["ProgramplanId"]);
            programTargetId = Convert.ToInt32(Request.QueryString["ProgramTargetId"]);



            programPlan.ProjectStatusId = 2;
            programPlan.ProgramName = "";
            programPlan.FinancialSource = "";
            programPlan.ProgramCategoryId = 1;
            programPlan.Location = txtLocation.Text;
            programPlan.Outcome = 0;
            programPlan.Output = 0;
            programPlan.ActualOutput = 0;
            programPlan.IsApproved = 0;
            programPlan.ApprovedBy = "";
            programPlan.ApprovedDate = DateTime.Now;
            programPlan.TotalEstimatedAmount = (float)Convert.ToDouble(txtBudget.Text);
            programPlan.ApprovedAmount = 0;
            programPlan.ActualAmount = 0;
            programPlan.MaleCount = int.Parse(txtMaleCount.Text);
            programPlan.FemaleCount = int.Parse(txtFemaleCount.Text);
            programPlan.Remark = "";
            programPlan.ProgramTargetId = programTargetId;
            programPlan.ProgramName = programTargetName;
            programPlan.Coordinater = ddlResourcePerson.SelectedValue;
            programPlan.ProgramPlanId = programPlanId;

            lblDate.Text = txtDate.Text;

            if (Uploader.HasFile)
            {
                HttpFileCollection uploadFiles = Request.Files;
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile uploadFile = uploadFiles[i];
                    if (uploadFile.ContentLength > 0)
                    {
                        uploadFile.SaveAs(Server.MapPath("~/SystemDocuments/ProgramPlanResources/") + uploadFile.FileName);
                        lblListOfUploadedFiles.Text += String.Format("{0}<br />", uploadFile.FileName);
                        programPlan.FinancialSource = uploadFile.FileName;

                    }
                }
            }

            if (DateTime.Parse(txtDate.Text) <= DateTime.Now)
            {
                lblDate.Text = "Invalid Date";
            }
            else
            {
                programPlan.Date = DateTime.Parse(txtDate.Text);

                int response = programPlanController.UpdateProgramPlan(programPlan);
                if (response != 0)
                {
                    Response.Redirect("planning.aspx");

                }
            }



        }

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();

            programPlanId = Convert.ToInt32(Request.QueryString["ProgramplanId"]);

            int response = programPlanController.UpdateProgramPlanComplete(4, programPlanId);
            if (response != 0)
            {
                Response.Redirect("planning.aspx");

            }
        }


    }
}