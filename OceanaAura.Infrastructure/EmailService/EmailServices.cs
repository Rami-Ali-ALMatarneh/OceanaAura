//using Microsoft.Extensions.Options;
//using MimeKit;
//using OceanaAura.Application.Contracts.Email;
//using OceanaAura.Application.Models.Email;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Mail;
//using System.Text;
//using System.Threading.Tasks;

//namespace OceanaAura.Infrastructure.EmailService
//{
//    public class EmailServices : IEmailService
//    {
//        private readonly EmailSettings _emailSettings;
//        public EmailServices(IOptions<EmailSettings> emailSettings)
//        {
//            _emailSettings = emailSettings.Value;
//        }
//        public Task SendEmailAsync(EmailMessage emailMessage)
//        {
//            var client = new SmtpClient(_emailSettings.Host, _emailSettings.Port)
//            {
//                EnableSsl = true,
//                UseDefaultCredentials = false,
//                Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password) //this is the correct App Password
//            };

//            var mailMessage = new MailMessage
//            {
//                From = new MailAddress(_emailSettings.Email,_emailSettings.DisplayName),
//                Subject = emailMessage.Subject,
//                Body = emailMessage.Body,
//                IsBodyHtml = true

//            };
//            mailMessage.To.Add(emailMessage.To);
//            // Add attachments if any
//            if (emailMessage.Attachments != null && emailMessage.Attachments.Any())
//            {
//                foreach (var attachment in emailMessage.Attachments)
//                {
//                    var mailAttachment = new Attachment(
//                        new System.IO.MemoryStream(attachment.Content),
//                        attachment.FileName,
//                        attachment.ContentType
//                    );
//                    mailMessage.Attachments.Add(mailAttachment);
//                }
//            }

//            return client.SendMailAsync(mailMessage);
//        }
//    }
//}

using Microsoft.Extensions.Options;
using OceanaAura.Application.Contracts.Email;
using OceanaAura.Application.Models.Email;
using System.Net;
using System.Net.Mail;
namespace EcommerceOnion.Application.Services
{
    public class EmailServices : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        public EmailServices(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public void SendEmail(EmailMessage emailMessage)
        {
            var smtpClient = new SmtpClient(_emailSettings.Host)
            {
                Port = _emailSettings.Port, 
                Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password),
                EnableSsl = _emailSettings.EnableSsl,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.Email),
                Subject = emailMessage.Subject,
                Body = emailMessage.Body,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(emailMessage.To);

            // Add PDF attachments
            foreach (var attachment in emailMessage.Attachments)
                {
                    var stream = new MemoryStream(attachment.Content);
                    var mailAttachment = new Attachment(stream, attachment.FileName, attachment.ContentType);
                    mailMessage.Attachments.Add(mailAttachment);
                }
            
            smtpClient.Send(mailMessage);
        }
        public void SendOTP(EmailMessage emailMessage)
        {
            var smtpClient = new SmtpClient("mail.oceanaaura.com")
            {
                Port = _emailSettings.Port,
                Credentials = new NetworkCredential("info@oceanaaura.com", "OceanaAura259257@"),
                EnableSsl = _emailSettings.EnableSsl,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("info@oceanaaura.com"),
                Subject = emailMessage.Subject,
                Body = emailMessage.Body,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(emailMessage.To);
            smtpClient.Send(mailMessage);
        }

        /***********************/
        //public void SendEmail()
        //{
        //    var smtpClient = new SmtpClient("mail.oceanaaura.com")
        //    {
        //        Port = 8889, // or 8889
        //        Credentials = new NetworkCredential("info@oceanaaura.com", "OceanaAura259257@"),
        //        EnableSsl = false, // true if using port 465
        //    };

        //    var mailMessage = new MailMessage
        //    {
        //        From = new MailAddress("info@oceanaaura.com"),
        //        Subject = "Subject",
        //        Body = "Email body",
        //        IsBodyHtml = true,
        //    };
        //    mailMessage.To.Add("opscode59@gmail.com");

        //    smtpClient.Send(mailMessage);
        //}
    }
}