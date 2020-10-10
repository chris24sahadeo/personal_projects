using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
//using System.Net;
//using System.Net.Mail;

namespace sandbox.Logic
{
    public class EmailActions
    {
        public bool SendEmail(string from, string password, string to, string subject, string body)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress(from);
            mail.Subject = subject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = body;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();
            //Add the Creddentials- use your own email id and password

            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(from, password);

            client.Port = 587; // Gmail works on this port
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; //Gmail works on Server Secured Layer
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                client.Send(mail);
                HttpContext.Current.Response.Write("Notification Sent!");
                return true;
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                HttpContext.Current.Response.Write(errorMessage);
                return false;
            }
        }
    }
}