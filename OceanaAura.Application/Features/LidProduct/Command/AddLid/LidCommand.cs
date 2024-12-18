using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LidProduct.Command.AddLid
{
    public class LidCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> ImageUrls { get; set; }  // List of image URLs
        public decimal PriceJOR { get; set; }
        public decimal PriceUAE { get; set; }
        public decimal PriceUSD { get; set; }
    }
}
