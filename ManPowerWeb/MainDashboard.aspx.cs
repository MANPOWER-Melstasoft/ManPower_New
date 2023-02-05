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
            if (Session["UserTypeId"].ToString() == "1")
            {
                Session["Division"] = 1;
                Response.Redirect("Dashboard.aspx");

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Access Denied!', 'error');", true);
            }

        }

        protected void btnPROCRU_Click(object sender, EventArgs e)
        {
            if (Session["UserTypeId"].ToString() == "1")
            {
                Session["Division"] = 2;
                Response.Redirect("SessionManager.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Access Denied!', 'error');", true);
            }
        }

        protected void btnFINAN_Click(object sender, EventArgs e)
        {
            if (Session["UserTypeId"].ToString() == "1")
            {
                Session["Division"] = 3;
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Access Denied!', 'error');", true);
            }
        }

        protected void btnPLAN_Click(object sender, EventArgs e)
        {
            if (Session["UserTypeId"].ToString() == "1" || Session["UserTypeId"].ToString() == "2" || Session["UserTypeId"].ToString() == "3")
            {
                Session["Division"] = 4;
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Access Denied!', 'error');", true);
            }
        }

        protected void btnICT_Click(object sender, EventArgs e)
        {
            if (Session["UserTypeId"].ToString() == "4")
            {
                Session["Division"] = 5;
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Access Denied!', 'error');", true);
            }
        }

    }
}