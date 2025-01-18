using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ProductColor.Queries.GetAllProductColors
{
    public class ProductColorDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool IsSoldOut { get; set; }
    }
}
