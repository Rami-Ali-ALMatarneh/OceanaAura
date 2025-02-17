using OceanaAura.Application.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Contracts.Email
{
    public interface IEmailService
    {
        void SendEmail(EmailMessage emailMessage);
        void SendOTP(EmailMessage emailMessage);
    }
}
