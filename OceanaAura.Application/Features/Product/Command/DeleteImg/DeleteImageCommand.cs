using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Command.DeleteImg
{
    public class DeleteImageCommand : IRequest<Unit>
    {
        public string Url { get; set; }
    }
}
