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
    public partial class DistrictTASummary : System.Web.UI.Page
    {
        List<DistrictTASummaryReport> districtTASummariesList = new List<DistrictTASummaryReport>();
        List<DistrictTASummaryReport> districtTASummariesListFinal = new List<DistrictTASummaryReport>();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataSource();
        }

        public void BindDataSource()
        {
            DistrictTASummaryController districtTASummaryController = ControllerFactory.CreateDistrictTASummaryController();

            districtTASummariesList = districtTASummaryController.GetDistrictTASummaryReport();

            var ListProgramTargetName = districtTASummariesList.Select(x => x.ProgramTargetName).Distinct();
            var ListDistrict = districtTASummariesList.Select(x => x.Location).Distinct();

            int flag = 0;


            foreach (var itemProgramTargetName in ListProgramTargetName)
            {
                foreach (var itemDistrict in ListDistrict)
                {
                    foreach (var listItem in districtTASummariesList.Where(x => x.ProgramTargetName == itemProgramTargetName))
                    {
                        if (listItem.ProjectTypeId == 2)
                        {
                            listItem.OnlineCount = 0;
                            listItem.PhysicalCount = 1;
                        }
                        else
                        {
                            listItem.OnlineCount = 1;
                            listItem.PhysicalCount = 0;
                        }

                        if (listItem.ProgramTargetName == itemProgramTargetName && listItem.Location == itemDistrict && districtTASummariesListFinal.Count == 0)
                        {
                            districtTASummariesListFinal.Add(listItem);

                        }
                        else if (listItem.ProgramTargetName == itemProgramTargetName && listItem.Location == itemDistrict && districtTASummariesListFinal.Count > 0)
                        {
                            flag = 0;
                            foreach (var finalListItem in districtTASummariesListFinal)
                            {
                                if (finalListItem.ProgramTargetName == itemProgramTargetName && finalListItem.Location == itemDistrict)
                                {
                                    flag = 1;

                                    finalListItem.NoOfBeneficiary += listItem.NoOfBeneficiary;
                                    finalListItem.Achievement += listItem.Achievement;
                                    finalListItem.Target += listItem.Target;
                                    finalListItem.PhysicalCount += listItem.PhysicalCount;
                                    finalListItem.OnlineCount += listItem.OnlineCount;


                                }

                            }
                            if (flag == 0)
                            {
                                districtTASummariesListFinal.Add(listItem);

                            }
                        }
                    }
                }
            }

            //gvTASummary.DataSource = districtTASummariesListFinal;
            //gvTASummary.DataBind();


            List<string> headers = new List<string>() { "Target", "Online", "Physical", "Total", "No. of beneficiaries" };

            TableHeaderRow thr2 = new TableHeaderRow();
            TableHeaderCell thc2 = new TableHeaderCell();

            TableHeaderRow thr1 = new TableHeaderRow();
            TableHeaderCell thc1 = new TableHeaderCell();

            thc1.Text = "";
            thr1.Cells.Add(thc1);

            thc2.Text = "ProgramTargetName";
            thr2.Cells.Add(thc2);
            thr2.Font.Size = 12;
            thr2.Font.Bold = true;

            foreach (string itemLocation in districtTASummariesListFinal.Select(x => x.Location).Distinct())
            {
                TableHeaderCell thc1i = new TableHeaderCell();
                thc1i.Text = itemLocation;
                thr1.Cells.Add(thc1i);

                int count = 0;

                foreach (var headerName in headers)
                {
                    count++;
                    TableHeaderCell thc2i = new TableHeaderCell();
                    thc2i.Text = headerName;
                    thr2.Cells.Add(thc2i);
                }

                thr1.HorizontalAlign = HorizontalAlign.Center;
                thr1.Font.Size = 12;
                thr1.Font.Bold = true;
                thc1i.ColumnSpan = count;
            }
            tblTaSummary.Rows.Add(thr1);
            tblTaSummary.Rows.Add(thr2);


            int flag2 = 0;
            foreach (var itemProgramTargetName in ListProgramTargetName)
            {
                TableRow tr = new TableRow();
                TableCell tc1 = new TableCell();
                tc1.Text = itemProgramTargetName;
                tr.Cells.Add(tc1);

                foreach (var itemDistrict in ListDistrict)
                {
                    TableCell tc21 = new TableCell();
                    TableCell tc22 = new TableCell();
                    TableCell tc23 = new TableCell();
                    TableCell tc24 = new TableCell();
                    TableCell tc25 = new TableCell();
                    flag2 = 0;

                    foreach (var item in districtTASummariesListFinal.Where(x => x.ProgramTargetName == itemProgramTargetName))
                    {
                        if (item.Location == itemDistrict)
                        {
                            flag2 = 1;
                            tc21.Text = item.Target.ToString();
                            tr.Cells.Add(tc21);
                            tc22.Text = item.OnlineCount.ToString();
                            tr.Cells.Add(tc22);
                            tc23.Text = item.PhysicalCount.ToString();
                            tr.Cells.Add(tc23);
                            tc24.Text = (item.OnlineCount + item.PhysicalCount).ToString();
                            tr.Cells.Add(tc24);
                            tc25.Text = item.NoOfBeneficiary.ToString();
                            tr.Cells.Add(tc25);
                        }
                    }
                    if (flag2 == 0)
                    {
                        tc21.Text = "0";
                        tr.Cells.Add(tc21);
                        tc22.Text = "0";
                        tr.Cells.Add(tc22);
                        tc23.Text = "0";
                        tr.Cells.Add(tc23);
                        tc24.Text = "0";
                        tr.Cells.Add(tc24);
                        tc25.Text = "0";
                        tr.Cells.Add(tc25);
                    }


                }
                tblTaSummary.Rows.Add(tr);
            }


        }

        protected void gvTASummary_DataBound(object sender, EventArgs e)
        {
            int cellCount = 6;

            for (int rowIndex = gvTASummary.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                if ((gvTASummary.Rows[rowIndex]).Cells[cellCount].Text == (gvTASummary.Rows[rowIndex + 1]).Cells[cellCount].Text)
                {
                    if ((gvTASummary.Rows[rowIndex + 1]).Cells[cellCount].RowSpan < 2)
                    {
                        (gvTASummary.Rows[rowIndex]).Cells[cellCount].RowSpan = 2;
                    }
                    else
                    {
                        (gvTASummary.Rows[rowIndex]).Cells[cellCount].RowSpan = (gvTASummary.Rows[rowIndex + 1]).Cells[cellCount].RowSpan + 1;
                    }
                    (gvTASummary.Rows[rowIndex + 1]).Cells[cellCount].Visible = false;
                }
            }
        }

        protected void gvTASummary_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView gv = (GridView)sender;
                GridViewRow gvRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell tc0 = new TableCell();
                tc0.Text = "";
                tc0.Font.Size = 12;
                tc0.Font.Bold = true;
                tc0.ColumnSpan = 2;
                tc0.RowSpan = 1;
                tc0.HorizontalAlign = HorizontalAlign.Center;

                TableCell tc1 = new TableCell();
                tc1.Text = "Achievement";
                tc1.Font.Size = 12;
                tc1.Font.Bold = true;
                tc1.ColumnSpan = 3;
                tc0.RowSpan = 1;
                tc1.HorizontalAlign = HorizontalAlign.Center;
                gvRow.Cells.Add(tc0);
                gvRow.Cells.Add(tc1);
                //gvRow.Cells.Add(tc2);

                gv.Controls[0].Controls.AddAt(0, gvRow);
            }
        }

        protected void gvTASummary_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[3].Text == "")
                {
                    e.Row.Cells[4].Text = e.Row.Cells[2].Text;
                }
                else if (e.Row.Cells[2].Text == "")
                {
                    e.Row.Cells[4].Text = e.Row.Cells[3].Text;

                }
                else
                {
                    e.Row.Cells[4].Text = (int.Parse(e.Row.Cells[3].Text) + int.Parse(e.Row.Cells[2].Text)).ToString();

                }

            }
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
            string FileName = "Target Achievement District Vise Summary" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            tblTaSummary.GridLines = GridLines.Both;
            //tblTaSummary.HeaderStyle.Font.Bold = true;
            tblTaSummary.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
    }
}