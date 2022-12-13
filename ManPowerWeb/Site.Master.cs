using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                lblName.Text = Session["Name"].ToString();
        }
        protected void btnLogut_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");

            }
        }
    }
}