using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Queries.GetCategoryWithNumberProduct
{
    public class CategoryWithNumberProductDto
    {
        public string CategoryName { get; set; }
        public int NumberOfProductInCategory { get; set; }
    }
}
