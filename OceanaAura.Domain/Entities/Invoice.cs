using OceanaAura.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        [Key]
        public int InvoiceId { get; set; }
        
    }
}
