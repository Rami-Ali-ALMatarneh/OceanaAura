using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Invoice.Commands.AddInvoice
{
    public class InvoiceCommand : IRequest<int>
    {
        public int OrderId { get; set; }
    }
}
