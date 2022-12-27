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
            if (userPrevilage.checkPrevilage(Convert.ToInt32(Session["UserId"]), functionId)) { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            PossitionsController possitionsController = ControllerFactory.CreatePossitionsController();

            Possitions possitions = new Possitions();
            possitions.PositionName = txtName.Text;
            possitionsController.SavePosition(possitions);

            Clear();

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
    }
}