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
    public class Cart 
    {
        [Key]
        public int CartId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }

        public int PaymentId { get; set; }

        //  منتج البيع القالب 
        public int Quantity { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int? LidId { get; set; }
        public string LidName { get; set; }
        public decimal LidPrice { get; set; } = 0;
        public decimal ProductPrice { get; set; }
        public decimal Shipping { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsCustomize { get; set; } = false;
        public string? FontFamily { get; set; }
        public string? Text { get; set; }
        public decimal? CustomizationFees { get; set; }
    }
}
