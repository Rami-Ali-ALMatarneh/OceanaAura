
using OceanaAura.Domain.Common;
using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Domain.Entities
{
    public class ProductSize : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Size")]
        public int SizeId { get; set; }
        public LookUpEntity Size { get; set; }
        public decimal PriceJOR { get; set; }
        public decimal PriceUAE { get; set; }
        public decimal PriceUSD { get; set; }

    }
}
