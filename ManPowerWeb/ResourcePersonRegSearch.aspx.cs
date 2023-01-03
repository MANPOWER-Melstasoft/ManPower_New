using Antlr.Runtime;
using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class ResourcePersonRegSearch : System.Web.UI.Page
    {
        List <ResourcePerson> rp = new List<ResourcePerson> ();
        string[] type = { "DME", "External" };
 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataSource();
            }
        }

        private void BindDataSource()
        {
            ddlType.DataSource = type;
            ddlType.DataBind();

            ResourcePersonController resourcePerson = ControllerFactory.CreateResourcePersonController();

            rp = resourcePerson.GetAllResourcePerson();

            ViewState["rp"] = rp;
            GridView1.DataSource = rp;
            GridView1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            rp = (List<ResourcePerson>)ViewState["rp"];
            GridView1.DataSource = rp.Where(u => u.ResourcePersonType == ddlType.SelectedValue && u.Designation == desig.Text);
            GridView1.DataBind();
        }

        protected void isClicked(object sender, EventArgs e)
        {
            Response.Redirect("ResourcePersonReg.aspx");
        }

        protected void reset(object sender, EventArgs e)
        {
            Response.Redirect("ResourcePersonRegSearch.aspx");
        }

    }
}