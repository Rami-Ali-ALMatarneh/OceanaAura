using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Queries.GetProduct
{
    public class ProductHomeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> ImgUrl { get; set; }
        public string Description { get; set; }
        public bool IsHide { get; set; }
        public int CategoryId { get; set; }
    }
}
