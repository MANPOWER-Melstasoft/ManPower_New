using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class TASummary : System.Web.UI.Page
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

            districtTASummariesList = districtTASummaryController.GetIndividualTASummaryReport();

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

            //gvIndividualTASummary.DataSource = districtTASummariesListFinal;
            //gvIndividualTASummary.DataBind();


            List<string> headers = new List<string>() { "Target", "Online", "Physical", "Total", "No. of beneficiaries" };

            TableHeaderRow thr2 = new TableHeaderRow();
            TableHeaderCell thc2 = new TableHeaderCell();

            TableHeaderRow thr1 = new TableHeaderRow();
            TableHeaderCell thc1 = new TableHeaderCell();

            TableHeaderRow thr3 = new TableHeaderRow();
            TableHeaderCell thc3 = new TableHeaderCell();

            thc1.Text = "";
            thr1.Cells.Add(thc1);
            thc2.Text = "";
            thr2.Cells.Add(thc2);

            thc3.Text = "ProgramTargetName";
            thr3.Cells.Add(thc3);
            thr3.Font.Size = 12;
            thr3.Font.Bold = true;

            foreach (string itemLocation in districtTASummariesListFinal.Select(x => x.Location).Distinct())
            {
                TableHeaderCell thc1i = new TableHeaderCell();
                thc1i.Text = itemLocation;
                thr1.Cells.Add(thc1i);

                int count1 = 0;
                int total = 0;
                foreach (string officerName in districtTASummariesListFinal.Where(x => x.Location == itemLocation).Select(x => x.OfficerName).Distinct())
                {
                    count1++;
                    TableHeaderCell thc2i = new TableHeaderCell();
                    thc2i.Text = officerName;
                    thr2.HorizontalAlign = HorizontalAlign.Center;
                    thr2.Font.Size = 12;
                    thr2.Font.Bold = true;
                    thr2.Cells.Add(thc2i);

                    int count2 = 0;
                    foreach (var headerName in headers)
                    {
                        count2++;
                        TableHeaderCell thc3i = new TableHeaderCell();
                        thc3i.Text = headerName;
                        thr3.Cells.Add(thc3i);
                    }
                    thc2i.ColumnSpan = count2;
                    total += count1 * count2;
                }
                thr1.HorizontalAlign = HorizontalAlign.Center;
                thr1.Font.Size = 12;
                thr1.Font.Bold = true;
                thc1i.ColumnSpan = total;
            }
            tblTaSummary.Rows.Add(thr1);
            tblTaSummary.Rows.Add(thr2);
            tblTaSummary.Rows.Add(thr3);

            int flag2 = 0;
            foreach (var itemProgramTargetName in ListProgramTargetName)
            {
                TableRow tr = new TableRow();
                TableCell tc1 = new TableCell();
                tc1.Text = itemProgramTargetName;
                tr.Cells.Add(tc1);

                foreach (var itemDistrict in ListDistrict)
                {
                    foreach (string officerName in districtTASummariesListFinal.Where(x => x.Location == itemDistrict).Select(x => x.OfficerName).Distinct())
                    {
                        TableCell tc21 = new TableCell();
                        TableCell tc22 = new TableCell();
                        TableCell tc23 = new TableCell();
                        TableCell tc24 = new TableCell();
                        TableCell tc25 = new TableCell();
                        flag2 = 0;

                        foreach (var item in districtTASummariesListFinal.Where(x => x.ProgramTargetName == itemProgramTargetName))
                        {
                            if (item.OfficerName == officerName && item.Location == itemDistrict)
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
                }
                tblTaSummary.Rows.Add(tr);
            }


        }

        protected void gvIndividualTASummary_DataBound(object sender, EventArgs e)
        {
            int cellCount = 7;
            for (int rowIndex = gvIndividualTASummary.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                if ((gvIndividualTASummary.Rows[rowIndex]).Cells[cellCount].Text == (gvIndividualTASummary.Rows[rowIndex + 1]).Cells[cellCount].Text)
                {
                    if ((gvIndividualTASummary.Rows[rowIndex + 1]).Cells[cellCount].RowSpan < 2)
                    {
                        (gvIndividualTASummary.Rows[rowIndex]).Cells[cellCount].RowSpan = 2;
                    }
                    else
                    {
                        (gvIndividualTASummary.Rows[rowIndex]).Cells[cellCount].RowSpan = (gvIndividualTASummary.Rows[rowIndex + 1]).Cells[cellCount].RowSpan + 1;
                    }
                    (gvIndividualTASummary.Rows[rowIndex + 1]).Cells[cellCount].Visible = false;
                }
            }

            int cellCount2 = 6;
            for (int rowIndex = gvIndividualTASummary.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                if ((gvIndividualTASummary.Rows[rowIndex]).Cells[cellCount2].Text == (gvIndividualTASummary.Rows[rowIndex + 1]).Cells[cellCount2].Text)
                {
                    if ((gvIndividualTASummary.Rows[rowIndex + 1]).Cells[cellCount2].RowSpan < 2)
                    {
                        (gvIndividualTASummary.Rows[rowIndex]).Cells[cellCount2].RowSpan = 2;
                    }
                    else
                    {
                        (gvIndividualTASummary.Rows[rowIndex]).Cells[cellCount2].RowSpan = (gvIndividualTASummary.Rows[rowIndex + 1]).Cells[cellCount2].RowSpan + 1;
                    }
                    (gvIndividualTASummary.Rows[rowIndex + 1]).Cells[cellCount2].Visible = false;
                }
            }
        }

        protected void gvIndividualTASummary_RowCreated(object sender, GridViewRowEventArgs e)
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

        protected void gvIndividualTASummary_RowDataBound(object sender, GridViewRowEventArgs e)
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
            string FileName = "Target Achievement Individual Summary" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gvIndividualTASummary.GridLines = GridLines.Both;
            gvIndividualTASummary.HeaderStyle.Font.Bold = true;
            gvIndividualTASummary.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
    }
}