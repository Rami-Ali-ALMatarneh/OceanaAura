using MediatR;
using OceanaAura.Application.Features.Product.Queries.GetAllProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Order.Queries.GetAllOrder
{
    public class PaginatedOrdersQuery : IRequest<(List<GetOrdersDto>  getOrdersDtos, int TotalRecords)>
    {
        public int Start { get; set; }
        public int Length { get; set; }
        public string SearchValue { get; set; }
    }
}
