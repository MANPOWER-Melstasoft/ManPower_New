using iTextSharp.xmp.impl;
using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using Microsoft.Ajax.Utilities;
using Org.BouncyCastle.Ocsp;
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
        ProgramTarget programTarget = new ProgramTarget();
        List<ProgramPlan> programPlansList = new List<ProgramPlan>();
        List<ProgramPlan> programPlansListBind = new List<ProgramPlan>();
        SystemUser systemUser = new SystemUser();
        List<string> projectPlanResourceStringList = new List<string>();
        List<ProjectPlanResource> projectPlanResourcesList = new List<ProjectPlanResource>();

        public string name;

        int programTargetId;
        int programPlanId;
        int RecommendedBy;

        protected void Page_Load(object sender, EventArgs e)
        {
            name = Session["Name"].ToString();
            programTargetId = Convert.ToInt32(Request.QueryString["ProgramTargetId"]);
            programPlanId = Convert.ToInt32(Request.QueryString["ProgramplanId"]);

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
            resourcePeopleList = resourcePersonController.GetAllResourcePerson(false);

            ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();

            programTarget = programTargetController.GetProgramTarget(Convert.ToInt32(Request.QueryString["ProgramTargetId"]));
            ViewState["programTarget"] = programTarget;
            programPlanId = Convert.ToInt32(Request.QueryString["ProgramplanId"]);


            RecommendedBy = programTarget.RecommendedBy;
            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            systemUser = systemUserController.GetSystemUser(RecommendedBy, false, false, false);

            ViewState["programTargetId"] = programTargetId;


            txtManger.Text = systemUser.Name;
            //ddlResourcePerson.DataSource = resourcePeopleList;
            //ddlResourcePerson.DataValueField = "ResoursePersonId";
            //ddlResourcePerson.DataTextField = "Name";
            //ddlResourcePerson.DataBind();

            chkList.DataSource = resourcePeopleList;
            chkList.DataValueField = "ResoursePersonId";
            chkList.DataTextField = "Name";
            chkList.DataBind();

            ProjectPlanResourceController projectPlanResourceController = ControllerFactory.CreateProjectPlanResourceController();
            projectPlanResourcesList = projectPlanResourceController.GetAllProjectPlanResourcesByProgramPlanId(programPlanId);



            foreach (var item in projectPlanResourcesList)
            {


                for (int i = 0; i < chkList.Items.Count; i++)
                {
                    if (chkList.Items[i].Value == item.ResourcePersonId.ToString())
                    {
                        chkList.Items[i].Selected = true;
                    }
                }
            }




            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            programPlansList = programPlanController.GetAllProgramPlan();

            programPlansListBind = programPlansList.Where(x => x.ProgramPlanId == programPlanId).ToList();

            txtProgramName.Text = programPlansListBind[0].ProgramName;
            txtDate.Text = programPlansListBind[0].Date.ToString("yyyy-MM-dd");
            txtBudget.Text = programPlansListBind[0].ApprovedAmount.ToString();
            txtFemaleCount.Text = programPlansListBind[0].FemaleCount.ToString();
            txtMaleCount.Text = programPlansListBind[0].MaleCount.ToString();
            txtLocation.Text = programPlansListBind[0].Location.ToString();

            txtEstimateAmount.Text = programTarget.EstimatedAmount.ToString();

            if (programPlansListBind[0].ProjectStatusId == 4)
            {
                btnComplete.Visible = false;
                btnSave.Visible = false;
            }
            else
            {
                btnComplete.Visible = true;
                btnSave.Visible = true;
            }




        }

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            ProgramAssigneeController programAssigneeController = ControllerFactory.CreateProgramAssigneeController();
            ProgramAssignee programAssigneeObj = new ProgramAssignee();
            int depid;

            programAssigneeObj = programAssigneeController.GetProgramAssignee().Where(x => x.ProgramTargetId == programTargetId).Single();

            depid = programAssigneeObj.DepartmentUnitPossitionsId;

            int flag1 = 0;

            TaskAllocationController taskAllocationController = ControllerFactory.CreateTaskAllocationController();

            List<TaskAllocation> taskAllocationList = taskAllocationController.GetAllTaskAllocationByDepartmentUnitPositionId(depid);

            TaskAllocationDetailController taskAllocationDetailController = ControllerFactory.CreateTaskAllocationDetailController();
            TaskAllocationDetail taskAllocationDetailObj = new TaskAllocationDetail();

            TaskAllocation taskAllocationObj = new TaskAllocation();

            List<TaskAllocationDetail> taskAllocationDetailList1 = taskAllocationDetailController.GetAllTaskAllocationDetail();

            foreach (var item in taskAllocationDetailList1)
            {
                if (item.TaskTypeId == 1 && item.programPlanId == programPlanId)
                {
                    taskAllocationDetailController.DeleteTaskAllocationDetail(item.TaskAllocationDetailId);
                }
            }

            foreach (var item in taskAllocationList)
            {
                if (item.TaskYearMonth.Month == Convert.ToDateTime(txtDate.Text).Month && item.TaskYearMonth.Year == Convert.ToDateTime(txtDate.Text).Year)
                {
                    taskAllocationObj = item;
                    break;
                }
            }

            int taskAllocationId = taskAllocationObj.TaskAllocationId;

            if (taskAllocationId != 0)
            {
                List<TaskAllocationDetail> taskAllocationDetailList = taskAllocationDetailController.GetAllTaskAllocationDetailByTaskAllocationId(taskAllocationId);

                foreach (var item in taskAllocationDetailList)
                {
                    if (item.StartTime.Year == Convert.ToDateTime(txtDate.Text).Year && item.StartTime.Month == Convert.ToDateTime(txtDate.Text).Month && item.StartTime.Date == Convert.ToDateTime(txtDate.Text).Date)
                    {
                        flag1 = 1; break;
                    }
                }

                if (flag1 == 1)
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "alert", "swal('Failed!', 'You Have a task on That Date! (DME21)', 'error')", true);
                }

                else
                {
                    bool validationflag = false;
                    ProgramPlan programPlan = new ProgramPlan();
                    ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();


                    //   ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
                    //  programTargets = programTargetController.GetAllProgramTargetWithPlan();

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

                    if ((float)Convert.ToDouble(txtEstimateAmount.Text) >= (float)Convert.ToDouble(txtBudget.Text))
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
                    programPlan.Coordinater = "";
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

                    ProgramTarget programTargetState = (ProgramTarget)ViewState["programTarget"];
                    if (DateTime.Parse(txtDate.Text) <= DateTime.Now || DateTime.Parse(txtDate.Text) <= programTargetState.StartDate || DateTime.Parse(txtDate.Text) >= programTargetState.EndDate)
                    {
                        lblDate.Text = "Invalid Date";
                        validationflag = false;
                    }


                    if (validationflag)
                    {
                        programPlan.Date = DateTime.Parse(txtDate.Text);


                        int response = programPlanController.UpdateProgramPlan(programPlan, (List<string>)ViewState["projectPlanResourceStringList"]);

                        taskAllocationDetailObj.TaskTypeId = 1;
                        taskAllocationDetailObj.TaskAllocationId = taskAllocationId;
                        taskAllocationDetailObj.TaskDescription = "";
                        taskAllocationDetailObj.WorkLocation = txtLocation.Text;
                        taskAllocationDetailObj.Isconmpleated = 0;
                        taskAllocationDetailObj.NotCompleatedReason = "";
                        taskAllocationDetailObj.StartTime = Convert.ToDateTime(txtDate.Text);
                        taskAllocationDetailObj.EndTime = DateTime.Today;
                        taskAllocationDetailObj.TaskRemarks = "";
                        taskAllocationDetailObj.TaskAmendments = "";
                        taskAllocationDetailObj.programPlanId = programPlanId;

                        taskAllocationDetailController.SaveTaskAllocationDetail(taskAllocationDetailObj);

                        if (response != 0)
                        {

                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success');window.setTimeout(function(){window.location='planning.aspx'},2500);", true);

                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);
                        }
                    }

                }
            }

            else
            {
                bool validationflag = false;
                ProgramPlan programPlan = new ProgramPlan();
                ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();


                //   ProgramTargetController programTargetController = ControllerFactory.CreateProgramTargetController();
                //  programTargets = programTargetController.GetAllProgramTargetWithPlan();

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

                if ((float)Convert.ToDouble(txtEstimateAmount.Text) >= (float)Convert.ToDouble(txtBudget.Text))
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
                programPlan.Coordinater = "";
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

                ProgramTarget programTargetState = (ProgramTarget)ViewState["programTarget"];
                if (DateTime.Parse(txtDate.Text) <= DateTime.Now || DateTime.Parse(txtDate.Text) <= programTargetState.StartDate || DateTime.Parse(txtDate.Text) >= programTargetState.EndDate)
                {
                    lblDate.Text = "Invalid Date";
                    validationflag = false;
                }


                if (validationflag)
                {
                    programPlan.Date = DateTime.Parse(txtDate.Text);


                    int response = programPlanController.UpdateProgramPlan(programPlan, (List<string>)ViewState["projectPlanResourceStringList"]);

                    taskAllocationObj.DepartmetUnitPossitionsId = depid;
                    taskAllocationObj.TaskYearMonth = Convert.ToDateTime(txtDate.Text);
                    taskAllocationObj.CreatedDate = DateTime.Today.Date;
                    taskAllocationObj.CreatedUser = name;
                    taskAllocationObj.StatusId = 0;
                    taskAllocationObj.DME21RecommendedBy1 = 0;
                    taskAllocationObj.RecommendedDate = DateTime.Today;
                    taskAllocationObj.DME21ApprovedBy = 0;
                    taskAllocationObj.ApprovedDate = DateTime.Today;
                    taskAllocationObj.DME21RecommendedBy2 = 0;
                    taskAllocationObj.DME22_ApprovedBy = 0;

                    int taskAllocationId1 = taskAllocationController.saveTaskAllocation(taskAllocationObj);

                    taskAllocationDetailObj.TaskTypeId = 1;
                    taskAllocationDetailObj.TaskAllocationId = taskAllocationId1;
                    taskAllocationDetailObj.TaskDescription = "";
                    taskAllocationDetailObj.WorkLocation = txtProgramName.Text;
                    taskAllocationDetailObj.Isconmpleated = 0;
                    taskAllocationDetailObj.NotCompleatedReason = "";
                    taskAllocationDetailObj.StartTime = Convert.ToDateTime(txtDate.Text);
                    taskAllocationDetailObj.EndTime = DateTime.Today;
                    taskAllocationDetailObj.TaskRemarks = "";
                    taskAllocationDetailObj.TaskAmendments = "";
                    taskAllocationDetailObj.programPlanId = programPlanId;

                    taskAllocationDetailController.SaveTaskAllocationDetail(taskAllocationDetailObj);

                    if (response != 0)
                    {

                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success');window.setTimeout(function(){window.location='planning.aspx'},2500);", true);

                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);
                    }
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

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Program plan Completed!', 'success');window.setTimeout(function(){window.location='planning.aspx'},2500);", true);

            }
        }

        protected void chkList_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < chkList.Items.Count; i++)
            {
                if (chkList.Items[i].Selected == true)// getting selected value from CheckBox List  
                {
                    projectPlanResourceStringList.Add(chkList.Items[i].Value); // add selected Item text to the String .  
                }

            }

            ViewState["projectPlanResourceStringList"] = projectPlanResourceStringList.ToList();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("planning.aspx");
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string str = "";

        //    for (int i = 0; i < chkList.Items.Count; i++)
        //    {
        //        if (chkList.Items[i].Selected == true)// getting selected value from CheckBox List  
        //        {
        //            str += chkList.Items[i].Text + " ," + "<br/>"; // add selected Item text to the String .  
        //        }


        //    }
        //    if (str != "")
        //    {
        //        str = str.Substring(0, str.Length - 7); // Remove Last "," from the string .  
        //        lblmsg.Text = "Selected Cities are <br/><br/>" + str; // Show selected Item List by Label.  
        //    }
        //}
    }
}