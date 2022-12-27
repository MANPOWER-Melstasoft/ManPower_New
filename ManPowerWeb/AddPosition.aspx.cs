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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            PossitionsController possitionsController = ControllerFactory.CreatePossitionsController();

            Possitions possitions = new Possitions();
            possitions.PositionName = txtName.Text;
            possitionsController.SavePosition(possitions);

            Clear();
            BindDataSource();

            lblSuccessMsg.Text = "Record Updated Successfully!";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtName.Text = string.Empty;
        }

        private void BindDataSource()
        {
            PossitionsController possitionsController = ControllerFactory.CreatePossitionsController();
            List<Possitions> positionList = possitionsController.GetAllPossitions(false, false);
            gvPosition.DataSource = positionList;
            gvPosition.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPosition.PageIndex = e.NewPageIndex;
            BindDataSource();

        }
    }
}