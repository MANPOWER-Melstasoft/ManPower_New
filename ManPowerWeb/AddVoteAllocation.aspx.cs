using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class AddVoteAllocation : System.Web.UI.Page
    {
        UserPrevilage userPrevilage = new UserPrevilage();
        int functionId = 1047;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (userPrevilage.checkPrevilage(Convert.ToInt32(Session["UserId"]), functionId))
            {
                if (!IsPostBack)
                {
                    BindYearList();
                    BindVoteTypeList();
                    BindDataSource();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            VoteAllocationController voteAllocationController = ControllerFactory.CreateVoteAllocationController();

            DateTime Year = new DateTime(Convert.ToInt32(ddlYear.SelectedValue), 1, 1);
            string VoteNumber = txtVoteNumber.Text;

            if (CheckAvailableVotNum(VoteNumber, voteAllocationController))
            {
                if (CheckAvailable(ddlVoteType.SelectedIndex, Year, voteAllocationController))
                {
                    VoteAllocation voteAllocation = new VoteAllocation();

                    voteAllocation.VoteTypeId = ddlVoteType.SelectedIndex;
                    voteAllocation.Year = Year;
                    voteAllocation.Amount = float.Parse(txtAmount.Text, CultureInfo.InvariantCulture.NumberFormat);
                    voteAllocation.RemainAmount = voteAllocation.Amount;
                    voteAllocation.VoteNumber = VoteNumber;
                    voteAllocation.CreatedBy = Convert.ToInt32(Session["UserId"]);
                    voteAllocation.CreatedDate = DateTime.Now;

                    voteAllocationController.Save(voteAllocation);

                    Clear();
                    BindDataSource();

                    lblErrorMsg.Text = string.Empty;
                    lblSuccessMsg.Text = "Record Updated Successfully!";
                }
            }
        }

        private bool CheckAvailable(int TypeId, DateTime Year, VoteAllocationController v)
        {
            VoteAllocation voteAllocation = v.CheckVoteAllocationExists(TypeId, Year);

            if (voteAllocation.Id == 0)
            {
                lblErrorMsg.Text = string.Empty;
                return true;
            }
            else
            {
                lblSuccessMsg.Text = string.Empty;
                lblErrorMsg.Text = "Vote Allocation Type " + ddlVoteType.SelectedValue + " is Already Exists for Year " + Year.Year + "!";
                return false;
            }
        }

        private bool CheckAvailableVotNum(string Number, VoteAllocationController v)
        {
            VoteAllocation voteAllocation = v.CheckVoteAllocationNumberExists(Number);

            if (voteAllocation.Id == 0)
            {
                lblVotnumError.Text = string.Empty;
                return true;
            }
            else
            {
                lblErrorMsg.Text = string.Empty;
                lblSuccessMsg.Text = string.Empty;
                lblVotnumError.Text = "This Vote Number is Already Exists!";
                return false;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            ddlVoteType.SelectedIndex = 0;
            ddlYear.SelectedIndex = 0;
            txtAmount.Text = string.Empty;
            txtVoteNumber.Text = string.Empty;
        }

        private void BindVoteTypeList()
        {

            VoteTypeController voteTypeController = ControllerFactory.CreateVoteTypeController();
            List<VoteType> voteTypes = voteTypeController.GetAllVoteType(false);


            ddlVoteType.DataSource = voteTypes;
            ddlVoteType.DataValueField = "Id";
            ddlVoteType.DataTextField = "Deatils";
            ddlVoteType.DataBind();
            ddlVoteType.Items.Insert(0, new ListItem("-- select vote type --", ""));

        }

        private void BindYearList()
        {
            int year = DateTime.Now.Year;
            for (int i = year; i <= year + 5; i++)
            {
                ListItem lyearListi = new ListItem(i.ToString());
                ddlYear.Items.Add(lyearListi);
            }

            ddlYear.DataBind();
            ddlYear.Items.Insert(0, new ListItem("-- select year --", ""));

        }

        private void BindDataSource()
        {
            VoteAllocationController voteAllocationController = ControllerFactory.CreateVoteAllocationController();
            List<VoteAllocation> voteAllocationList = voteAllocationController.GetAllVoteAllocation(false);
            gvVoteAllocation.DataSource = voteAllocationList;
            gvVoteAllocation.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVoteAllocation.PageIndex = e.NewPageIndex;
            BindDataSource();

        }
    }
}