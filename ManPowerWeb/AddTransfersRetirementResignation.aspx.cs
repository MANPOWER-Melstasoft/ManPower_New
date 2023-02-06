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
    public partial class AddTransfersRetirementResignation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                BindRequestType();
                BindEmpData();
            }
        }

        private void BindRequestType()
        {
            RequestTypeController requestTypeController = ControllerFactory.CreateRequestTypeController();
            ddlRequestType.DataSource = requestTypeController.GetAllRequestType(false);
            ddlRequestType.DataValueField = "Id";
            ddlRequestType.DataTextField = "RequestTypeName";
            ddlRequestType.DataBind();
            ddlRequestType.Items.Insert(0, new ListItem("-- select request type --", ""));

            if (ddlRequestType.SelectedValue == "")
            {
                transferDiv.Visible = false;
                retirementDiv.Visible = false;
                resignationDiv.Visible = false;
            }
        }

        private void BindEmpData()
        {
            lblEmpNumber.Text = Session["EmpNumber"].ToString();
            lblEmpName.Text = Session["Name"].ToString();

            EmployeeController employeeController = ControllerFactory.CreateEmployeeController();
            Employee employee = employeeController.GetEmployeeById(Convert.ToInt32(Session["EmpNumber"]));
            txtDob.Text = employee.DOB.ToString("yyyy-MM-dd");

            SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();
            SystemUser systemUser = systemUserController.GetSystemUser(Convert.ToInt32(Session["UserId"]), true, false, true);

            DepartmentUnitController departmentUnitController = ControllerFactory.CreateDepartmentUnitController();
            DepartmentUnit departmentUnit = departmentUnitController.GetDepartmentUnit(systemUser._DepartmentUnitPositions.DepartmentUnitId, true, false);
            lblDepartment.Text = departmentUnit.Name;

            DesignationController designationController = ControllerFactory.CreateDesignationController();
            Designation designation = designationController.GetDesignation(systemUser.DesignationId, true, false);

            lblDesignation.Text = designation.DesigntionName;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransfersRetirementResignation.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string type = ddlRequestType.SelectedValue;
            int output = 0;

            //--------------------------------------------------Transfer--------------------------------------------------------

            if (type == "1")
            {
                TransfersRetirementResignationMain transfersRetirementResignationMain = new TransfersRetirementResignationMain();
                Transfer transfer = new Transfer();

                transfersRetirementResignationMain.RequestTypeId = 1;
                transfersRetirementResignationMain.StatusId = 1;
                transfersRetirementResignationMain.EmployeeId = Convert.ToInt32(Session["EmpNumber"]);
                transfersRetirementResignationMain.CreatedDate = DateTime.Now;
                transfersRetirementResignationMain.CreatedUser = Session["Name"].ToString();
                transfersRetirementResignationMain.RequestTypeId = Convert.ToInt32(type);
                transfersRetirementResignationMain.ParentId = Convert.ToInt32(Session["DepUnitParentId"]);
                transfersRetirementResignationMain.Documents = "";

                if (Uploader.HasFile)
                {
                    HttpFileCollection uploadFiles = Request.Files;
                    for (int i = 0; i < uploadFiles.Count; i++)
                    {
                        HttpPostedFile uploadFile = uploadFiles[i];
                        if (uploadFile.ContentLength > 0)
                        {
                            uploadFile.SaveAs(Server.MapPath("~/SystemDocuments/Transfers/") + uploadFile.FileName);
                            transfersRetirementResignationMain.Documents = uploadFile.FileName;

                        }
                    }
                }

                transfer.TransferType = ddlTransferType.SelectedValue;
                transfer.CurrentDep = lblDepartment.Text;
                transfer.NextDep = Convert.ToInt32(ddlDepartment.SelectedValue);
                transfer.Reason = txtReason.Text;

                TransferController transferController = ControllerFactory.CreateTransferController();
                output = transferController.Save(transfersRetirementResignationMain, transfer);
                if (output == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Record Added Succesfully!', 'success');window.setTimeout(function(){window.location='TransfersRetirementResignation.aspx'},2500);", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Record Added Fail!', 'error');", true);
                }
            }


            //--------------------------------------------------Resignation--------------------------------------------------------

            if (type == "2")
            {
                TransfersRetirementResignationMain transfersRetirementResignationMain = new TransfersRetirementResignationMain();
                Resignation resignation = new Resignation();

                transfersRetirementResignationMain.RequestTypeId = 1;
                transfersRetirementResignationMain.StatusId = 1;
                transfersRetirementResignationMain.EmployeeId = Convert.ToInt32(Session["EmpNumber"]);
                transfersRetirementResignationMain.CreatedDate = DateTime.Now;
                transfersRetirementResignationMain.CreatedUser = Session["Name"].ToString();
                transfersRetirementResignationMain.RequestTypeId = Convert.ToInt32(type);
                transfersRetirementResignationMain.ParentId = Convert.ToInt32(Session["DepUnitParentId"]);
                transfersRetirementResignationMain.Documents = "";

                if (Uploader.HasFile)
                {
                    HttpFileCollection uploadFiles = Request.Files;
                    for (int i = 0; i < uploadFiles.Count; i++)
                    {
                        HttpPostedFile uploadFile = uploadFiles[i];
                        if (uploadFile.ContentLength > 0)
                        {
                            uploadFile.SaveAs(Server.MapPath("~/SystemDocuments/Resignation/") + uploadFile.FileName);
                            transfersRetirementResignationMain.Documents = uploadFile.FileName;

                        }
                    }
                }


                resignation.ResignationDate = DateTime.Parse(txtResignationDate.Text);
                resignation.Reason = txtResignationReason.Text;

                ResignationController resignationController = ControllerFactory.CreateResignationController();
                output = resignationController.Save(transfersRetirementResignationMain, resignation);
                if (output == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Record Added Succesfully!', 'success');window.setTimeout(function(){window.location='TransfersRetirementResignation.aspx'},2500);", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Record Added Succesfully!', 'error');", true);
                }
            }


            //--------------------------------------------------Retirement--------------------------------------------------------


            if (type == "3")
            {
                TransfersRetirementResignationMain transfersRetirementResignationMain = new TransfersRetirementResignationMain();
                Retirement retirement = new Retirement();

                transfersRetirementResignationMain.RequestTypeId = 1;
                transfersRetirementResignationMain.StatusId = 1;
                transfersRetirementResignationMain.EmployeeId = Convert.ToInt32(Session["EmpNumber"]);
                transfersRetirementResignationMain.CreatedDate = DateTime.Now;
                transfersRetirementResignationMain.CreatedUser = Session["Name"].ToString();
                transfersRetirementResignationMain.RequestTypeId = Convert.ToInt32(type);
                transfersRetirementResignationMain.ParentId = Convert.ToInt32(Session["DepUnitParentId"]);
                transfersRetirementResignationMain.Documents = "";

                if (Uploader.HasFile)
                {
                    HttpFileCollection uploadFiles = Request.Files;
                    for (int i = 0; i < uploadFiles.Count; i++)
                    {
                        HttpPostedFile uploadFile = uploadFiles[i];
                        if (uploadFile.ContentLength > 0)
                        {
                            uploadFile.SaveAs(Server.MapPath("~/SystemDocuments/Retirement/") + uploadFile.FileName);
                            transfersRetirementResignationMain.Documents = uploadFile.FileName;

                        }
                    }
                }

                retirement.JoinedDate = DateTime.Parse(txtJoinedDate.Text);
                retirement.Remark = txtRetirementRemark.Text;
                if (ddlRetirementType.SelectedItem.Text == "Other")
                {
                    retirement.RetirementType = txtRetirementOther.Text;
                }
                else
                {
                    retirement.RetirementType = ddlRetirementType.SelectedValue;
                }
                retirement.Reason = txtRetirementReason.Text;

                RetirementController retirementController = ControllerFactory.CreateRetirementController();
                output = retirementController.Save(transfersRetirementResignationMain, retirement);
                if (output == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Record Added Succesfully!', 'success');window.setTimeout(function(){window.location='TransfersRetirementResignation.aspx'},2500);", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Record Added Succesfully!', 'error');", true);
                }
            }

        }





        protected void ddlRequestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRequestType.SelectedValue == "")
            {
                transferDiv.Visible = false;
                retirementDiv.Visible = false;
                resignationDiv.Visible = false;
            }
            if (ddlRequestType.SelectedValue == "1")
            {
                transferDiv.Visible = true;
                retirementDiv.Visible = false;
                resignationDiv.Visible = false;

                BindTransferType();
                BindDepList();
            }
            if (ddlRequestType.SelectedValue == "2")
            {
                transferDiv.Visible = false;
                retirementDiv.Visible = false;
                resignationDiv.Visible = true;
            }
            if (ddlRequestType.SelectedValue == "3")
            {
                transferDiv.Visible = false;
                retirementDiv.Visible = true;
                resignationDiv.Visible = false;

                BindRetirementType();
            }
        }

        private void BindDepList()
        {
            DepartmentUnitController departmentUnitTypeController = ControllerFactory.CreateDepartmentUnitController();
            List<DepartmentUnit> departmentUnitType = departmentUnitTypeController.GetAllDepartmentUnit(false, false);

            ddlDepartment.DataSource = departmentUnitType;
            ddlDepartment.DataValueField = "DepartmentUnitId";
            ddlDepartment.DataTextField = "Name";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("-- select department --", ""));
        }

        private void BindTransferType()
        {

            TransferTypeController transferTypeController = ControllerFactory.CreateTransferTypeController();
            List<TransferType> transferType = transferTypeController.GetAllTransferType(false);
            ddlTransferType.DataSource = transferType;
            ddlTransferType.DataValueField = "TransferTypeName";
            ddlTransferType.DataTextField = "TransferTypeName";
            ddlTransferType.DataBind();
            ddlTransferType.Items.Insert(0, new ListItem("-- select transfer type --", ""));

        }

        private void BindRetirementType()
        {

            RetirementTypeController retirementTypeController = ControllerFactory.CreateRetirementTypeController();
            List<RetirementType> retirementTypes = retirementTypeController.GetAllRetirementType(false);

            ddlRetirementType.DataSource = retirementTypes;
            ddlRetirementType.DataValueField = "RetirementTypeName";
            ddlRetirementType.DataTextField = "RetirementTypeName";
            ddlRetirementType.DataBind();
            ddlRetirementType.Items.Insert(0, new ListItem("-- select retirement type --", ""));

        }

    }
}