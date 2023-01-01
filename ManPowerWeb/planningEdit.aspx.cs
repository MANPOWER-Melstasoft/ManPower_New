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
        List<ProgramPlan> programPlansList = new List<ProgramPlan>();
        List<ProgramPlan> programPlansListBind = new List<ProgramPlan>();


        int programTargetId;
        int programPlanId;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                if (Request.QueryString["ProgramTargetId"] != null)
                {
                    programTargetId = Convert.ToInt32(Request.QueryString["ProgramTargetId"]);
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


            txtManger.Text = programPlanId.ToString();
            ddlResourcePerson.DataSource = resourcePeopleList;
            ddlResourcePerson.DataValueField = "ResoursePersonId";
            ddlResourcePerson.DataTextField = "Name";
            ddlResourcePerson.DataBind();

            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();


            programPlansList = programPlanController.GetAllProgramPlan();

            programPlansListBind = programPlansList.Where(x => x.ProgramPlanId == programPlanId).ToList();

            txtProgramName.Text = programPlansListBind[0].ProgramName;
            txtDate.Text = programPlansListBind[0].Date.ToString("yyyy-MM-dd");
            txtBudget.Text = programPlansListBind[0].ApprovedAmount.ToString();
            txtFemaleCount.Text = programPlansListBind[0].FemaleCount.ToString();
            txtMaleCount.Text = programPlansListBind[0].MaleCount.ToString();
            txtLocation.Text = programPlansListBind[0].Location.ToString();
            if (programPlansListBind[0].Coordinater != null)
            {
                ddlResourcePerson.Text = programPlansListBind[0].Coordinater.ToString();

            }
            txtEstimateAmount.Text = Request.QueryString["EstimateAmount"];




        }



        protected void btnSave_Click1(object sender, EventArgs e)
        {
            bool validationflag = false;
            ProgramPlan programPlan = new ProgramPlan();
            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();


            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
            programTargets = programTargetController.GetAllProgramTargetWithPlan();

            programPlanId = Convert.ToInt32(Request.QueryString["ProgramplanId"]);
            programPlanId = Convert.ToInt32(Request.QueryString["ProgramplanId"]);
            programTargetId = Convert.ToInt32(Request.QueryString["ProgramTargetId"]);



            programPlan.ProjectStatusId = 2;

            programPlan.ProgramName = txtProgramName.Text;
            programPlan.FinancialSource = "";
            programPlan.ProgramCategoryId = 1;
            programPlan.Location = txtLocation.Text;
            programPlan.Outcome = 0;
            programPlan.Output = 0;
            programPlan.ActualOutput = 0;
            programPlan.IsApproved = 0;
            programPlan.ApprovedBy = "";
            programPlan.ApprovedDate = DateTime.Now;
            programPlan.TotalEstimatedAmount = (float)Convert.ToDouble(txtEstimateAmount.Text);

            if ((float)Convert.ToDouble(txtEstimateAmount.Text) > (float)Convert.ToDouble(txtBudget.Text))
            {
                programPlan.ApprovedAmount = (float)Convert.ToDouble(txtBudget.Text);
                validationflag = true;
            }
            else
            {
                lblBudget.Text = "Invalid Budget";
                validationflag = false;

            }
            programPlan.ActualAmount = 0;
            programPlan.MaleCount = int.Parse(txtMaleCount.Text);
            programPlan.FemaleCount = int.Parse(txtFemaleCount.Text);
            programPlan.Remark = "";
            programPlan.ProgramTargetId = programTargetId;
            programPlan.Coordinater = ddlResourcePerson.SelectedItem.Text;
            programPlan.ProgramPlanId = programPlanId;


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
                validationflag = false;
            }


            if (validationflag)
            {
                programPlan.Date = DateTime.Parse(txtDate.Text);


                int response = programPlanController.UpdateProgramPlan(programPlan);
                if (response != 0)
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success')", true);
                    Response.Redirect("planning.aspx");

                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);
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
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Completed!', 'Program plan Completed !', 'success')", true);

                Response.Redirect("planning.aspx");

            }
        }


    }
}