using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class SessionManager1 : System.Web.UI.Page
    {
        string id = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //id = Request.QueryString["id"].ToString();
            SessionManager();
        }



        private void SessionManager()
        {
            //StringBuilder cstextCard = new StringBuilder();

            //switch (id)
            //{
            //    case "1":
            //        //Response.Write("<form name=t id=t runat=server target=_newpage action=Sessiontransfer.aspx method=post>");
            //        break;
            //    default:
            //        Response.Redirect("404.aspx");
            //        break;
            //}

            //cstextCard.Append("<asp:TextBox ID=\"txtUserId\" runat=\"server\" Visible=\"false\" Value=\"");
            //cstextCard.Append(Session["UserId"].ToString());
            //cstextCard.Append("\"></asp:TextBox>");

            //ltlTextBox.Text += cstextCard;

            //Response.Write("<script>form1.submit();</script>");

            Response.Redirect("http://dme-procurement-web-uat.melstasoft.com/Sessiontransfer.aspx?UserId=" + Session["UserId"].ToString() +
                "&Name=" + Session["Name"].ToString() +
                "&EmpNumber=" + Session["EmpNumber"].ToString() +
                "&DepUnitParentId=" + Session["DepUnitParentId"].ToString() +
                "&DepUnitPositionId=" + Session["DepUnitPositionId"].ToString());

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}