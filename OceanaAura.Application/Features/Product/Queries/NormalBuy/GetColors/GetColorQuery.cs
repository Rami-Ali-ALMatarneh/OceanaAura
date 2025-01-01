using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Queries.NormalBuy.GetColors
{
    public record GetColorQuery : IRequest<List<ColorDto>>;
}
