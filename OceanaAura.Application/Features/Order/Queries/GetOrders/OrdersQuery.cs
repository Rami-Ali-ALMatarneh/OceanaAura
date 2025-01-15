using MediatR;
using OceanaAura.Application.Features.Order.Queries.GetAllOrder;
using OceanaAura.Application.Features.Product.Queries.GetProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Order.Queries.GetOrders
{
    public record OrdersQuery : IRequest<List<GetOrdersDto>>;

}
