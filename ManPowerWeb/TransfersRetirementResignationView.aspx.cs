using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ManPowerWeb
{
    public partial class TransfersRetirementResignationView : System.Web.UI.Page
    {

        static int Id;
        static int typeId;
        static string document;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["Id"]);
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
            TransfersRetirementResignationMainController trrController = ControllerFactory.CreateTransfersRetirementResignationMainController();
            TransfersRetirementResignationMain trrmainObj = trrController.GetTransfersRetirementResignation(Id);

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

                if (transfer.TransferType == "Combine Service")
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
            Response.Redirect("TransfersRetirementResignation.aspx");
        }

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{

        //}


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

    }
}