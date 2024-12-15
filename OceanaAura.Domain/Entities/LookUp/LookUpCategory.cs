using OceanaAura.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Domain.Entities.LookUp
{
    public class LookUpCategory : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryId { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Description { get; set; }
        public ICollection<LookUpEntity> lookUps { get; set; }
    }
}
