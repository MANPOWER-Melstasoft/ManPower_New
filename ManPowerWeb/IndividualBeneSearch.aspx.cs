using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class IndividualBeneSearch : System.Web.UI.Page
    {
        List<InduvidualBeneficiary> beneficiaries = new List<InduvidualBeneficiary>();
        List<InduvidualBeneficiary> filtered = new List<InduvidualBeneficiary>();
        string[] gen = { "Male", "Female" };
        string[] scl = { "School", "Non School" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataSource();
            }
        }

        private void BindDataSource()
        {
            InduvidualBeneficiaryController bc = ControllerFactory.CreateInduvidualBeneficiaryController();
            beneficiaries = bc.GetAllInduvidualBeneficiary();

            ddlGen.DataSource = gen;
            ddlGen.DataBind();
            ddlGen.Items.Insert(0, new ListItem(""));

            ddlScl.DataSource = scl;
            ddlScl.DataBind();
            ddlScl.Items.Insert(0, new ListItem(""));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            InduvidualBeneficiaryController bc = ControllerFactory.CreateInduvidualBeneficiaryController();
            beneficiaries = bc.GetAllInduvidualBeneficiary();


            if (dob.Text != "" && ddlGen.SelectedValue == "" && ddlScl.SelectedValue == "")
            {
                GridView1.DataSource = beneficiaries.Where(u => u.DateOfBirth.Date == Convert.ToDateTime(dob.Text).Date);
                GridView1.DataBind();
            }

            //----------------------------------------

            else if (dob.Text == "" && ddlGen.SelectedValue != "" && ddlScl.SelectedValue == "")
            {
                GridView1.DataSource = beneficiaries.Where(u => u.BeneficiaryGender == ddlGen.SelectedValue);
                GridView1.DataBind();
            }

            //-----------------------------------------

            else if (dob.Text == "" && ddlGen.SelectedValue == "" && ddlScl.SelectedValue != "")
            {
                if (ddlScl.SelectedValue.ToLower() == "school")
                {
                    GridView1.DataSource = beneficiaries.Where(u => u.IsSchoolStudent == 1);
                }
                else if (ddlScl.SelectedValue.ToLower() == "non school")
                {
                    GridView1.DataSource = beneficiaries.Where(u => u.IsSchoolStudent == 0);
                }

                GridView1.DataBind();
            }

            //------------------------------------------

            else if (dob.Text != "" && ddlGen.SelectedValue != "" && ddlScl.SelectedValue == "")
            {
                GridView1.DataSource = beneficiaries.Where(u => u.DateOfBirth.Date == Convert.ToDateTime(dob.Text).Date && u.BeneficiaryGender == ddlGen.SelectedValue);
                GridView1.DataBind();
            }

            //-------------------------------------------

            else if (dob.Text != "" && ddlGen.SelectedValue == "" && ddlScl.SelectedValue != "")
            {
                if (ddlScl.SelectedValue.ToLower() == "school")
                {
                    GridView1.DataSource = beneficiaries.Where(u => u.IsSchoolStudent == 1 && u.DateOfBirth.Date == Convert.ToDateTime(dob.Text).Date);
                }
                else if (ddlScl.SelectedValue.ToLower() == "non school")
                {
                    GridView1.DataSource = beneficiaries.Where(u => u.IsSchoolStudent == 0 && u.DateOfBirth.Date == Convert.ToDateTime(dob.Text).Date);
                }
                GridView1.DataBind();
            }

            //---------------------------------------------

            else if (dob.Text == "" && ddlGen.SelectedValue != "" && ddlScl.SelectedValue != "")
            {
                if (ddlScl.SelectedValue.ToLower() == "school")
                {
                    GridView1.DataSource = beneficiaries.Where(u => u.IsSchoolStudent == 1 && u.BeneficiaryGender == ddlGen.SelectedValue);
                }
                else if (ddlScl.SelectedValue.ToLower() == "non school")
                {
                    GridView1.DataSource = beneficiaries.Where(u => u.IsSchoolStudent == 0 && u.BeneficiaryGender == ddlGen.SelectedValue);
                }
                GridView1.DataBind();
            }

            //---------------------------------------------

            else if (dob.Text != "" && ddlGen.SelectedValue != "" && ddlScl.SelectedValue != "")
            {
                if (ddlScl.SelectedValue.ToLower() == "school")
                {
                    GridView1.DataSource = beneficiaries.Where(u => u.IsSchoolStudent == 1 && u.DateOfBirth.Date == Convert.ToDateTime(dob.Text).Date && u.BeneficiaryGender == ddlGen.SelectedValue);
                }
                else if (ddlScl.SelectedValue.ToLower() == "non school")
                {
                    GridView1.DataSource = beneficiaries.Where(u => u.IsSchoolStudent == 0 && u.DateOfBirth.Date == Convert.ToDateTime(dob.Text).Date && u.BeneficiaryGender == ddlGen.SelectedValue);
                }
                GridView1.DataBind();
            }
        }

        protected void isClicked(object sender, EventArgs e)
        {
            Response.Redirect("IndividualBene.aspx");
        }


    }
}