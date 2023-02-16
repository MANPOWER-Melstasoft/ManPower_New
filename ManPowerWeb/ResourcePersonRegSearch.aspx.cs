using Antlr.Runtime;
using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class ResourcePersonRegSearch : System.Web.UI.Page
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

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (rp.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                string FileName = "Individual Beneficiary List" + DateTime.Now + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    GridView gridView = GridView1;

                    gridView.AllowPaging = false;
                    gridView.AllowSorting = false;
                    gridView.DataBind();

                    gridView.RenderControl(hw);

                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }

                //Response.Clear();
                //Response.Buffer = true;
                //Response.ClearContent();
                //Response.ClearHeaders();
                //Response.Charset = "";
                //string FileName = "Individual Beneficiary List" + DateTime.Now + ".xls";
                //StringWriter strwritter = new StringWriter();
                //HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.ContentType = "application/vnd.ms-excel";
                //Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                //GridView1.GridLines = GridLines.Both;
                ////tblTaSummary.HeaderStyle.Font.Bold = true;
                //GridView1.RenderControl(htmltextwrtter);
                //Response.Write(strwritter.ToString());
                //Response.End();
            }
        }

    }
}