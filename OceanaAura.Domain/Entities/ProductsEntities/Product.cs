using OceanaAura.Domain.Common;
using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Domain.Entities.ProductsEntities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Collection for product images (0 or more)
        public ICollection<Image> ProductImages { get; set; }
        // Prices in different regions
        public decimal? PriceJOR { get; set; }
        public decimal? PriceUAE { get; set; }
        public decimal? PriceUSD { get; set; }


        // Foreign key for category
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public LookUpEntity Category { get; set; }
    }
}
