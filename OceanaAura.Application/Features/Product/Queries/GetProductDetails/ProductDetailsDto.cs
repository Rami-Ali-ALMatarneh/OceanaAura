using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Queries.GetProductDetails
{
    public class ProductDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Prices in different regions
        public decimal? PriceJOR { get; set; }
        public decimal? PriceUAE { get; set; }
        public decimal? PriceUSD { get; set; }
        public string? Discount { get; set; }
        public List<string> ImageUrls { get; set; }
        public ICollection<Domain.Entities.Image> ProductImages { get; set; }

        public int CategoryId { get; set; }
        public LookUpEntity Category { get; set; }
        public bool IsHide { get; set; }
    }
}
