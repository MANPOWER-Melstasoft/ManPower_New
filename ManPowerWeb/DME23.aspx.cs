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
    public partial class DME23 : System.Web.UI.Page
    {
        private string officerName;
        private string userId;

        public int depId;

        public string OfficerName { get { return officerName; } }
        public string UserId { get { return userId; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            officerName = Session["Name"].ToString();
            userId = Session["UserId"].ToString();
            depId = Convert.ToInt32(Session["DepUnitPositionId"]);

            BindMonth();
            bindDataSource();
        }

        private void bindDataSource()
        {
            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();

            DataTable programPlan = programPlanController.getProgramPlan(depId);

            gvDme23.DataSource = programPlan;
            gvDme23.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "DME23" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gvDme23.GridLines = GridLines.Both;
            //tblTaSummary.HeaderStyle.Font.Bold = true;
            gvDme23.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ProgramPlanController programPlanController = ControllerFactory.CreateProgramPlanController();

            DataTable programPlan = programPlanController.getProgramPlan(depId);

            string txtProgram = txtName.Text;
            int month = Convert.ToInt32(ddlMonth.SelectedValue);


            if (txtProgram != "")
            {
                programPlan.DefaultView.RowFilter = "Program_Name LIKE '%" + txtProgram + "%' AND MONTH(Date) =" + month;

                gvDme23.DataSource = programPlan;
                gvDme23.DataBind();
            }

            else
            {
                programPlan.DefaultView.RowFilter = "MONTH(Date) =" + month;

                gvDme23.DataSource = programPlan;
                gvDme23.DataBind();
            }
        }

        protected void btnGetAll_Click(object sender, EventArgs e)
        {
            bindDataSource();
        }

        private void BindMonth()
        {
            List<Month> monthTable = new List<Month>();

            monthTable.Add(new Month() { monthName = "January", monthNumber = 1 });
            monthTable.Add(new Month() { monthName = "February", monthNumber = 2 });
            monthTable.Add(new Month() { monthName = "March", monthNumber = 3 });
            monthTable.Add(new Month() { monthName = "April", monthNumber = 4 });
            monthTable.Add(new Month() { monthName = "May", monthNumber = 5 });
            monthTable.Add(new Month() { monthName = "June", monthNumber = 6 });
            monthTable.Add(new Month() { monthName = "July", monthNumber = 7 });
            monthTable.Add(new Month() { monthName = "August", monthNumber = 8 });
            monthTable.Add(new Month() { monthName = "September", monthNumber = 9 });
            monthTable.Add(new Month() { monthName = "October", monthNumber = 10 });
            monthTable.Add(new Month() { monthName = "November", monthNumber = 11 });
            monthTable.Add(new Month() { monthName = "December", monthNumber = 12 });

            ddlMonth.DataSource = monthTable;
            ddlMonth.DataBind();
        }
    }
}