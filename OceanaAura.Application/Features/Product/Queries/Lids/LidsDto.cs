using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Queries.Lids
{
    public class LidsDto
    {
        public int Id { get; set; }
        public string ProductImages { get; set; }
        public string Name { get; set; }
        public decimal? PriceJOR { get; set; }
        public decimal? PriceUAE { get; set; }
        public decimal? PriceUSD { get; set; }
        public bool IsMagneticLid { get; set; }

    }
}
