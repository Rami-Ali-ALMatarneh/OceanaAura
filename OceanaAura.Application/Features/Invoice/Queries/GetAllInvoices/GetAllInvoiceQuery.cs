using MediatR;
using OceanaAura.Application.Features.Order.Queries.GetAllOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Invoice.Queries.GetAllInvoices
{
    public record GetAllInvoiceQuery : IRequest<List<InvoiceDetailsDto>>;

}
