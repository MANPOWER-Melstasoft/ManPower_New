using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class RecommendTransfersRetirementResignationView : System.Web.UI.Page
    {
        static int Id;
        static int typeId;
        static string document;
        static TransfersRetirementResignationMain trrmainObj = new TransfersRetirementResignationMain();
        static List<SystemUser> AssignUserList = new List<SystemUser>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                    BindStatus();
                    BindAssignUser();
                    BindReverseReason();
                    BindData();
                }
                else
                {
                    Response.Redirect("404.aspx");
                }
            }
        }

        private void BindData()
        {
            btnSubmit.Visible = false;

            TransfersRetirementResignationMainController trrController = ControllerFactory.CreateTransfersRetirementResignationMainController();
            trrmainObj = trrController.GetTransfersRetirementResignation(Id);

            lblEmpNumber.Text = trrmainObj.EmployeeId.ToString();
            lblEmpName.Text = trrmainObj.employee.EmpInitials + trrmainObj.employee.LastName;

            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            SystemUser systemUser = systemUserController.GetSystemUserByEmpNumber(trrmainObj.EmployeeId);

            DepartmentUnitController departmentUnitController = ControllerFactory.CreateDepartmentUnitController();
            DepartmentUnit departmentUnit = departmentUnitController.GetDepartmentUnit(systemUser._DepartmentUnitPositions.DepartmentUnitId, true, false);

            lblDepartment.Text = departmentUnit.Name;
            lblDesignation.Text = systemUser._Designation.DesigntionName;
            lblDocument.Text = trrmainObj.Documents;
            document = trrmainObj.Documents;

            if (trrmainObj.StatusId == 1)
            {
                btnSubmit.Visible = true;
            }
            else if (trrmainObj.StatusId == 2)
            {
                ddlUpdateStatus.SelectedValue = "1";
            }
            else if (trrmainObj.StatusId == 3)
            {
                ddlUpdateStatus.SelectedValue = "3";
                sendtoapp.Visible = false;
                reverse.Visible = false;
                reject.Visible = true;

                txtRejectRemark.Text = trrmainObj.Remarks;

            }
            else if (trrmainObj.StatusId == 4)
            {
                ddlUpdateStatus.SelectedValue = "4";
                sendtoapp.Visible = false;
                reverse.Visible = true;
                reject.Visible = false;

                ReverseReasonController reverseReasonController = ControllerFactory.CreateReverseReasonController();
                List<ReverseReason> reverseReasonsList = reverseReasonController.GetAllReverseReason(false);

                ReverseReason reverseReasonsObj = new ReverseReason();

                foreach (var item in reverseReasonsList)
                {
                    if (item.ReverseReasonName.ToLower() == trrmainObj.ParentAction.ToLower())
                    {
                        reverseReasonsObj = item;
                    }
                }

                if (reverseReasonsObj != null)
                {
                    ddlReverseReason.SelectedValue = Convert.ToString(reverseReasonsObj.Id);
                }

            }
            else if (trrmainObj.StatusId == 5)
            {
                ddlUpdateStatus.SelectedValue = "0";
            }

            if (trrmainObj.RequestTypeId == 1 || trrmainObj.RequestTypeId == 4)
            {
                typeId = 1;
                transferDiv.Visible = true;
                heading.Text = "Transfer - " + Id.ToString();
                lblRequestType.Text = "Transfer";

                TransferController transferController = ControllerFactory.CreateTransferController();
                Transfer transfer = transferController.GetTransferByMainId(Id);

                lblTransferType.Text = transfer.TransferType;
                lblTransferReason.Text = transfer.Reason;

                if (trrmainObj.RequestTypeId == 4)
                {
                    typeId = 4;
                    heading.Text = "Temporary Attchement - " + Id.ToString();
                    lblRequestType.Text = "Temporary Attchement";
                    FromToDate.Visible = true;

                    if (transfer.FromDate.ToString("yyyy-MM-dd") != "0001-01-01")
                    {
                        fromDate.Text = transfer.FromDate.ToString("yyyy-MM-dd");
                        toDate.Text = transfer.ToDate.ToString("yyyy-MM-dd");
                    }
                }

                if (transfer.TransferType == "External")
                {
                    lblNewDapartment.Text = transfer.RequestWorkPlace;
                }
                else
                {
                    DepartmentUnit departmentUnitNext = departmentUnitController.GetDepartmentUnit(transfer.NextDep, false, false);
                    lblNewDapartment.Text = departmentUnitNext.Name;
                }
            }
            if (trrmainObj.RequestTypeId == 2)
            {
                typeId = 2;
                resignationDiv.Visible = true;
                heading.Text = "Resignation - " + Id.ToString();
                lblRequestType.Text = "Resignation";

                ResignationController resignationController = ControllerFactory.CreateResignationController();
                Resignation resignation = resignationController.GetResignationByMainId(Id);

                lblResignationDate.Text = resignation.ResignationDate.ToShortDateString();
                lblResignationReason.Text = resignation.Reason;
            }
            if (trrmainObj.RequestTypeId == 3)
            {
                typeId = 3;
                retirementDiv.Visible = true;
                heading.Text = "Retirement - " + Id.ToString();
                lblRequestType.Text = "Retirement";

                RetirementController retirementController = ControllerFactory.CreateRetirementController();
                Retirement retirement = retirementController.GetRetirementByMainId(Id);

                EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
                Employee employee = employeeController.GetEmployeeById(trrmainObj.EmployeeId);

                lblJoinedDate.Text = retirement.JoinedDate.ToShortDateString();
                lblDob.Text = employee.DOB.ToShortDateString();
                lblRetirementType.Text = retirement.RetirementType;
                lblRetirementReason.Text = retirement.Reason;
                lblRetirementRemark.Text = retirement.Remark;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecommendTransfersRetirementResignation.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int output = 0;
            TransfersRetirementResignationMainController transfersRetirementResignationMainController = ControllerFactory.CreateTransfersRetirementResignationMainController();

            trrmainObj.ActionTakenUserId = Convert.ToInt32(Session["UserId"]);
            trrmainObj.ActionTakenDate = DateTime.Today;
            trrmainObj.RecomendParentId = Convert.ToInt32(Session["UserId"]);
            trrmainObj.Remarks = "";
            trrmainObj.Reason = "";
            trrmainObj.ReverseRemarks = "";
            trrmainObj.RecDocuments = "";

            if (ddlUpdateStatus.SelectedItem.Text == "Send to Approval")
            {
                trrmainObj.StatusId = 5;
                trrmainObj.ParentAction = ddlAction.SelectedItem.Text;
            }
            if (ddlUpdateStatus.SelectedItem.Text == "Incomplete Application")
            {
                trrmainObj.StatusId = 4;
                trrmainObj.ParentAction = ddlReverseReason.SelectedItem.Text;
                trrmainObj.ReverseRemarks = txtReverseRemarks.Text;
            }
            if (ddlUpdateStatus.SelectedItem.Text == "Reject")
            {
                trrmainObj.StatusId = 3;
                trrmainObj.ParentAction = "Reject";
                trrmainObj.Remarks = txtRejectRemark.Text;
            }

            if (OtherUploader.HasFile)
            {
                HttpFileCollection uploadFiles = Request.Files;
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile uploadFile = uploadFiles[i];
                    if (uploadFile.ContentLength > 0)
                    {
                        var originalFileName = Path.GetFileName(uploadFile.FileName); // Get the original filename
                        var extension = Path.GetExtension(originalFileName); // Get the file extension
                        var dateTime = DateTime.Now.ToString("yyyyMMddHHmmss"); // Get the current date and time as a string
                        var newFileName = trrmainObj.EmployeeId + "_" + dateTime + extension; // Set the new filename

                        if (typeId == 1)
                        {
                            uploadFile.SaveAs(Server.MapPath("~/SystemDocuments/Transfers/") + newFileName);
                            trrmainObj.RecDocuments = newFileName;
                        }
                        if (typeId == 4)
                        {
                            uploadFile.SaveAs(Server.MapPath("~/SystemDocuments/Transfers/") + newFileName);
                            trrmainObj.RecDocuments = newFileName;
                        }
                        if (typeId == 2)
                        {
                            uploadFile.SaveAs(Server.MapPath("~/SystemDocuments/Resignation/") + newFileName);
                            trrmainObj.RecDocuments = newFileName;
                        }
                        if (typeId == 3)
                        {
                            uploadFile.SaveAs(Server.MapPath("~/SystemDocuments/Retirement/") + newFileName);
                            trrmainObj.RecDocuments = newFileName;
                        }

                    }
                }
            }

            output = transfersRetirementResignationMainController.Recommend(trrmainObj);

            if (output == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Record Updated Succesfully!', 'success');window.setTimeout(function(){window.location='RecommendTransfersRetirementResignation.aspx'},2500);", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Record Added Fail!', 'error');", true);
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            if (typeId == 1 || typeId == 4)
            {
                if (document != "" && document != null)
                {
                    string filePathe = Server.MapPath("~/SystemDocuments/Transfers/" + document);

                    Response.Clear();
                    Response.ContentType = "application/octect-stream";
                    Response.AppendHeader("content-disposition", "filename = " + document);
                    Response.TransmitFile(filePathe);
                    Response.End();
                }
            }
            if (typeId == 2)
            {
                if (document != "" && document != null)
                {
                    string filePathe = Server.MapPath("~/SystemDocuments/Resignation/" + document);

                    Response.Clear();
                    Response.ContentType = "application/octect-stream";
                    Response.AppendHeader("content-disposition", "filename = " + document);
                    Response.TransmitFile(filePathe);
                    Response.End();
                }
            }
            if (typeId == 3)
            {
                if (document != "" && document != null)
                {
                    string filePathe = Server.MapPath("~/SystemDocuments/Retirement/" + document);

                    Response.Clear();
                    Response.ContentType = "application/octect-stream";
                    Response.AppendHeader("content-disposition", "filename = " + document);
                    Response.TransmitFile(filePathe);
                    Response.End();
                }
            }
        }

        private void BindStatus()
        {
            ddlUpdateStatus.Items.Insert(0, new ListItem("-- select status --", ""));

            ddlUpdateStatus.Items.Insert(1, new ListItem("Send to Approval", "1"));
            ddlUpdateStatus.Items.Insert(2, new ListItem("Incomplete Application", "4"));
            ddlUpdateStatus.Items.Insert(3, new ListItem("Reject", "3"));
        }

        private void BindAssignUser()
        {
            ApproveActionController approveActionController = ControllerFactory.CreateApproveActionController();
            List<ApproveAction> approveActions = approveActionController.GetAllApproveAction(false);

            ddlAction.DataSource = approveActions;
            ddlAction.DataValueField = "Id";
            ddlAction.DataTextField = "ApproveActionName";
            ddlAction.DataBind();
            ddlAction.Items.Insert(0, new ListItem("-- select action --", ""));
        }

        private void BindReverseReason()
        {
            ReverseReasonController reverseReasonController = ControllerFactory.CreateReverseReasonController();
            List<ReverseReason> reverseReasons = reverseReasonController.GetAllReverseReason(false);

            ddlReverseReason.DataSource = reverseReasons;
            ddlReverseReason.DataValueField = "Id";
            ddlReverseReason.DataTextField = "ReverseReasonName";
            ddlReverseReason.DataBind();
            ddlReverseReason.Items.Insert(0, new ListItem("-- select reason --", ""));
        }

        protected void ddlUpdateStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUpdateStatus.SelectedItem.Text == "Approve")
            {
                sendtoapp.Visible = false;
                reverse.Visible = false;
                reject.Visible = false;
            }
            if (ddlUpdateStatus.SelectedItem.Text == "Send to Approval")
            {
                sendtoapp.Visible = true;
                reverse.Visible = false;
                reject.Visible = false;
            }
            if (ddlUpdateStatus.SelectedItem.Text == "Incomplete Application")
            {
                sendtoapp.Visible = false;
                reverse.Visible = true;
                reject.Visible = false;
            }
            if (ddlUpdateStatus.SelectedItem.Text == "Reject")
            {
                sendtoapp.Visible = false;
                reverse.Visible = false;
                reject.Visible = true;
            }
        }
    }
}