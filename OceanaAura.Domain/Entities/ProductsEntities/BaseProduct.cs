using OceanaAura.Domain.Common;
using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Domain.Entities.ProductsEntities
{
    public class BaseProduct : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Image> ProductImages { get; set; }
        public decimal PriceJOR { get; set; }
        public decimal PriceUAE { get; set; }
        public decimal PriceUSD { get; set; }
    }
}
