using MediatR;
using OceanaAura.Application.Features.Invoice.Queries.GetAllInvoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Invoice.Queries.GetInvoices
{
    public record InvoicesQuery : IRequest<List<InvoiceDtos>>;

}
