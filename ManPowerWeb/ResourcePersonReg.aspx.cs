using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class ResourcePersonReg : System.Web.UI.Page
    {
        string[] type = { "DME", "External" };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlType.DataSource = type;
                ddlType.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ResourcePersonController rp = ControllerFactory.CreateResourcePersonController();
            ResourcePerson resourcePerson = new ResourcePerson();

            resourcePerson.ResourcePersonType = ddlType.SelectedValue;
            resourcePerson.Name = name.Text;
            resourcePerson.Designation = desig.Text;
            resourcePerson.NIC = nic.Text;
            resourcePerson.WorkPlace = workPlace.Text;
            resourcePerson.Qualifications = qalifications.Text;
            resourcePerson.Address = address.Text;
            resourcePerson.ContactNumber = contact.Text;
            resourcePerson.WhatsappNumber = whatsapp.Text;
            resourcePerson.Email = email.Text;
            resourcePerson.Gender = ddlGender.SelectedValue;

            int result1 = rp.SaveResourcePerson(resourcePerson);

            if (result1 == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Something Went Wrong!', 'error');", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Added Succesfully!', 'success');window.setTimeout(function(){window.location='ResourcePersonReg.aspx'},2500);", true);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

            desig.Text = null;
            nic.Text = null;
            workPlace.Text = null;
            qalifications.Text = null;
            address.Text = null;
            contact.Text = null;
            whatsapp.Text = null;
            email.Text = null;
            name.Text = null;
        }
    }
}