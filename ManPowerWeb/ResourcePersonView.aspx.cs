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
    public partial class ResourcePersonView : System.Web.UI.Page
    {
        List<ResourcePerson> rp = new List<ResourcePerson>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ResourcePersonController resourcePerson = ControllerFactory.CreateResourcePersonController();

            rp = resourcePerson.GetAllResourcePerson(true);

            string id = Request.QueryString["id"];

            foreach (var i in rp.Where(u => u.ResoursePersonId == int.Parse(id)))
            {
                rptype.Text = i.ResourcePersonType;
                nic.Text = i.NIC;
                name.Text = i.Name;
                desig.Text = i.Designation;
                qalifications.Text = i.Qualifications;
                workPlace.Text = i.WorkPlace;
                address.Text = i.Address;
                contact.Text = i.ContactNumber;
                whatsapp.Text = i.WhatsappNumber;
                email.Text = i.Email;

            }

        }
        protected void isClicked(object sender, EventArgs e)
        {
            Response.Redirect("ResourcePersonRegSearch.aspx");
        }
    }
}