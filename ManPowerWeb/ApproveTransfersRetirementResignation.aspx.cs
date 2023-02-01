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
    public partial class ApproveTransfersRetirementResignation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataSource();
            }
        }

        private void BindDataSource()
        {
            DepartmentUnitPositionsController departmentUnitPositionsController = ControllerFactory.CreateDepartmentUnitPositionsController();
            DepartmentUnitPositions departmentUnitPositions = new DepartmentUnitPositions();

            TransfersRetirementResignationMainController main = ControllerFactory.CreateTransfersRetirementResignationMainController();
            List<TransfersRetirementResignationMain> mainList = main.GetAllTransfersRetirementResignation(false);
            List<TransfersRetirementResignationMain> filterList = new List<TransfersRetirementResignationMain>();

            foreach (var item in mainList)
            {
                if (item.ParentId != 0 && item.ParentId != 1)
                {
                    departmentUnitPositions = departmentUnitPositionsController.GetDepartmentUnitPositions(item.ParentId, false, false, false, false, false);
                    if (departmentUnitPositions.SystemUserId == Convert.ToInt32(Session["UserId"]))
                    {
                        filterList.Add(item);
                    }
                }
                else
                {
                    if (item.EmployeeId == Convert.ToInt32(Session["EmpNumber"]))
                    {
                        filterList.Add(item);
                    }
                }

            }


            GridView1.DataSource = filterList;
            GridView1.DataBind();

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            BindDataSource();
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = GridView1.PageSize;
            int pageindex = GridView1.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;
            Response.Redirect("AddTransfersRetirementResignation.aspx?ProgramTargetId=");

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;


            BindDataSource();


        }
    }
}