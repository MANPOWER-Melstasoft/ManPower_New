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
    public partial class TransferReport : System.Web.UI.Page
    {
        SystemUserController systemUserController = ControllerFactory.CreateSystemUserController();

        TransfersRetirementResignationMainController transfersRetirementResignationMainController = ControllerFactory.CreateTransfersRetirementResignationMainController();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            BindDataSource();
        }

        public void BindDataSource()
        {
            List<TransfersRetirementResignationMain> transferList = transfersRetirementResignationMainController.GetAllTransfersRetirementResignation(false);

            List<SystemUser> systemUserList = systemUserController.GetAllSystemUser(false, false, false);

            transferList = transferList.Where(x => x.RequestTypeId == 1 && x.StatusId == 2).ToList();

            foreach (var item in transferList)
            {
                item.ActionTakenUser = systemUserList.Where(x => x.SystemUserId == item.ActionTakenUserId).Single();
            }

            gvTransferReport.DataSource = transferList;
            gvTransferReport.DataBind();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            BindDataSource();

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Transfer Detail Report" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gvTransferReport.GridLines = GridLines.Both;
            //tblTaSummary.HeaderStyle.Font.Bold = true;
            gvTransferReport.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
    }
}