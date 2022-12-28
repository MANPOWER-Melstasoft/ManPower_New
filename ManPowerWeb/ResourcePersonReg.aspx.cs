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

            int result1 = rp.SaveResourcePerson(resourcePerson);

            if (result1 == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Something went wrong');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Added Succesfully');", true);
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
            name.Text=null;
        }
    }
}