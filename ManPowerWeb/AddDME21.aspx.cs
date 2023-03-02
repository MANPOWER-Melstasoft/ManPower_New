using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class AddDME21 : System.Web.UI.Page
    {
        TaskAllocation taskAllocation = new TaskAllocation();
        TaskAllocationDetail taskAllocationDetail = new TaskAllocationDetail();
        List<TaskType> taskTypeList = new List<TaskType>();
        List<ProgramPlan> programPlanList = new List<ProgramPlan>();
        List<TaskAllocation> taskAllocationList;
        public int depId;
        public int flag = 0;
        public int worktype;
        public int programId;
        public string description;
        public string duty;
        public string date1;
        public int taskAllocationId;
        public int rowIndex;

        public DateTime date;
        public string name;
        public int year;

        protected void Page_Load(object sender, EventArgs e)
        {
            date1 = Request.QueryString["date"].ToString();

            depId = Convert.ToInt32(Session["DepUnitPositionId"]);

            year = DateTime.Now.Year;

            name = Session["Name"].ToString();

            rowIndex = Convert.ToInt32(Request.QueryString["taskAllocationDetailId"]);
            TaskAllocationDetailController allocationDetail = ControllerFactory.CreateTaskAllocationDetailController();

            taskAllocationDetail = allocationDetail.GetTaskAllocationDetail(rowIndex, false, false, false);

            ProgramDisplay.Visible = false;
            OtherDisplay.Visible = false;

            //this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {

                ProgramDataBind();
                WorkTypeDataBind();
                IsUpdate();
            }
            DivVisibility();


        }

        private void IsUpdate()
        {
            if (rowIndex > 0)
            {
                ddlWorkType.SelectedValue = taskAllocationDetail.TaskTypeId.ToString();
                txtDuty.Text = taskAllocationDetail.TaskDescription;
                txtPlace.Text = taskAllocationDetail.WorkLocation;
                txtRemarks.Text = taskAllocationDetail.TaskRemarks;
                ddlProgram.SelectedValue = taskAllocationDetail.programPlanId.ToString();
                LinkButton1.Text = "Update";

                btnDelete.Enabled = true;
                btnDelete.CssClass = "btn btn-outline-danger";
            }

            else
            {
                btnDelete.Enabled = false;
                btnDelete.CssClass = "btn btn-outline-danger disabled";
            }
        }

        private void WorkTypeDataBind()
        {
            TaskTypeController taskTypeController = ControllerFactory.CreateTaskTypeController();
            taskTypeList = taskTypeController.GetAllTaskType(false);
            ddlWorkType.DataSource = taskTypeList;
            ddlWorkType.DataBind();
        }

        private void ProgramDataBind()
        {
            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();
            programPlanList = programPlanController.getddlProgramPlan(depId, year);
            programPlanList = programPlanList.Where(p => p.Date.Month == DateTime.Now.AddMonths(1).Month && p.Date.Year == DateTime.Now.AddMonths(1).Year).ToList();

            ddlProgram.DataSource = programPlanList;
            ddlProgram.DataBind();

            ddlProgram.Items.Insert(0, new ListItem("", ""));

            //TaskAllocationController taskAllocationController = ControllerFactory.CreateTaskAllocationController();
            //List<TaskAllocation> taskAllocationList = taskAllocationController.GetAllTaskAllocation(false, false, false, false);

            //TaskAllocationDetailController taskAllocationDetailController = ControllerFactory.CreateTaskAllocationDetailController();

            //int taskAllocationId = 0;

            //foreach (var item in taskAllocationList)
            //{
            //    if (item.DepartmetUnitPossitionsId == depId && item.TaskYearMonth.Month == DateTime.Now.AddMonths(1).Month && item.TaskYearMonth.Year == DateTime.Now.AddMonths(1).Year)
            //    {
            //        taskAllocationId = item.TaskAllocationId;
            //        break;
            //    }
            //}

            //if (taskAllocationId == 0)
            //{
            //    ddlProgram.DataSource = programPlanList;
            //    ddlProgram.DataBind();
            //}

            //else
            //{
            //    List<TaskAllocationDetail> taskAllocationDetailList = taskAllocationDetailController.GetAllTaskAllocationDetail().Where(x => x.TaskAllocationId == taskAllocationId && x.TaskTypeId == 1).ToList();

            //    foreach (var item in programPlanList.ToList())
            //    {
            //        foreach (var item1 in taskAllocationDetailList)
            //        {
            //            if (item.ProgramPlanId == item1.programPlanId)
            //            {
            //                programPlanList.Remove(item);
            //            }
            //        }
            //    }

            //    ddlProgram.DataSource = programPlanList;
            //    ddlProgram.DataBind();
            //}

        }

        public void DivVisibility()
        {
            if (ddlWorkType.SelectedValue == "1")
            {
                ProgramDisplay.Visible = true;
                divDuty.Visible = true;
                divPlace.Visible = true;

            }
            else if (ddlWorkType.SelectedValue == "3")
            {
                OtherDisplay.Visible = true;
                divDuty.Visible = true;
                divPlace.Visible = true;
            }
            else if (ddlWorkType.SelectedValue == "2")
            {
                divDuty.Visible = false;
                divPlace.Visible = false;
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            TaskAllocationController allocation = ControllerFactory.CreateTaskAllocationController();

            TaskAllocationDetailController allocationDetail = ControllerFactory.CreateTaskAllocationDetailController();

            if (LinkButton1.Text == "Update")
            {
                worktype = Convert.ToInt32(ddlWorkType.SelectedValue);

                date = DateTime.ParseExact(date1, "yyyy-MM-dd", null);

                string remark = txtRemarks.Text;

                if (remark == null)
                {
                    taskAllocationDetail.TaskAllocationDetailId = taskAllocationDetail.TaskAllocationDetailId;
                    taskAllocationDetail.TaskTypeId = worktype;
                    taskAllocationDetail.TaskAllocationId = taskAllocationDetail.TaskAllocationId;
                    taskAllocationDetail.TaskDescription = txtDuty.Text;
                    taskAllocationDetail.WorkLocation = txtPlace.Text;
                    taskAllocationDetail.Isconmpleated = 0;
                    taskAllocationDetail.NotCompleatedReason = "";
                    taskAllocationDetail.StartTime = date;
                    taskAllocationDetail.EndTime = DateTime.Today;
                    taskAllocationDetail.TaskRemarks = "";
                    taskAllocationDetail.TaskAmendments = "";
                    //taskAllocationDetail.programPlanId = Convert.ToInt32(ddlProgram.SelectedValue);

                    allocationDetail.UpdateTaskAllocationDetail(taskAllocationDetail);

                    if (worktype == 1)
                    {
                        ProjectTaskController projectTaskController = ControllerFactory.CreateProjectTaskController();
                        ProjectTask projectTaskobj = new ProjectTask();

                        projectTaskobj.TaskAllocationDetailId = taskAllocationDetail.TaskAllocationDetailId;
                        projectTaskobj.ProgramPlanId = Convert.ToInt32(ddlProgram.SelectedValue);

                        projectTaskController.saveProjectTask(projectTaskobj);
                    }
                }
                else
                {
                    taskAllocationDetail.TaskAllocationDetailId = taskAllocationDetail.TaskAllocationDetailId;
                    taskAllocationDetail.TaskTypeId = worktype;
                    taskAllocationDetail.TaskAllocationId = taskAllocationDetail.TaskAllocationId;
                    taskAllocationDetail.TaskDescription = txtDuty.Text;
                    taskAllocationDetail.WorkLocation = txtPlace.Text;
                    taskAllocationDetail.Isconmpleated = 0;
                    taskAllocationDetail.NotCompleatedReason = "";
                    taskAllocationDetail.StartTime = date;
                    taskAllocationDetail.EndTime = DateTime.Today;
                    taskAllocationDetail.TaskRemarks = txtRemarks.Text;
                    taskAllocationDetail.TaskAmendments = "";
                    //taskAllocationDetail.programPlanId = Convert.ToInt32(ddlProgram.SelectedValue);

                    allocationDetail.UpdateTaskAllocationDetail(taskAllocationDetail);

                    if (worktype == 1)
                    {
                        ProjectTaskController projectTaskController = ControllerFactory.CreateProjectTaskController();
                        ProjectTask projectTaskobj = new ProjectTask();

                        projectTaskobj.TaskAllocationDetailId = taskAllocationDetail.TaskAllocationDetailId;
                        projectTaskobj.ProgramPlanId = Convert.ToInt32(ddlProgram.SelectedValue);

                        projectTaskController.saveProjectTask(projectTaskobj);
                    }
                }

                Response.Redirect("DME21.aspx");
            }

            else
            {
                if (Convert.ToInt32(ddlWorkType.SelectedValue) == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Failed!', 'Please Add Program Plan from Planning Section!', 'error');window.setTimeout(function(){window.location='DME21.aspx'},2500);", true);
                    //ClientScript.RegisterClientScriptBlock(GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);
                }

                else
                {
                    taskAllocationList = allocation.GetAllTaskAllocation(false, false, false, false);

                    worktype = Convert.ToInt32(ddlWorkType.SelectedValue);

                    date = DateTime.ParseExact(date1, "yyyy-MM-dd", null);

                    string remark = txtRemarks.Text;


                    foreach (var i in taskAllocationList)
                    {
                        if (i.DepartmetUnitPossitionsId == depId && i.TaskYearMonth.Month == date.Month && i.TaskYearMonth.Year == date.Year)
                        {
                            flag = 1;
                            taskAllocationId = i.TaskAllocationId;
                        }
                    }

                    if (flag == 0)
                    {
                        taskAllocation.DepartmetUnitPossitionsId = depId;
                        taskAllocation.TaskYearMonth = date;
                        taskAllocation.CreatedDate = DateTime.Today.Date;
                        taskAllocation.CreatedUser = name;
                        taskAllocation.StatusId = 0;
                        taskAllocation.DME21RecommendedBy1 = 0;
                        taskAllocation.RecommendedDate = DateTime.Today;
                        taskAllocation.DME21ApprovedBy = 0;
                        taskAllocation.ApprovedDate = DateTime.Today;
                        taskAllocation.DME21RecommendedBy2 = 0;
                        taskAllocation.DME22_ApprovedBy = 0;

                        int taskAllocationId1 = allocation.saveTaskAllocation(taskAllocation);

                        if (remark == null)
                        {
                            taskAllocationDetail.TaskTypeId = worktype;
                            taskAllocationDetail.TaskAllocationId = taskAllocationId1;
                            taskAllocationDetail.TaskDescription = txtDuty.Text;
                            taskAllocationDetail.WorkLocation = txtPlace.Text;
                            taskAllocationDetail.Isconmpleated = 0;
                            taskAllocationDetail.NotCompleatedReason = "";
                            taskAllocationDetail.StartTime = date;
                            taskAllocationDetail.EndTime = DateTime.Today;
                            taskAllocationDetail.TaskRemarks = "";
                            taskAllocationDetail.TaskAmendments = "";
                            //taskAllocationDetail.programPlanId = Convert.ToInt32(ddlProgram.SelectedValue);

                            int taskAlocationDetailId = allocationDetail.SaveTaskAllocationDetail(taskAllocationDetail);

                            if (worktype == 1)
                            {
                                ProjectTaskController projectTaskController = ControllerFactory.CreateProjectTaskController();
                                ProjectTask projectTaskobj = new ProjectTask();

                                projectTaskobj.TaskAllocationDetailId = taskAlocationDetailId;
                                projectTaskobj.ProgramPlanId = Convert.ToInt32(ddlProgram.SelectedValue);

                                projectTaskController.saveProjectTask(projectTaskobj);
                            }
                        }
                        else
                        {
                            taskAllocationDetail.TaskTypeId = worktype;
                            taskAllocationDetail.TaskAllocationId = taskAllocationId1;
                            taskAllocationDetail.TaskDescription = txtDuty.Text;
                            taskAllocationDetail.WorkLocation = txtPlace.Text;
                            taskAllocationDetail.Isconmpleated = 0;
                            taskAllocationDetail.NotCompleatedReason = "";
                            taskAllocationDetail.StartTime = date;
                            taskAllocationDetail.EndTime = DateTime.Today;
                            taskAllocationDetail.TaskRemarks = txtRemarks.Text;
                            taskAllocationDetail.TaskAmendments = "";
                            //taskAllocationDetail.programPlanId = Convert.ToInt32(ddlProgram.SelectedValue);

                            int taskAlocationDetailId = allocationDetail.SaveTaskAllocationDetail(taskAllocationDetail);

                            if (worktype == 1)
                            {
                                ProjectTaskController projectTaskController = ControllerFactory.CreateProjectTaskController();
                                ProjectTask projectTaskobj = new ProjectTask();

                                projectTaskobj.TaskAllocationDetailId = taskAlocationDetailId;
                                projectTaskobj.ProgramPlanId = Convert.ToInt32(ddlProgram.SelectedValue);

                                projectTaskController.saveProjectTask(projectTaskobj);
                            }
                        }
                    }
                    else
                    {
                        if (remark == null)
                        {
                            taskAllocationDetail.TaskTypeId = worktype;
                            taskAllocationDetail.TaskAllocationId = taskAllocationId;
                            taskAllocationDetail.TaskDescription = txtDuty.Text;
                            taskAllocationDetail.WorkLocation = txtPlace.Text;
                            taskAllocationDetail.Isconmpleated = 0;
                            taskAllocationDetail.NotCompleatedReason = "";
                            taskAllocationDetail.StartTime = date;
                            taskAllocationDetail.EndTime = DateTime.Today;
                            taskAllocationDetail.TaskRemarks = "";
                            taskAllocationDetail.TaskAmendments = "";
                            //taskAllocationDetail.programPlanId = Convert.ToInt32(ddlProgram.SelectedValue);

                            int taskAlocationDetailId = allocationDetail.SaveTaskAllocationDetail(taskAllocationDetail);

                            if (worktype == 1)
                            {
                                ProjectTaskController projectTaskController = ControllerFactory.CreateProjectTaskController();
                                ProjectTask projectTaskobj = new ProjectTask();

                                projectTaskobj.TaskAllocationDetailId = taskAlocationDetailId;
                                projectTaskobj.ProgramPlanId = Convert.ToInt32(ddlProgram.SelectedValue);

                                projectTaskController.saveProjectTask(projectTaskobj);
                            }
                        }
                        else
                        {
                            taskAllocationDetail.TaskTypeId = worktype;
                            taskAllocationDetail.TaskAllocationId = taskAllocationId;
                            taskAllocationDetail.TaskDescription = txtDuty.Text;
                            taskAllocationDetail.WorkLocation = txtPlace.Text;
                            taskAllocationDetail.Isconmpleated = 0;
                            taskAllocationDetail.NotCompleatedReason = "";
                            taskAllocationDetail.StartTime = date;
                            taskAllocationDetail.EndTime = DateTime.Today;
                            taskAllocationDetail.TaskRemarks = txtRemarks.Text;
                            taskAllocationDetail.TaskAmendments = "";
                            //taskAllocationDetail.programPlanId = Convert.ToInt32(ddlProgram.SelectedValue);

                            int taskAlocationDetailId = allocationDetail.SaveTaskAllocationDetail(taskAllocationDetail);

                            if (worktype == 1)
                            {
                                ProjectTaskController projectTaskController = ControllerFactory.CreateProjectTaskController();
                                ProjectTask projectTaskobj = new ProjectTask();

                                projectTaskobj.TaskAllocationDetailId = taskAlocationDetailId;
                                projectTaskobj.ProgramPlanId = Convert.ToInt32(ddlProgram.SelectedValue);

                                projectTaskController.saveProjectTask(projectTaskobj);
                            }
                        }
                    }
                    Response.Redirect("DME21.aspx");
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            TaskAllocationDetailController taskAllocationDetailController = ControllerFactory.CreateTaskAllocationDetailController();

            taskAllocationDetailController.DeleteTaskAllocationDetail(rowIndex);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Successfuly Deleted!', 'success');window.setTimeout(function(){window.location='DME21.aspx'},2500);", true);

        }
    }
}