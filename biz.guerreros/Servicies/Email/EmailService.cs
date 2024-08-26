using biz.guerreros.Models.Email;
using System;
using System.Net;
using System.Net.Mail;

namespace biz.guerreros.Servicies
{
    public class EmailService : IEmailService
    {
        public void SendEmail(Email email)
        {
            try
            {
                new SmtpClient
                {
                    Host = "Smtp.Gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Timeout = 10000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("rodrigo.stps@gmail.com", "$dvs1188")
                    
                }.Send(new MailMessage
                {
                    //From = new MailAddress("no-reply@premier.com", "Premier"),
                    From = new MailAddress("no-reply@techo.org", "GuerrerosApp"),
                    To = { email.To },
                    Subject = email.Subject,
                    IsBodyHtml = email.IsBodyHtml,
                    Body = email.Body
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
