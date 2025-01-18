using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Queries.GetAllProduct
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEnCategory { get; set; }

        public string NameArCategory { get; set; }

        public string Description { get; set; }

        // Prices in different regions
        public decimal? PriceJOR { get; set; }
        public decimal? PriceUAE { get; set; }
        public decimal? PriceUSD { get; set; }
        public string? Discount { get; set; }
        public List<string> ImageUrls { get; set; }
        public string CreatedOn { get; set; }
        public string? ModifyOn { get; set; } = "N/A";
        public int CategoryId { get; set; }
        public LookUpEntity Category { get; set; }
        public bool IsMagneticLid { get; set; }

    }
}
