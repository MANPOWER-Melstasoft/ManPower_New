using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
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

            ViewState["beneficiaries"] = beneficiaries;
            GridView1.DataSource = beneficiaries;
            GridView1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime dateOfBirth = Convert.ToDateTime(dob.Text);
            beneficiaries = (List<InduvidualBeneficiary>)ViewState["beneficiaries"];
            GridView1.DataSource = beneficiaries.Where(u => u.DateOfBirth.Date == dateOfBirth.Date);
            GridView1.DataBind();
        }

        protected void isClicked(object sender, EventArgs e)
        {
            Response.Redirect("IndividualBene.aspx");
        }
    }
}