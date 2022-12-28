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
    public partial class AddProgram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProgramTypeList();
                BindDataSource();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ProgramController programController = ControllerFactory.CreateProgramController();

            Program program = new Program();
            program.ProgramName = txtName.Text;
            program.ProgramType = Convert.ToInt32(ddlProgramType.SelectedValue);
            programController.SaveProgram(program);

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
            txtName.Text = string.Empty;
        }

        private void BindProgramTypeList()
        {

            ProgramTypeController programTypeController = ControllerFactory.CreateProgramTypeController();
            List<ProgramType> programTypeList = programTypeController.GetAllProgramType(false);


            ddlProgramType.DataSource = programTypeList;
            ddlProgramType.DataValueField = "ProgramTypeId";
            ddlProgramType.DataTextField = "ProgramTypeName";
            ddlProgramType.DataBind();
            ddlProgramType.Items.Insert(0, new ListItem("-- select program type --", ""));

        }

        private void BindDataSource()
        {
            ProgramController programController = ControllerFactory.CreateProgramController();
            List<Program> programList = programController.GetAllProgram(false, true);
            gvProgram.DataSource = programList;
            gvProgram.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProgram.PageIndex = e.NewPageIndex;
            BindDataSource();

        }
    }
}