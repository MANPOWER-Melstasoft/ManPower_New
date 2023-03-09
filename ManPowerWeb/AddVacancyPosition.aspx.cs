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
    public partial class AddVacancyPosition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                bindData();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            VacancyPositionController vacancyPositionController = ControllerFactory.CreateVacancyPositionController();

            if (btnSubmit.Text == "Submit")
            {
                VacancyPosition vacancyPosition = new VacancyPosition();
                vacancyPosition.VacancyPositionName = txtPositionName.Text;
                vacancyPosition.VacancyCategory = txtCategory.Text;
                int response = vacancyPositionController.saveVacancyPosition(vacancyPosition);
                if (response != 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', ' Succesfully Added!', 'success');window.setTimeout(function(){window.location='AddVacancyPosition.aspx'},2500);", true); txtPositionName.Text = null;
                    txtPositionName.Text = null;
                    txtCategory.Text = null;

                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something went wrong!', 'error')", true);
                    txtPositionName.Text = null;
                    txtCategory.Text = null;
                }

            }
            else
            {
                int id = Convert.ToInt32(ViewState["Id"]);
                VacancyPosition vacancyPosition = new VacancyPosition();
                vacancyPosition.VacancyPositionName = txtPositionName.Text;
                vacancyPosition.VacancyCategory = txtCategory.Text;
                int response = vacancyPositionController.updateVacancyPosition(id, vacancyPosition);

                if (response != 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Succesfully Updated!', 'success');window.setTimeout(function(){window.location='AddVacancyPosition.aspx'},2500);", true); txtPositionName.Text = null;
                    txtCategory.Text = null;

                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something went wrong!', 'error')", true);
                    txtPositionName.Text = null;
                    txtCategory.Text = null;
                }

                btnSubmit.Text = "Submit";
            }


        }
        private void bindData()
        {
            VacancyPositionController vacancyPositionController = ControllerFactory.CreateVacancyPositionController();
            List<VacancyPosition> vacancyPositionsList = vacancyPositionController.getVacancyPositionList();
            gvVacancyPosition.DataSource = vacancyPositionsList.Where(x => x.IsActive == 1);
            gvVacancyPosition.DataBind();


        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtPositionName.Text = null;
            txtCategory.Text = null;
        }

        protected void lbEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            txtCategory.Text = gvVacancyPosition.Rows[rowIndex].Cells[2].Text;
            txtPositionName.Text = gvVacancyPosition.Rows[rowIndex].Cells[1].Text;

            ViewState["Id"] = gvVacancyPosition.Rows[rowIndex].Cells[0].Text;
            btnSubmit.Text = "Update";

        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            VacancyPositionController vacancyPositionController = ControllerFactory.CreateVacancyPositionController();

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int id = Convert.ToInt32(gvVacancyPosition.Rows[rowIndex].Cells[0].Text);



            int response = vacancyPositionController.deletePosition(id);

            if (response != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Succesfully Deleted!', 'success');window.setTimeout(function(){window.location='AddVacancyPosition.aspx'},2500);", true);

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something went wrong!', 'error')", true);

            }

        }
    }
}