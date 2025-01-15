using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Invoice.Queries.GetInvoices
{
    public class InvoiceDtos
    {
        public int InvoiceId { get; set; }
        public int OrderId { get; set; }
        public DateTime CreateOn { get; set; } 
    }
}
