using MediatR;
using OceanaAura.Application.Features.Product.Queries.GetAllProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Order.Queries.GetAllOrder
{
    public record GetOrdersQuery : IRequest<List<GetOrdersDto>>;

}
