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
    public partial class AddPosition : System.Web.UI.Page
    {
        static List<Possitions> positionList = new List<Possitions>();
        UserPrevilage userPrevilage = new UserPrevilage();
        int functionId = 37;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (userPrevilage.checkPrevilage(Convert.ToInt32(Session["UserId"]), functionId))
            {
                if (!IsPostBack)
                {
                    BindDataSource();
                }
            }
        }
        private void BindDataSource()
        {
            PossitionsController possitionsController = ControllerFactory.CreatePossitionsController();
            positionList = possitionsController.GetAllPossitions(false, false);
            gvPosition.DataSource = positionList;
            gvPosition.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int output;
            PossitionsController possitionsController = ControllerFactory.CreatePossitionsController();

            Possitions possitions = new Possitions();
            possitions.PositionName = txtName.Text;

            if (btnSubmit.Text == "Update")
            {
                possitions.PossitionId = Convert.ToInt32(ViewState["posId"]);
                possitions.IsActive = 1;
                output = possitionsController.UpdatePosition(possitions);

                if (output == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Possition Updated Succesfully!', 'success')", true);
                    btnSubmit.Text = "Create";
                    Clear();
                    BindDataSource();
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Possition Updated Fail!', 'error');", true);
                }
            }
            else
            {
                output = possitionsController.SavePosition(possitions);
                if (output == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Possition Updated Succesfully!', 'success')", true);
                    btnSubmit.Text = "Create";
                    Clear();
                    BindDataSource();
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Possition Updated Fail!', 'error');", true);
                }
                //lblSuccessMsg.Text = "Record Updated Successfully!";
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = gvPosition.PageSize;
            int pageindex = gvPosition.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;

            Possitions possitions = positionList[rowIndex];
            txtName.Text = possitions.PositionName;

            btnSubmit.Text = "Update";
            ViewState["posId"] = possitions.PossitionId;
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = gvPosition.PageSize;
            int pageindex = gvPosition.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;

            Possitions possitions = positionList[rowIndex];
            int output;
            PossitionsController possitionsController = ControllerFactory.CreatePossitionsController();

            possitions.IsActive = 0;
            output = possitionsController.UpdatePosition(possitions);

            if (output == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Program Deleted Succesfully!', 'success')", true);
                BindDataSource();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Program Deleted Fail!', 'error');", true);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            btnSubmit.Text = "Create";
            Clear();
        }

        private void Clear()
        {
            txtName.Text = string.Empty;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPosition.PageIndex = e.NewPageIndex;
            BindDataSource();

        }
    }
}