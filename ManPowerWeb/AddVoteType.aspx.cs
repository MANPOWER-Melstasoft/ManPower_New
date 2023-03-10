using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ManPowerWeb
{
    public partial class AddVoteType : System.Web.UI.Page
    {
        UserPrevilage userPrevilage = new UserPrevilage();
        int functionId = 1048;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (userPrevilage.checkPrevilage(Convert.ToInt32(Session["UserId"]), functionId))
            {
                if (!IsPostBack)
                {
                    BindDataSource();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            VoteTypeController voteTypeController = ControllerFactory.CreateVoteTypeController();

            VoteType voteType = new VoteType();
            voteType.Deatils = txtVoteDetails.Text;
            voteTypeController.Save(voteType);

            Clear();
            BindDataSource();

            lblSuccessMsg.Text = "Record Updated Successfully!";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtVoteDetails.Text = string.Empty;
        }

        private void BindDataSource()
        {
            VoteTypeController voteTypeController = ControllerFactory.CreateVoteTypeController();
            List<VoteType> voteTypeList = voteTypeController.GetAllVoteType(false);
            gvVoteType.DataSource = voteTypeList;
            gvVoteType.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVoteType.PageIndex = e.NewPageIndex;
            BindDataSource();

        }
    }
}