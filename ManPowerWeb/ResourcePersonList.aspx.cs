using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class ResourcePersonList : System.Web.UI.Page
    {
        static List<ResourcePerson> rp = new List<ResourcePerson>();
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

            rp = resourcePerson.GetAllResourcePerson(true);

            if (rp.Count > 0)
            {
                btnRun.Visible = true;
            }

            ViewState["rp"] = rp;
            GridView1.DataSource = rp;
            GridView1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            rp = (List<ResourcePerson>)ViewState["rp"];
            GridView1.DataSource = rp.Where(u => u.ResourcePersonType.ToLower().Contains(ddlType.SelectedValue.ToLower()) && u.Designation.ToLower().Contains(desig.Text.ToLower())).ToList();
            GridView1.DataBind();
        }

        protected void reset(object sender, EventArgs e)
        {
            desig.Text = string.Empty;
            GridView1.DataSource = rp;
            GridView1.DataBind();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (rp.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = "";
                string FileName = "Resource Person List" + DateTime.Now + ".xls";
                StringWriter strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                GridView1.GridLines = GridLines.Both;
                //tblTaSummary.HeaderStyle.Font.Bold = true;
                GridView1.RenderControl(htmltextwrtter);
                Response.Write(strwritter.ToString());
                Response.End();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindDataSource();
        }
    }
}