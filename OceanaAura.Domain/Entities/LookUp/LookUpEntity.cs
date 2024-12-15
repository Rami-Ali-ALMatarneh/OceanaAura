using OceanaAura.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Domain.Entities.LookUp
{
    public class LookUpEntity : BaseEntity
    {
        [Key]
        public int LookUpId { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string? Details { get; set; }
        public LookUpCategory LookupCategory { get; set; }
        public int LookupCategoryId { get; set; }
    }
}
