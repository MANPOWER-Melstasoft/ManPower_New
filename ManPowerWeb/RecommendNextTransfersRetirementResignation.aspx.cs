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
    public partial class RecommendNextTransfersRetirementResignation : System.Web.UI.Page
    {
        static List<TransfersRetirementResignationMain> mainList;
        static List<TransfersRetirementResignationMain> filterList;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                BindDataSource();
                BindDdlType();
            }
        }

        private void BindDataSource()
        {
            DepartmentUnitPositionsController departmentUnitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
            DepartmentUnitPositions departmentUnitPositions = new DepartmentUnitPositions();
            DepartmentUnitPositions departmentUnitPositionsCheckAdmint = new DepartmentUnitPositions();
            departmentUnitPositionsCheckAdmint = departmentUnitPositionsController.departmentUnitPositionWithPID(Convert.ToInt32(Session["UserId"]), true);

            TransfersRetirementResignationMainController main = ControllerFactory.CreateTransfersRetirementResignationMainController();
            List<TransfersRetirementResignationMain> mainListIn = main.GetAllTransfersRetirementResignation(false);

            int userType = Convert.ToInt32(Session["UserTypeId"]);
            int designationId = Convert.ToInt32(Session["DesignationId"]);

            try
            {
                if (designationId == 34)
                {
                    mainListIn = mainListIn.Where(x => x.StatusId == 6).ToList();
                    lblName.Text = " AD ";
                }
                else if (designationId == 5)
                {
                    mainListIn = mainListIn.Where(x => x.StatusId == 7).ToList();
                    lblName.Text = " Director ";
                }
                else
                {
                    mainListIn.Clear();
                }

            }
            catch (Exception ex)
            {
                mainListIn.Clear();
            }

            mainList = new List<TransfersRetirementResignationMain>();

            mainList = mainListIn.ToList();
            filterList = mainList.ToList();

            GridView1.DataSource = filterList;
            GridView1.DataBind();

        }

        private void BindDdlType()
        {
            RequestTypeController requestTypeController = ControllerFactory.CreateRequestTypeController();
            List<RequestType> type = requestTypeController.GetAllRequestType(false);

            ddltype.DataSource = type;
            ddltype.DataValueField = "Id";
            ddltype.DataTextField = "RequestTypeName";
            ddltype.DataBind();
            ddltype.Items.Insert(0, new ListItem("All", ""));
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = GridView1.PageSize;
            int pageindex = GridView1.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;
            Response.Redirect("RecommendNextTransfersRetirementResignationView.aspx?Id=" + filterList[rowIndex].MainId);

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindDataSource();
        }

        protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddltype.SelectedValue == "1")
            {
                filterList = mainList.Where(a => a.RequestTypeId == 1).ToList();
                GridView1.DataSource = filterList;
            }
            else if (ddltype.SelectedValue == "2")
            {
                filterList = mainList.Where(a => a.RequestTypeId == 2).ToList();
                GridView1.DataSource = filterList;
            }
            else if (ddltype.SelectedValue == "3")
            {
                filterList = mainList.Where(a => a.RequestTypeId == 3).ToList();
                GridView1.DataSource = filterList;
            }
            else if (ddltype.SelectedValue == "4")
            {
                filterList = mainList.Where(a => a.RequestTypeId == 4).ToList();
                GridView1.DataSource = filterList;
            }
            else
            {
                filterList = mainList;
                GridView1.DataSource = filterList;
            }
            GridView1.DataBind();
        }
    }
}