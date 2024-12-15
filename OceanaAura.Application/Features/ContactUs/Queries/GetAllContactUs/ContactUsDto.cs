using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ContactUs.Queries.GetAllContactUs
{
    public class ContactUsDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string SubmittedAt { get; set; } // Changed to string
    }
}
