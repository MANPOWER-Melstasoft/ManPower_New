using ManPowerCore.Common;
using ManPowerCore.Controller;
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
    public partial class LoanReport : System.Web.UI.Page
    {
        DataTable dtloanReport = new DataTable();

        LoanDetailsController loanDetailsController = ControllerFactory.CreateLoanDetailsController();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            BindDataSource();
        }

        public void BindDataSource()
        {
            dtloanReport = loanDetailsController.getLoanReport();
            gvLoanReport.DataSource = dtloanReport;
            gvLoanReport.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            dtloanReport.DefaultView.RowFilter = "Full_Name LIKE '%" + txtKeyWord.Text + "%' " +
                "OR position LIKE '%" + txtKeyWord.Text + "%'" +
                "OR loan_type_name LIKE '%" + txtKeyWord.Text + "%'" +
                "OR district LIKE '%" + txtKeyWord.Text + "%'" +
                "OR DSDivision LIKE '%" + txtKeyWord.Text + "%'";

            gvLoanReport.DataSource = dtloanReport.DefaultView;
            gvLoanReport.DataBind();
        }

        protected void btnGetAll_Click(object sender, EventArgs e)
        {
            txtKeyWord.Text = string.Empty;
            BindDataSource();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Loan Detail Report" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gvLoanReport.GridLines = GridLines.Both;
            //tblTaSummary.HeaderStyle.Font.Bold = true;
            gvLoanReport.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
    }
}