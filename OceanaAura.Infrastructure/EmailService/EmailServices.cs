using Microsoft.Extensions.Options;
using OceanaAura.Application.Contracts.Email;
using OceanaAura.Application.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Infrastructure.EmailService
{
    public class EmailServices : IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public EmailServices(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public Task SendEmailAsync(EmailMessage emailMessage)
        {
            var client = new SmtpClient(_emailSettings.Host, _emailSettings.Port)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password) //this is the correct App Password
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.Email,_emailSettings.DisplayName),
                Subject = emailMessage.Subject,
                Body = emailMessage.Body,
                IsBodyHtml = true, // Allow HTML content if needed

            };
            mailMessage.To.Add(emailMessage.To);

            return client.SendMailAsync(mailMessage);
        }
    }
}
