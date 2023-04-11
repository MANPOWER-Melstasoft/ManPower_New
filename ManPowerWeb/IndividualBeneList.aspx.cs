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
    public partial class IndividualBeneList : System.Web.UI.Page
    {
        List<InduvidualBeneficiary> beneficiaries = new List<InduvidualBeneficiary>();
        static List<InduvidualBeneficiary> beneficiariesFinalList = new List<InduvidualBeneficiary>();
        List<InduvidualBeneficiary> filtered = new List<InduvidualBeneficiary>();
        string[] gen = { "Male", "Female" };
        string[] scl = { "School", "Non School" };

        List<IndividualBeneReport> beneficiariesReport = new List<IndividualBeneReport>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                BindDataSource();
            }
        }

        private void BindDataSource()
        {

            ddlGen.DataSource = gen;
            ddlGen.DataBind();
            ddlGen.Items.Insert(0, new ListItem(""));

            ddlScl.DataSource = scl;
            ddlScl.DataBind();
            ddlScl.Items.Insert(0, new ListItem(""));

            InduvidualBeneficiaryController bc = ControllerFactory.CreateInduvidualBeneficiaryController();
            beneficiaries = bc.GetAllInduvidualBeneficiary(true);

            //GridView1.DataSource = beneficiaries;
            //GridView1.DataBind();

            IndividualBeneReportController beneReportController = ControllerFactory.CreateIndividualBeneReportController();
            beneficiariesReport = beneReportController.GetReport();

            //GridView1.DataSource = beneficiariesReport;
            //GridView1.DataBind();

            BindDataTable();
        }

        public void BindDataTable()
        {
            CareerKeyTestResultsController careerKeyTestResultsController = ControllerFactory.CreateCareerKeyTestResultsController();
            TrainingRefferalsController trainingRefferalsController = ControllerFactory.CreateTrainingRefferalController();
            JobRefferalsController jobRefferalsController = ControllerFactory.CreateJobRefferalsController();

            //------------------------------------------------------ Create Table Header ---------------------------------------------------------------------
            List<string> headersBene = new List<string>() {
                "Benificiary Id", "Nic", "Name", "Gender", "DOB", "Personal Address", "Email", "Job Preference", "Contact Number",
                "WhatsappNumber", "Is School Student", "School Name", "School Address", "Grade", "Parent Nic",
                "Career Key Test Id", "R", "I", "A", "S", "E", "C", "Provided Guidance", "Career Key Test Held Date", "Career Key Test Program Plan",
                 "Training Refferals Id", "Institute Name", "Training Course", "Contact Person", "Training Refferals Date", "Training Refferals Program Plan",
                 "Job Refferals Id", "Company Name", "Career Path", "Job Position", "Career Guidance", "Remarks", "Job Refferals Date", "Job Placement Date",
                "Job Refferals Program Plan"
            };

            TableHeaderRow thr1 = new TableHeaderRow();

            foreach (var head in headersBene)
            {
                TableHeaderCell thc1i = new TableHeaderCell();
                thc1i.Text = head;
                thr1.Cells.Add(thc1i);
            }

            thr1.HorizontalAlign = HorizontalAlign.Center;
            thr1.Font.Size = 12;
            thr1.Font.Bold = true;
            tblBene.Rows.Add(thr1);
            //----------------------------------------------------------------------------------------------------------------------------------------------

            //------------------------------------------------------ Create Table Data ---------------------------------------------------------------------
            var beneId = beneficiariesReport.Select(x => x.BenificiaryId).Distinct();

            int ctrCount = 0, trCount = 0, jrCount = 0, max = 0;

            foreach (var bene in beneId)
            {
                List<IndividualBeneReport> individualBeneReport = beneficiariesReport.Where(x => x.BenificiaryId == bene).ToList();

                ctrCount = individualBeneReport.Select(x => x.CareerKeyTestId).Distinct().Count();
                trCount = individualBeneReport.Select(x => x.TrainingRefferalsId).Distinct().Count();
                jrCount = individualBeneReport.Select(x => x.JobRefferalsId).Distinct().Count();
                max = getmax(ctrCount, trCount, jrCount);

                TableRow tr = new TableRow();
                TableCell tc1 = new TableCell(); TableCell tc2 = new TableCell();
                TableCell tc3 = new TableCell(); TableCell tc4 = new TableCell();
                TableCell tc5 = new TableCell(); TableCell tc6 = new TableCell();
                TableCell tc7 = new TableCell(); TableCell tc8 = new TableCell();
                TableCell tc9 = new TableCell(); TableCell tc10 = new TableCell();
                TableCell tc11 = new TableCell(); TableCell tc12 = new TableCell();
                TableCell tc13 = new TableCell(); TableCell tc14 = new TableCell();
                TableCell tc15 = new TableCell();

                tc1.Text = individualBeneReport[0].BenificiaryId.ToString();
                tc2.Text = individualBeneReport[0].BeneficiaryNic;
                tc3.Text = individualBeneReport[0].InduvidualBeneficiaryName;
                tc4.Text = individualBeneReport[0].BeneficiaryGender;
                tc5.Text = individualBeneReport[0].DateOfBirth.ToString("yyyy-MM-dd");
                tc6.Text = individualBeneReport[0].PersonalAddress;
                tc7.Text = individualBeneReport[0].BeneficiaryEmail;
                tc8.Text = individualBeneReport[0].JobPreference;
                tc9.Text = individualBeneReport[0].ContactNumber;
                tc10.Text = individualBeneReport[0].WhatsappNumber;
                if (individualBeneReport[0].IsSchoolStudent == 1) { tc11.Text = "Yes"; }
                else { tc11.Text = "No"; }
                tc12.Text = individualBeneReport[0].SchoolName;
                tc13.Text = individualBeneReport[0].AddressOfSchool;
                tc14.Text = individualBeneReport[0].SchoolGrade;
                tc15.Text = individualBeneReport[0].ParentNic;

                tr.Cells.Add(tc1); tr.Cells.Add(tc2);
                tr.Cells.Add(tc3); tr.Cells.Add(tc4);
                tr.Cells.Add(tc5); tr.Cells.Add(tc6);
                tr.Cells.Add(tc7); tr.Cells.Add(tc8);
                tr.Cells.Add(tc9); tr.Cells.Add(tc10);
                tr.Cells.Add(tc11); tr.Cells.Add(tc12);
                tr.Cells.Add(tc13); tr.Cells.Add(tc14);
                tr.Cells.Add(tc15);

                //----------------------------------- Add Career Key Test Data ------------------------------------------
                TableCell tc1i = new TableCell(); TableCell tc2i = new TableCell();
                TableCell tc3i = new TableCell(); TableCell tc4i = new TableCell();
                TableCell tc5i = new TableCell(); TableCell tc6i = new TableCell();
                TableCell tc7i = new TableCell(); TableCell tc8i = new TableCell();
                TableCell tc9i = new TableCell(); TableCell tc10i = new TableCell();

                List<CareerKeyTestResults> CareerKeyTestResultsList = careerKeyTestResultsController.GetAllCareerKeyTestResultsByBene(bene);

                if (CareerKeyTestResultsList.Count != 0)
                {
                    tc1i.Text = CareerKeyTestResultsList[0].Id.ToString();
                    tc2i.Text = CareerKeyTestResultsList[0].R.ToString();
                    tc3i.Text = CareerKeyTestResultsList[0].I.ToString();
                    tc4i.Text = CareerKeyTestResultsList[0].A.ToString();
                    tc5i.Text = CareerKeyTestResultsList[0].S.ToString();
                    tc6i.Text = CareerKeyTestResultsList[0].E.ToString();
                    tc7i.Text = CareerKeyTestResultsList[0].C.ToString();
                    tc8i.Text = CareerKeyTestResultsList[0].Guidence;
                    tc9i.Text = CareerKeyTestResultsList[0].HeldDate.ToString("yyyy-MM-dd");
                    if (CareerKeyTestResultsList[0].Program_Plan_Id != 0)
                    {
                        tc10i.Text = CareerKeyTestResultsList[0].ProgramPlan.ProgramName;
                    }
                    else
                    {
                        tc10i.Text = "";
                    }
                }
                else
                {
                    tc1i.Text = ""; tc2i.Text = "";
                    tc3i.Text = ""; tc4i.Text = "";
                    tc5i.Text = ""; tc6i.Text = "";
                    tc7i.Text = ""; tc8i.Text = "";
                    tc9i.Text = ""; tc10i.Text = "";
                }
                tr.Cells.Add(tc1i); tr.Cells.Add(tc2i);
                tr.Cells.Add(tc3i); tr.Cells.Add(tc4i);
                tr.Cells.Add(tc5i); tr.Cells.Add(tc6i);
                tr.Cells.Add(tc7i); tr.Cells.Add(tc8i);
                tr.Cells.Add(tc9i); tr.Cells.Add(tc10i);

                //----------------------------------- Add Training Referel Data ------------------------------------------
                TableCell tc1t = new TableCell(); TableCell tc2t = new TableCell();
                TableCell tc3t = new TableCell(); TableCell tc4t = new TableCell();
                TableCell tc5t = new TableCell(); TableCell tc6t = new TableCell();

                List<TrainingRefferals> trainingRefferalsList = trainingRefferalsController.GetAllTrainingRefferalsByBene(bene);

                if (trainingRefferalsList.Count != 0)
                {
                    tc1t.Text = trainingRefferalsList[0].Id.ToString();
                    tc2t.Text = trainingRefferalsList[0].InstituteName;
                    tc3t.Text = trainingRefferalsList[0].TrainingCourse;
                    tc4t.Text = trainingRefferalsList[0].ContactPerson;
                    tc5t.Text = trainingRefferalsList[0].RefferalsDate.ToString("yyyy-MM-dd");
                    if (trainingRefferalsList[0].Program_Plan_Id != 0)
                    {
                        tc6t.Text = trainingRefferalsList[0].ProgramPlan.ProgramName;
                    }
                    else
                    {
                        tc6t.Text = "";
                    }
                }
                else
                {
                    tc1t.Text = ""; tc2t.Text = "";
                    tc3t.Text = ""; tc4t.Text = "";
                    tc5t.Text = ""; tc6t.Text = "";
                }
                tr.Cells.Add(tc1t); tr.Cells.Add(tc2t);
                tr.Cells.Add(tc3t); tr.Cells.Add(tc4t);
                tr.Cells.Add(tc5t); tr.Cells.Add(tc6t);

                //---------------------------------------------------------------------------------------------------------

                //---------------------------------------- Add Job Referal Data -------------------------------------------
                TableCell tc1j = new TableCell(); TableCell tc2j = new TableCell();
                TableCell tc3j = new TableCell(); TableCell tc4j = new TableCell();
                TableCell tc5j = new TableCell(); TableCell tc6j = new TableCell();
                TableCell tc7j = new TableCell(); TableCell tc8j = new TableCell();
                TableCell tc9j = new TableCell();

                List<JobRefferals> jobRefferalsList = jobRefferalsController.GetAllJobRefferalsByBene(bene);

                if (jobRefferalsList.Count != 0)
                {
                    tc1j.Text = jobRefferalsList[0].JobRefferalsId.ToString();
                    if (jobRefferalsList[0].VacancyRegistrationId != 0)
                    {
                        tc2j.Text = jobRefferalsList[0].companyVecansyRegistationDetails.CompanyName;
                        tc4j.Text = jobRefferalsList[0].companyVecansyRegistationDetails.JobPosition;
                    }
                    else { tc2j.Text = ""; tc4j.Text = ""; }
                    if (jobRefferalsList[0].JobCategoryId != 0)
                    {
                        tc3j.Text = jobRefferalsList[0].JobCategory.Title;
                    }
                    else { tc3j.Text = ""; }

                    tc5j.Text = jobRefferalsList[0].CareerGuidance;
                    tc6j.Text = jobRefferalsList[0].RefferalRemarks;
                    tc7j.Text = jobRefferalsList[0].RefferalsDate.ToString("yyyy-MM-dd");
                    tc8j.Text = jobRefferalsList[0].JobPlacementDate.ToString("yyyy-MM-dd");
                    if (jobRefferalsList[0].ProgramPlanId != 0)
                    {
                        tc9j.Text = jobRefferalsList[0].ProgramPlan.ProgramName;
                    }
                    else { tc9j.Text = ""; }
                }
                else
                {
                    tc1j.Text = ""; tc2j.Text = "";
                    tc3j.Text = ""; tc4j.Text = "";
                    tc5j.Text = ""; tc6j.Text = "";
                    tc7j.Text = ""; tc8j.Text = "";
                    tc9j.Text = "";
                }
                tr.Cells.Add(tc1j); tr.Cells.Add(tc2j);
                tr.Cells.Add(tc3j); tr.Cells.Add(tc4j);
                tr.Cells.Add(tc5j); tr.Cells.Add(tc6j);
                tr.Cells.Add(tc7j); tr.Cells.Add(tc8j);
                tr.Cells.Add(tc9j);

                //---------------------------------------------------------------------------------------------------------

                tblBene.Rows.Add(tr);


                //-------------------------------- Add Next Data -----------------------------------------------------------

                for (int i = 1; i < max; i++)
                {
                    TableRow trn = new TableRow();

                    TableCell tc1n = new TableCell(); TableCell tc2n = new TableCell();
                    TableCell tc3n = new TableCell(); TableCell tc4n = new TableCell();
                    TableCell tc5n = new TableCell(); TableCell tc6n = new TableCell();
                    TableCell tc7n = new TableCell(); TableCell tc8n = new TableCell();
                    TableCell tc9n = new TableCell(); TableCell tc10n = new TableCell();
                    TableCell tc11n = new TableCell(); TableCell tc12n = new TableCell();
                    TableCell tc13n = new TableCell(); TableCell tc14n = new TableCell();
                    TableCell tc15n = new TableCell();
                    trn.Cells.Add(tc1n); trn.Cells.Add(tc2n);
                    trn.Cells.Add(tc3n); trn.Cells.Add(tc4n);
                    trn.Cells.Add(tc5n); trn.Cells.Add(tc6n);
                    trn.Cells.Add(tc7n); trn.Cells.Add(tc8n);
                    trn.Cells.Add(tc9n); trn.Cells.Add(tc10n);
                    trn.Cells.Add(tc11n); trn.Cells.Add(tc12n);
                    trn.Cells.Add(tc13n); trn.Cells.Add(tc14n);
                    trn.Cells.Add(tc15n);


                    //-------------------------------- Add Repeate Career Key -------------------------------------------
                    TableCell tc1in = new TableCell(); TableCell tc2in = new TableCell();
                    TableCell tc3in = new TableCell(); TableCell tc4in = new TableCell();
                    TableCell tc5in = new TableCell(); TableCell tc6in = new TableCell();
                    TableCell tc7in = new TableCell(); TableCell tc8in = new TableCell();
                    TableCell tc9in = new TableCell(); TableCell tc10in = new TableCell();

                    if (CareerKeyTestResultsList.Count > i)
                    {
                        tc1in.Text = CareerKeyTestResultsList[i].Id.ToString();
                        tc2in.Text = CareerKeyTestResultsList[i].R.ToString();
                        tc3in.Text = CareerKeyTestResultsList[i].I.ToString();
                        tc4in.Text = CareerKeyTestResultsList[i].A.ToString();
                        tc5in.Text = CareerKeyTestResultsList[i].S.ToString();
                        tc6in.Text = CareerKeyTestResultsList[i].E.ToString();
                        tc7in.Text = CareerKeyTestResultsList[i].C.ToString();
                        tc8in.Text = CareerKeyTestResultsList[i].Guidence;
                        tc9in.Text = CareerKeyTestResultsList[i].HeldDate.ToString("yyyy-MM-dd");
                        if (CareerKeyTestResultsList[i].Program_Plan_Id != 0)
                        {
                            tc10in.Text = CareerKeyTestResultsList[i].ProgramPlan.ProgramName;
                        }
                        else
                        {
                            tc10in.Text = "";
                        }
                    }
                    else
                    {
                        tc1in.Text = ""; tc2in.Text = "";
                        tc3in.Text = ""; tc4in.Text = "";
                        tc5in.Text = ""; tc6in.Text = "";
                        tc7in.Text = ""; tc8in.Text = "";
                        tc9in.Text = ""; tc10in.Text = "";
                    }
                    trn.Cells.Add(tc1in); trn.Cells.Add(tc2in);
                    trn.Cells.Add(tc3in); trn.Cells.Add(tc4in);
                    trn.Cells.Add(tc5in); trn.Cells.Add(tc6in);
                    trn.Cells.Add(tc7in); trn.Cells.Add(tc8in);
                    trn.Cells.Add(tc9in); trn.Cells.Add(tc10in);
                    //---------------------------------------------------------------------------------------------------

                    //-------------------------------- Add Repeate Training Ref -----------------------------------------
                    TableCell tc1tn = new TableCell(); TableCell tc2tn = new TableCell();
                    TableCell tc3tn = new TableCell(); TableCell tc4tn = new TableCell();
                    TableCell tc5tn = new TableCell(); TableCell tc6tn = new TableCell();

                    if (trainingRefferalsList.Count > i)
                    {
                        tc1tn.Text = trainingRefferalsList[i].Id.ToString();
                        tc2tn.Text = trainingRefferalsList[i].InstituteName;
                        tc3tn.Text = trainingRefferalsList[i].TrainingCourse;
                        tc4tn.Text = trainingRefferalsList[i].ContactPerson;
                        tc5tn.Text = trainingRefferalsList[i].RefferalsDate.ToString("yyyy-MM-dd");
                        if (trainingRefferalsList[i].Program_Plan_Id != 0)
                        {
                            tc6tn.Text = trainingRefferalsList[i].ProgramPlan.ProgramName;
                        }
                        else
                        {
                            tc6tn.Text = "";
                        }
                    }
                    else
                    {
                        tc1tn.Text = ""; tc2tn.Text = "";
                        tc3tn.Text = ""; tc4tn.Text = "";
                        tc5tn.Text = ""; tc6tn.Text = "";
                    }
                    trn.Cells.Add(tc1tn); trn.Cells.Add(tc2tn);
                    trn.Cells.Add(tc3tn); trn.Cells.Add(tc4tn);
                    trn.Cells.Add(tc5tn); trn.Cells.Add(tc6tn);
                    //---------------------------------------------------------------------------------------------------

                    //-------------------------------- Add Repeate Job Ref ---------------------------------------------
                    TableCell tc1jn = new TableCell(); TableCell tc2jn = new TableCell();
                    TableCell tc3jn = new TableCell(); TableCell tc4jn = new TableCell();
                    TableCell tc5jn = new TableCell(); TableCell tc6jn = new TableCell();
                    TableCell tc7jn = new TableCell(); TableCell tc8jn = new TableCell();
                    TableCell tc9jn = new TableCell();

                    if (jobRefferalsList.Count > i)
                    {
                        tc1jn.Text = jobRefferalsList[i].JobRefferalsId.ToString();
                        if (jobRefferalsList[i].VacancyRegistrationId != 0)
                        {
                            tc2jn.Text = jobRefferalsList[i].companyVecansyRegistationDetails.CompanyName;
                            tc4jn.Text = jobRefferalsList[i].companyVecansyRegistationDetails.JobPosition;
                        }
                        else { tc2jn.Text = ""; tc4jn.Text = ""; }
                        if (jobRefferalsList[i].JobCategoryId != 0)
                        {
                            tc3jn.Text = jobRefferalsList[i].JobCategory.Title;
                        }
                        else { tc3jn.Text = ""; }

                        tc5jn.Text = jobRefferalsList[i].CareerGuidance;
                        tc6jn.Text = jobRefferalsList[i].RefferalRemarks;
                        tc7jn.Text = jobRefferalsList[i].RefferalsDate.ToString("yyyy-MM-dd");
                        tc8jn.Text = jobRefferalsList[i].JobPlacementDate.ToString("yyyy-MM-dd");
                        if (jobRefferalsList[i].ProgramPlanId != 0)
                        {
                            tc9jn.Text = jobRefferalsList[i].ProgramPlan.ProgramName;
                        }
                        else { tc9jn.Text = ""; }
                    }
                    else
                    {
                        tc1jn.Text = ""; tc2jn.Text = "";
                        tc3jn.Text = ""; tc4jn.Text = "";
                        tc5jn.Text = ""; tc6jn.Text = "";
                        tc7jn.Text = ""; tc8jn.Text = "";
                        tc9jn.Text = "";
                    }
                    trn.Cells.Add(tc1jn); trn.Cells.Add(tc2jn);
                    trn.Cells.Add(tc3jn); trn.Cells.Add(tc4jn);
                    trn.Cells.Add(tc5jn); trn.Cells.Add(tc6jn);
                    trn.Cells.Add(tc7jn); trn.Cells.Add(tc8jn);
                    trn.Cells.Add(tc9jn);

                    tblBene.Rows.Add(trn);
                }

                //---------------------------------------------------------------------------------------------------------
            }

        }

        private int getmax(int num1, int num2, int num3)
        {
            if (num1 >= num2)
            {
                if (num1 >= num3) { return num1; }
                else { return num3; }
            }
            else
            {
                if (num2 >= num3) { return num2; }
                else { return num3; }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            InduvidualBeneficiaryController bc = ControllerFactory.CreateInduvidualBeneficiaryController();
            beneficiaries = bc.GetAllInduvidualBeneficiary(true);

            if (dob.Text != "" && ddlGen.SelectedValue == "" && ddlScl.SelectedValue == "")
            {
                beneficiariesFinalList = beneficiaries.Where(u => u.DateOfBirth.Date == Convert.ToDateTime(dob.Text).Date).ToList();
                GridView1.DataSource = beneficiariesFinalList;
                GridView1.DataBind();
            }

            //----------------------------------------

            else if (dob.Text == "" && ddlGen.SelectedValue != "" && ddlScl.SelectedValue == "")
            {
                beneficiariesFinalList = beneficiaries.Where(u => u.BeneficiaryGender == ddlGen.SelectedValue).ToList();
                GridView1.DataSource = beneficiariesFinalList;
                GridView1.DataBind();
            }

            //-----------------------------------------

            else if (dob.Text == "" && ddlGen.SelectedValue == "" && ddlScl.SelectedValue != "")
            {
                if (ddlScl.SelectedValue.ToLower() == "school")
                {
                    beneficiariesFinalList = beneficiaries.Where(u => u.IsSchoolStudent == 1).ToList();
                    GridView1.DataSource = beneficiariesFinalList;
                }
                else if (ddlScl.SelectedValue.ToLower() == "non school")
                {
                    beneficiariesFinalList = beneficiaries.Where(u => u.IsSchoolStudent == 0).ToList();
                    GridView1.DataSource = beneficiariesFinalList;
                }

                GridView1.DataBind();
            }

            //------------------------------------------

            else if (dob.Text != "" && ddlGen.SelectedValue != "" && ddlScl.SelectedValue == "")
            {
                beneficiariesFinalList = beneficiaries.Where(u => u.DateOfBirth.Date == Convert.ToDateTime(dob.Text).Date && u.BeneficiaryGender == ddlGen.SelectedValue).ToList();
                GridView1.DataSource = beneficiariesFinalList;
                GridView1.DataBind();
            }

            //-------------------------------------------

            else if (dob.Text != "" && ddlGen.SelectedValue == "" && ddlScl.SelectedValue != "")
            {
                if (ddlScl.SelectedValue.ToLower() == "school")
                {
                    beneficiariesFinalList = beneficiaries.Where(u => u.IsSchoolStudent == 1 && u.DateOfBirth.Date == Convert.ToDateTime(dob.Text).Date).ToList();
                    GridView1.DataSource = beneficiariesFinalList;
                }
                else if (ddlScl.SelectedValue.ToLower() == "non school")
                {
                    beneficiariesFinalList = beneficiaries.Where(u => u.IsSchoolStudent == 0 && u.DateOfBirth.Date == Convert.ToDateTime(dob.Text).Date).ToList();
                    GridView1.DataSource = beneficiariesFinalList;
                }
                GridView1.DataBind();
            }

            //---------------------------------------------

            else if (dob.Text == "" && ddlGen.SelectedValue != "" && ddlScl.SelectedValue != "")
            {
                if (ddlScl.SelectedValue.ToLower() == "school")
                {
                    beneficiariesFinalList = beneficiaries.Where(u => u.IsSchoolStudent == 1 && u.BeneficiaryGender == ddlGen.SelectedValue).ToList();
                    GridView1.DataSource = beneficiariesFinalList;
                }
                else if (ddlScl.SelectedValue.ToLower() == "non school")
                {
                    beneficiariesFinalList = beneficiaries.Where(u => u.IsSchoolStudent == 0 && u.BeneficiaryGender == ddlGen.SelectedValue).ToList();
                    GridView1.DataSource = beneficiariesFinalList;
                }
                GridView1.DataBind();
            }

            //---------------------------------------------

            else if (dob.Text != "" && ddlGen.SelectedValue != "" && ddlScl.SelectedValue != "")
            {
                if (ddlScl.SelectedValue.ToLower() == "school")
                {
                    beneficiariesFinalList = beneficiaries.Where(u => u.IsSchoolStudent == 1 && u.DateOfBirth.Date == Convert.ToDateTime(dob.Text).Date && u.BeneficiaryGender == ddlGen.SelectedValue).ToList();
                    GridView1.DataSource = beneficiariesFinalList;
                }
                else if (ddlScl.SelectedValue.ToLower() == "non school")
                {
                    beneficiariesFinalList = beneficiaries.Where(u => u.IsSchoolStudent == 0 && u.DateOfBirth.Date == Convert.ToDateTime(dob.Text).Date && u.BeneficiaryGender == ddlGen.SelectedValue).ToList();
                    GridView1.DataSource = beneficiariesFinalList;
                }
                GridView1.DataBind();
            }

            if (beneficiariesFinalList.Count > 0)
            {
                btnRun.Visible = true;
            }
        }


        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (beneficiaries.Count > 0 || beneficiariesFinalList.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = "";
                string FileName = "Individual Beneficiary List" + DateTime.Now + ".xls";
                StringWriter strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                tblBene.GridLines = GridLines.Both;
                tblBene.RenderControl(htmltextwrtter);
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