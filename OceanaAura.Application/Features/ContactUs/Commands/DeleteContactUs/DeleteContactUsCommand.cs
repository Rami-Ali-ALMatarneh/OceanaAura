using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ContactUs.Commands.DeleteContactUs
{
    public class DeleteContactUsCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
