using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Domain.Entities
{
    public class BottleImg
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int LidId { get; set; }

    }
}
