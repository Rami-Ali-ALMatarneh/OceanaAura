using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Command.EditProduct
{
    public class EditProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> ImageUrls { get; set; }
        public decimal? PriceJOR { get; set; }
        public decimal? PriceUAE { get; set; }
        public decimal? PriceUSD { get; set; }
        public int? Discount { get; set; } = 0;
        public int CategoryId { get; set; }
        public bool IsHide { get; set; }

    }
}
