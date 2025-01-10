using OceanaAura.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Domain.Entities
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime CreateOn { get; set; } = DateTime.Now;
    }
}
