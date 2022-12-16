using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                if (!IsPostBack)
                {
                    lblName.Text = Session["Name"].ToString();
                    BindSideBar();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }


        protected void BindSideBar()
        {
            int userId = Convert.ToInt32(Session["UserId"]);

            AutUserFunctionController autUserFunctionController = ControllerFactory.CreateAutUserFunctionController();

            List<AutUserFunction> autUserFunctionList = autUserFunctionController.GetAllAutUserFunctionByUserId(true, userId);

            StringBuilder cstextCard = new StringBuilder();

            foreach (var item in autUserFunctionList)
            {
                cstextCard.Append("<li class=\"nav-item\">");
                cstextCard.Append("<a class=\"nav-link\" href=");
                cstextCard.Append(item.autFunction.Url);
                cstextCard.Append("> <i class=\"");
                cstextCard.Append(item.autFunction.MenuIcon);
                cstextCard.Append("\"></i> <span>");
                cstextCard.Append(item.autFunction.FunctionName);
                cstextCard.Append("</span></a>");
                cstextCard.Append("</li>");
            }

            ltSideBar.Text += cstextCard;

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