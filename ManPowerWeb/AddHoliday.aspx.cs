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
    public partial class AddHoliday : System.Web.UI.Page
    {
        List<HolidaySheet> holidaySheetsList = new List<HolidaySheet>();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                BindDataSource();
                lblAddHoliday.Visible = false;
                lblAddHoliday2.Visible = false;
            }
        }

        private void BindDataSource()
        {
            holidaySheetsList = ControllerFactory.CreateHolidaySheetController().getAllHolidays();
            gvHoliday.DataSource = holidaySheetsList;
            gvHoliday.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            HolidaySheetController holidaySheetController = ControllerFactory.CreateHolidaySheetController();
            HolidaySheet holidaySheet = new HolidaySheet();

            holidaySheet.Description = txtDescription.Text;
            holidaySheet.HolidayDate = Convert.ToDateTime(txtDate.Text);

            int response = holidaySheetController.save(holidaySheet);
            if (response != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'You Added Succesfully!', 'success')", true);
                clear();
                lblAddHoliday.Text = "Succesfully Added !";
                lblAddHoliday.Visible = true;
                lblAddHoliday2.Visible = false;
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Failed!', 'Something Went Wrong!', 'error')", true);
                clear();
                lblAddHoliday2.Text = "Something Went Wrong !";
                lblAddHoliday2.Visible = true;
                lblAddHoliday.Visible = false;
            }

        }

        private void clear()
        {
            txtDescription.Text = null;
            txtDate.Text = null;
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            int pagesize = gvHoliday.PageSize;
            int pageindex = gvHoliday.PageIndex;
            rowIndex = (pagesize * pageindex) + rowIndex;


            int id = holidaySheetsList[rowIndex].Id;
        }
    }
}