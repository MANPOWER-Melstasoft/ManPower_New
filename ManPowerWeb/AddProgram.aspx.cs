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
        static List<Program> programList = new List<Program>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                BindProgramTypeList();
                BindDataSource();
            }
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
            programList = programController.GetAllProgram(true, false, true);
            gvProgram.DataSource = programList;
            gvProgram.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProgram.PageIndex = e.NewPageIndex;
            BindDataSource();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int output;
            ProgramController programController = ControllerFactory.CreateProgramController();
            Program program = new Program();
            program.ProgramName = txtName.Text;
            program.ProgramType = Convert.ToInt32(ddlProgramType.SelectedValue);

            if (btnSubmit.Text == "Update")
            {
                program.ProgramId = Convert.ToInt32(ViewState["prgId"]);
                program.IsActive = 1;
                output = programController.UpdateProgram(program);

                if (output == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Program Updated Succesfully!', 'success')", true);
                    btnSubmit.Text = "Create";
                    Clear();
                    BindDataSource();
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Program Updated Fail!', 'error');", true);
                }
            }
            else
            {
                output = programController.SaveProgram(program);

                if (output == 1)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Program Added Succesfully!', 'success')", true);
                    Clear();
                    BindDataSource();
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Program Added Fail!', 'error');", true);
                }
                //lblSuccessMsg.Text = "Record Updated Successfully!";
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = gvProgram.PageSize;
            int pageindex = gvProgram.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;

            Program program = programList[rowIndex];
            txtName.Text = program.ProgramName;
            ddlProgramType.SelectedIndex = program.ProgramType;

            btnSubmit.Text = "Update";
            ViewState["prgId"] = program.ProgramId;
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = gvProgram.PageSize;
            int pageindex = gvProgram.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;

            Program program = programList[rowIndex];
            int output;
            ProgramController programController = ControllerFactory.CreateProgramController();

            program.IsActive = 0;
            output = programController.UpdateProgram(program);

            if (output == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Program Deleted Succesfully!', 'success')", true);
                BindDataSource();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Program Deleted Fail!', 'error');", true);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            btnSubmit.Text = "Create";
            Clear();
        }

        private void Clear()
        {
            txtName.Text = string.Empty;
            ddlProgramType.SelectedIndex = 0;
        }
    }
}