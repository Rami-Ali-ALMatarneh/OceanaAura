using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Order.Queries.GetOrdersWithStatus
{
    public class GetOrdersWithStatusDto
    {
        public string StatusName { get; set; }
        public int NumberOfOrders { get; set; }
    }
}
