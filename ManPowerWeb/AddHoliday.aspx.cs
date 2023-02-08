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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            HolidaySheetController holidaySheetController = ControllerFactory.CreateHolidaySheetController();
            HolidaySheet holidaySheet = new HolidaySheet();

            holidaySheet.Description = txtDescription.Text;
            holidaySheet.HolidayDate = Convert.ToDateTime(txtDate.Text);

            holidaySheetController.save(holidaySheet);
        }
    }
}