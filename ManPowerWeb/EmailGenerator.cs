using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace ManPowerWeb
{
    public class EmailGenerator
    {
        public string Sendmail()
        {

            MailAddress to = new MailAddress("charithanjana01@gmail.com");
            MailAddress from = new MailAddress("belltestsmtp@gmail.com");

            MailMessage email = new MailMessage(from, to);
            email.Subject = "Testing out email sending";
            email.Body = "<p>Hello all the way from the land of C#</p>";
            email.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("belltestsmtp@gmail.com", "Pass@123");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(email);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}