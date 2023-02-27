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
    public partial class RequestLoan : System.Web.UI.Page
    {
        List<LoanType> loanTypeList = new List<LoanType>();
        List<DistressLoan> distressLoansList = new List<DistressLoan>();
        static List<GuarantorDetail> guarantorDetailList = new List<GuarantorDetail>();
        static List<RequestorGuarantor> requestorGuarantorsList = new List<RequestorGuarantor>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                bindDatasource();
            }
        }

        private void bindDatasource()
        {
            LoanTypeController loanTypeController = ControllerFactory.CreateLoanTypeController();
            loanTypeList = loanTypeController.GetAllLoanType();

            ddlLoanType.DataSource = loanTypeList;
            ddlLoanType.DataValueField = "Id";
            ddlLoanType.DataTextField = "Loan_Type_Name";
            ddlLoanType.DataBind();
            ddlLoanType.Items.Insert(0, new ListItem("Select Loan Type", ""));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            LoanDetail loanDetail = new LoanDetail();
            DistressLoan distressLoan = new DistressLoan();
            int response = 0;
            bool validationflag = false;
            LoanDetailsController loanDetailsController = ControllerFactory.CreateLoanDetailsController();

            loanDetail.FullName = txtName.Text;
            loanDetail.LoanTypeId = Convert.ToInt32(ddlLoanType.SelectedValue);
            loanDetail.Position = txtPosition.Text;
            loanDetail.WorkType = txtPositionType.Text;
            loanDetail.WorkPlace = txtWorkPlace.Text;
            if (Convert.ToDateTime(txtAppointmentDate.Text) < DateTime.Now)
            {
                loanDetail.AppointedDate = Convert.ToDateTime(txtAppointmentDate.Text);
                validationflag = true;

            }
            else
            {
                validationflag = false;
            }
            loanDetail.BasicSalary = float.Parse(txtBasicSalary.Text);
            loanDetail.LoanAmount = float.Parse(txtLoanAmount.Text);

            if (Convert.ToDateTime(txtDateWanted.Text) > DateTime.Now)
            {
                loanDetail.LoanRequireDate = Convert.ToDateTime(txtDateWanted.Text);
                validationflag = true;

            }
            else
            {
                validationflag = false;
            }
            loanDetail.CreatedDate = DateTime.Now;
            loanDetail.EmployeeId = Convert.ToInt32(Session["EmpNumber"]);
            loanDetail.ApprovalStatusId = 1;

            if (ddlLoanType.SelectedValue == "3")
            {
                distressLoan.ReasonForLoan = txtLoanReason.Text;
                distressLoan.LastLoanDate = DateTime.Parse(txtLastLoan.Text);
                if (FUSalarySlip.HasFile)
                {
                    string fileName = FUSalarySlip.FileName;
                    string filePath = Server.MapPath("~/SystemDocuments/SalarySlips/" + fileName);
                    FUSalarySlip.SaveAs(filePath);
                    distressLoan.SalarySlip = fileName;
                }

                if (FileUploadAggrement.HasFile)
                {
                    string fileName = FileUploadAggrement.FileName;
                    string filePath = Server.MapPath("~/SystemDocuments/DistreesLoanAggrement/" + fileName);
                    FUSalarySlip.SaveAs(filePath);
                    distressLoan.AgreementDoc = fileName;
                }
                if (validationflag)
                {
                    response = loanDetailsController.SaveAll(loanDetail, distressLoan, guarantorDetailList, requestorGuarantorsList);

                }
            }
            else
            {
                if (validationflag)
                {
                    response = loanDetailsController.Save(loanDetail);

                }
            }

            if (response != 0)
            {
                guarantorDetailList.Clear();
                requestorGuarantorsList.Clear();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Added Succesfully!', 'success');window.setTimeout(function(){window.location='RequestLoan.aspx'},2500);", true);
            }
            else
            {
                guarantorDetailList.Clear();
                requestorGuarantorsList.Clear();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something went wrong!', 'error');window.setTimeout(function(){window.location='RequestLoan.aspx'},2500);", true);

            }

        }

        protected void btnAddGuarantor_Click(object sender, EventArgs e)
        {
            GuarantorDetail gurontor = new GuarantorDetail();

            gurontor.Name = txtGuarantorName.Text;
            gurontor.Address = txtGuarantorAdress.Text;
            gurontor.Position = txtGuarantorPosition.Text;
            gurontor.AppointedDate = DateTime.Parse(txtGuarantorAppointedDate.Text);

            guarantorDetailList.Add(gurontor);
            clearGurontor();

            gvGuarantor.DataSource = guarantorDetailList;
            gvGuarantor.DataBind();

        }

        private void clearGurontor()
        {
            txtGuarantorName.Text = null;
            txtGuarantorAdress.Text = null;
            txtGuarantorPosition.Text = null;
            txtGuarantorAppointedDate.Text = null;
        }

        protected void btnAddApplicant_Click(object sender, EventArgs e)
        {
            RequestorGuarantor requestorGuarantor = new RequestorGuarantor();
            requestorGuarantor.OfficerName = txtOfficerName.Text;
            requestorGuarantor.Position = txtOfficerPosition.Text;
            requestorGuarantor.Amount = float.Parse(txtApplicantLoanAmount.Text);
            requestorGuarantor.Interest = float.Parse(txtInterest.Text);
            requestorGuarantor.PeriodicalAmount = float.Parse(txtPremiumAmount.Text);

            requestorGuarantorsList.Add(requestorGuarantor);
            clearApplicant();

            gvApplicantAsGurontor.DataSource = requestorGuarantorsList;
            gvApplicantAsGurontor.DataBind();

        }

        private void clearApplicant()
        {

            txtOfficerName.Text = null;
            txtApplicantLoanAmount.Text = null;
            txtInterest.Text = null;
            txtPremiumAmount.Text = null;
            txtOfficerPosition.Text = null;
        }

        protected void btnPdfDownload_Click(object sender, EventArgs e)
        {
            string filePath = "~/SystemDocuments/Quatations/Session-1 IT3090-Mid Examination -2022 (BMIT 3090.pdf";

            string fileName = Path.GetFileName(filePath);

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(fileBytes);
            Response.Flush();
            Response.End();
        }

        protected void LinkButtonDownloadPdf_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Session-1 IT3090-Mid Examination -2022 (BMIT 3090.pdf");
            Response.TransmitFile(Server.MapPath("~/SystemDocuments/Quatations/Session-1 IT3090-Mid Examination -2022 (BMIT 3090.pdf"));
            Response.End();
        }

        protected void btnRemovegvGuarantor_Click(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            guarantorDetailList.RemoveAt(rowIndex);

        }


        //protected void btnPdfDownload_Click(object sender, EventArgs e)
        //{
        //    string filePath = "SystemDocuments/DistreesLoanAggrement/Test.pdf";

        //    Response.Clear();
        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        //    Response.TransmitFile(filePath);
        //    Response.End();
        //}


    }
}