using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Queries.NormalBuy.GetColors
{
    public class ColorDto
    {
        public int Id { get; set; }
        public string Img { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool IsSoldOut { get; set; }
    }
}
