using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Queries.GetAllPayment
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public decimal PriceJOR { get; set; }
        public decimal PriceUAE { get; set; }
        public decimal PriceUSD { get; set; }
    }
}
