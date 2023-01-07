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
        public void Sendmail()
        {

            MailMessage message = null;//new MailMessage();
            MailAddress fromAddress = new MailAddress("noreply@cilanka.com");
            string toEmailAddress = "test@gmail.com";

            message = new MailMessage();
            message.Subject = "Test";

            if (toEmailAddress.Length > 5)
            {
                message.From = fromAddress;
                message.To.Add(toEmailAddress.Trim());

                //message.CC.Add("roshanu@bellvantage.com");

                message.Body = "Test Email body";

                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;
                //System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential("finance.cill@gmail.com", "ContiFin");
                //System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);

                System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential("stassen.exporters@gmail.com", "uxdgpjvtrvhbsqdk");
                System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                //Google app password
                //uxdgpjvtrvhbsqdk

                mailClient.EnableSsl = true;
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = mailAuthentication;

                try
                {
                    mailClient.Send(message); // send Email

                }

                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}