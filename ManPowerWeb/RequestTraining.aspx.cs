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
    public partial class RequestTraining : System.Web.UI.Page
    {
        List<Training_Request> trainingRequestList = new List<Training_Request>();
        public int depId;

        public int trainingRequestId;
        List<EmploymentDetails> employeeDetailList = new List<EmploymentDetails>();
        protected void Page_Load(object sender, EventArgs e)
        {
            depId = Convert.ToInt32(Session["DepUnitPositionId"]);

            if (!IsPostBack)
            {
                BindDataSource();
                bindddlEmployee();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string url = "addtrainingrequest.aspx?" + "TrainingRequestId=" + 0;
            Response.Redirect(url);
        }

        public void BindDataSource()
        {
            TrainingRequestController trainingRequestController = ControllerFactory.CreateTrainingRequestController();
            trainingRequestList = trainingRequestController.GetAllPendingTrainingRequest(depId);

            gvRequestTraining.DataSource = trainingRequestList;
            gvRequestTraining.DataBind();
        }

        public void bindddlEmployee()
        {
            EmploymentDetailsController employeeDetailController = ControllerFactory.CreateEmploymentDetailsController();

            employeeDetailList = employeeDetailController.GetAllEmploymentDetails();


            ddlEmployee.DataSource = employeeDetailList;
            ddlEmployee.DataValueField = "EmpID";
            ddlEmployee.DataTextField = "EmpID";
            ddlEmployee.DataBind();
        }

        protected void btnAction_Click(object sender, EventArgs e)
        {
            BindDataSource();

            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            trainingRequestId = trainingRequestList[rowIndex].TrainingRequestId;

            string url = "addtrainingrequest.aspx?" + "TrainingRequestId=" + trainingRequestId;
            Response.Redirect(url);
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            BindDataSource();

            trainingRequestList = trainingRequestList.Where(x => x.ProgramDate == Convert.ToDateTime(txtDate.Value) && x.Employee_Id == Convert.ToInt32(ddlEmployee.SelectedValue)).ToList();

            gvRequestTraining.DataSource = trainingRequestList;
            gvRequestTraining.DataBind();
        }
    }
}