using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ProductSize.Queries.GetSizeDetails
{
    public class SizeDetailsDto
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public decimal PriceJor { get; set; }
        public decimal PriceUae { get; set; }
        public decimal PriceUsd { get; set; }
    }
}
