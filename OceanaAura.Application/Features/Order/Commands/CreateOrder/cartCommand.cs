using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Order.Commands.CreateOrder
{
    public class cartCommand
    {
        public int PaymentId { get; set; }

        //  منتج البيع القالب 
        public int Quantity { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int ProductId { get; set; }
        public int LidId { get; set; }
        public string LidName { get; set; }
        public decimal LidPrice { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal Shipping { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
