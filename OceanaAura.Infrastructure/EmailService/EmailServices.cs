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
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OceanaAura.Application.Contracts.Email;
using OceanaAura.Application.Models.Email;
namespace EcommerceOnion.Application.Services
{
    public class EmailServices : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        public EmailServices(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(EmailMessage message)
        {
            var emailMessage = CreateEmailMessage(message);
            await SendAsync(emailMessage);
        }

        private MimeMessage CreateEmailMessage(EmailMessage message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailSettings.DisplayName, _emailSettings.Email));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = message.Body };

            if (message.Attachments != null && message.Attachments.Any())
            {
                foreach (var attachment in message.Attachments)
                {
                    bodyBuilder.Attachments.Add(attachment.FileName, attachment.Content, ContentType.Parse(attachment.ContentType));
                }
            }

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailSettings.Email, _emailSettings.Password);
                    await client.SendAsync(mailMessage);
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}