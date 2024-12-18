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
    public class AdditionalProduct : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public LookUpEntity AdditionalProducts { get; set; }
        [ForeignKey("AdditionalProducts")]
        public int LookUpId { get; set; }
        public decimal PriceJOR { get; set; }
        public decimal PriceUAE { get; set; }
        public decimal PriceUSD { get; set; }
    }
}
