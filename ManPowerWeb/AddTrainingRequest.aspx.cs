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
    public partial class AddTrainingRequest : System.Web.UI.Page
    {
        List<Program> programList = new List<Program>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEmployNO();
                BindProgram();
            }
        }

        public void BindEmployNO()
        {

        }

        public void BindProgram()
        {
            ProgramController programControl = ControllerFactory.CreateProgramController();

            programList = programControl.GetAllProgram(false);

            ddlProgram.DataSource = programList;
            ddlProgram.DataValueField = "ProgramId";
            ddlProgram.DataTextField = "ProgramName";
            ddlProgram.DataBind();
        }
    }
}