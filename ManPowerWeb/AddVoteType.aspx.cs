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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            VoteTypeController voteTypeController = ControllerFactory.CreateVoteTypeController();

            VoteType voteType = new VoteType();
            voteType.Deatils = txtVoteDetails.Text;
            voteTypeController.Save(voteType);

            Clear();

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
    }
}