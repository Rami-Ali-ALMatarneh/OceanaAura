using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Commands.DeleteAdditional
{
    public class DeleteAdditionalCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int LookUpId { get; set; }
    }
}
