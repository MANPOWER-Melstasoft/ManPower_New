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

        bool IsSendToRec = false;

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

                DivAfterComplete.Visible = false;
                divUplaod.Visible = false;

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
            txtTotalCount.Text = (programPlansListBind[0].FemaleCount + programPlansListBind[0].MaleCount).ToString();
            txtLocation.Text = programPlansListBind[0].Location.ToString();
            txtActualOutcome.Text = programPlansListBind[0].Outcome.ToString();
            txtActualOutput.Text = programPlansListBind[0].ActualOutput.ToString();
            txtExpenditure.Text = programPlansListBind[0].ActualAmount.ToString();

            txtEstimateAmount.Text = programTarget.EstimatedAmount.ToString();

            if (programPlansListBind[0].Date <= DateTime.Now)
            {
                if (programPlansListBind[0].ProjectStatusId == 1)
                {
                    btnSave.Visible = true;
                }
                else
                {
                    btnSave.Visible = false;
                }


            }
            else
            {
                if (programPlansListBind[0].ProjectStatusId != 4)
                {
                    btnSave.Visible = true;
                }
                else
                {
                    btnSave.Visible = false;
                }

            }

            if (programPlansListBind[0].ProjectStatusId == 4 || programPlansListBind[0].ProjectStatusId == 1)
            {
                btnSendToRecommendation.Visible = false;


            }

            if (programPlansListBind[0].Date < DateTime.Now && programPlansListBind[0].ProjectStatusId != 1)
            {
                DivAfterComplete.Visible = true;
                divUplaod.Visible = true;
            }





        }

        private void save(bool IsSendToRec)
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

            ProjectTaskController projectTaskController = ControllerFactory.CreateProjectTaskController();

            foreach (var item in taskAllocationDetailList1)
            {

                if (item.TaskTypeId == 1 && item.programPlanId == programPlanId)
                {
                    projectTaskController.DeletefromProgramPlanId(item.programPlanId);
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
                    if (txtActualOutcome.Text != "")
                    {
                        programPlan.Outcome = Convert.ToInt32(txtActualOutcome.Text);

                    }
                    else
                    {
                        programPlan.Outcome = 0;
                    }
                    programPlan.Output = 0;

                    if (txtActualOutput.Text != "")
                    {
                        programPlan.ActualOutput = Convert.ToInt32(txtActualOutput.Text);
                    }
                    else
                    {
                        programPlan.ActualOutput = 0;
                    }

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

                    if (txtExpenditure.Text != "")
                    {
                        programPlan.ActualAmount = float.Parse(txtExpenditure.Text);
                    }
                    else
                    {
                        programPlan.ActualAmount = 0;
                    }

                    if (txtMaleCount.Text != "")
                    {
                        programPlan.MaleCount = int.Parse(txtMaleCount.Text);
                    }
                    else
                    {
                        programPlan.MaleCount = 0;
                    }
                    if (txtFemaleCount.Text != "")
                    {
                        programPlan.FemaleCount = int.Parse(txtFemaleCount.Text);
                    }
                    else
                    {
                        programPlan.FemaleCount = 0;
                    }



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
                            if (!IsSendToRec)
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success');window.setTimeout(function(){window.location='planning.aspx'},2500);", true);

                            }


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
                programPlan.Outcome = Convert.ToInt32(txtActualOutcome.Text);
                programPlan.Output = 0;
                programPlan.ActualOutput = Convert.ToInt32(txtActualOutput.Text);
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
                programPlan.ActualAmount = float.Parse(txtExpenditure.Text);
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
                if (DateTime.Parse(txtDate.Text) <= programTargetState.StartDate || DateTime.Parse(txtDate.Text) >= programTargetState.EndDate)
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
                        if (!IsSendToRec)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success');window.setTimeout(function(){window.location='planning.aspx'},2500);", true);
                        }

                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);
                    }
                }

            }
        }
        protected void btnSave_Click1(object sender, EventArgs e)
        {
            IsSendToRec = false;
            save(IsSendToRec);
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

        protected void btnSendToRecommendation_Click(object sender, EventArgs e)
        {
            IsSendToRec = true;
            save(IsSendToRec);

            programPlanId = Convert.ToInt32(Request.QueryString["ProgramplanId"]);

            ProgramPlanApprovalDetailsController programPlanApprovalDetailsController = ControllerFactory.CreateProgramPlanApprovalDetailsController();

            ProgramPlanApprovalDetails programPlanApprovalDetails = new ProgramPlanApprovalDetails();

            programPlanApprovalDetails.ProgramPlanId = programPlanId;
            programPlanApprovalDetails.ProjectStatus = 2013;

            programPlanApprovalDetails.Recommendation1By = Convert.ToInt32(Session["DepUnitParentId"]);
            //  programPlanApprovalDetails.Recommendation1Date =;

            programPlanApprovalDetails.Recommendation2By = 0;
            //  programPlanApprovalDetails.Recommendation2Date =;

            programPlanApprovalDetails.RejectReason = "";

            int response = programPlanApprovalDetailsController.Save(programPlanApprovalDetails);

            if (response != 0)
            {

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Succesfully Send To Recommendation!', 'success');window.setTimeout(function(){window.location='planning.aspx'},2500);", true);

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);
            }
        }

        protected void txtFemaleCount_TextChanged(object sender, EventArgs e)
        {
            txtTotalCount.Text = (Convert.ToInt32(txtFemaleCount.Text) + Convert.ToInt32(txtMaleCount.Text)).ToString();
        }

        protected void txtMaleCount_TextChanged(object sender, EventArgs e)
        {
            txtTotalCount.Text = (Convert.ToInt32(txtFemaleCount.Text) + Convert.ToInt32(txtMaleCount.Text)).ToString();

        }
    }


}