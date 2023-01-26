using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class MainDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnHR_Click(object sender, EventArgs e)
        {
            Session["Division"] = 1;
            Response.Redirect("Dashboard.aspx");
        }

        protected void btnPROCRU_Click(object sender, EventArgs e)
        {
            Session["Division"] = 2;
            Response.Redirect("SessionManager.aspx");
        }

        protected void btnFINAN_Click(object sender, EventArgs e)
        {
            Session["Division"] = 3;
            Response.Redirect("Dashboard.aspx");
        }

        protected void btnPLAN_Click(object sender, EventArgs e)
        {
            Session["Division"] = 4;
            Response.Redirect("Dashboard.aspx");
        }
    }
}