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
    public partial class AproveLoanAdminRecomendation : System.Web.UI.Page
    {
        static List<LoanDetail> loanDetailsList = new List<LoanDetail>();
        static List<LoanType> loanTypeList = new List<LoanType>();
        static LoanDetail loanDetailObj = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSourceBind();
            }
        }

        private void DataSourceBind()
        {
            LoanDetailsController loanDetailsController = ControllerFactory.CreateLoanDetailsController();
            loanDetailsList = loanDetailsController.GetAllLoanDetail();

            gvLoanAdminRec.DataSource = loanDetailsList;
            gvLoanAdminRec.DataBind();


            LoanTypeController loanTypeController = ControllerFactory.CreateLoanTypeController();
            loanTypeList = loanTypeController.GetAllLoanType();

            ddlLoanType.DataSource = loanTypeList;
            ddlLoanType.DataValueField = "Id";
            ddlLoanType.DataTextField = "Loan_Type_Name";
            ddlLoanType.DataBind();
            ddlLoanType.Items.Insert(0, new ListItem("Select Loan Type", ""));


        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = gvLoanAdminRec.PageSize;
            int pageindex = gvLoanAdminRec.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;

            loanDetailObj = loanDetailsList[rowIndex];

            txtName.Text = loanDetailObj.FullName;
            ddlLoanType.SelectedValue = loanDetailObj.LoanTypeId.ToString();
            txtPosition.Text = loanDetailObj.Position;
            txtPositionType.Text = loanDetailObj.WorkType;
            txtWorkPlace.Text = loanDetailObj.WorkPlace;
            txtAppointmentDate.Text = loanDetailObj.AppointedDate.ToString("yyyy/MM/dd");
            txtBasicSalary.Text = loanDetailObj.BasicSalary.ToString();
            txtLoanAmount.Text = loanDetailObj.LoanAmount.ToString();
            txtDateWanted.Text = loanDetailObj.LoanRequireDate.ToString("yyyy-MM-dd");


        }

        protected void btnApproval_Click(object sender, EventArgs e)
        {
            LoanDetailsController loanDetailsController = ControllerFactory.CreateLoanDetailsController();
            loanDetailObj.ApprovalStatusId = 2;

            int response = loanDetailsController.UpdateStatus(loanDetailObj.LoanDetailsId, 2);

            if (response != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Succesfully Updated!', 'success');window.setTimeout(function(){window.location='AproveLoanAdminRecomendation.aspx'},2500);", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something went wrong!', 'error');window.setTimeout(function(){window.location='AproveLoanAdminRecomendation.aspx'},2500);", true);

            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {

        }
    }
}