using MediatR;
using OceanaAura.Application.Features.ContactUs.Queries.GetAllContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ContactUs.Queries.GetContactUsWithDetails
{
    public record ContactUsDetailsQuery(int Id) : IRequest<ContactUsDetailsDto>;
}
