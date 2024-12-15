using MediatR;
using OceanaAura.Application.Features.ContactUs.Queries.GetAllContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ProductColor.Queries.GetAllProductColors
{
    public record ProductColorQuery : IRequest<List<ProductColorDto>>;
}
