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
    public partial class RequestLoan : System.Web.UI.Page
    {
        List<LoanType> loanTypeList = new List<LoanType>();
        protected void Page_Load(object sender, EventArgs e)
        {
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
            LoanDetailsController loanDetailsController = ControllerFactory.CreateLoanDetailsController();

            loanDetail.FullName = txtName.Text;
            loanDetail.LoanTypeId = Convert.ToInt32(ddlLoanType.SelectedValue);
            loanDetail.Position = txtPosition.Text;
            loanDetail.WorkType = txtPositionType.Text;
            loanDetail.WorkPlace = txtWorkPlace.Text;
            loanDetail.AppointedDate = Convert.ToDateTime(txtAppointmentDate.Text);
            loanDetail.BasicSalary = float.Parse(txtBasicSalary.Text);
            loanDetail.LoanAmount = float.Parse(txtLoanAmount.Text);
            loanDetail.LoanRequireDate = Convert.ToDateTime(txtDateWanted.Text);
            loanDetail.CreatedDate = DateTime.Now;
            loanDetail.EmployeeId = Convert.ToInt32(Session["EmpNumber"]);

            int response = loanDetailsController.Save(loanDetail);

        }
    }
}