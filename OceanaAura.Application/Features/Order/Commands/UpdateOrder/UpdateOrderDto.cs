using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Order.Commands.UpdateOrder
{
    public class UpdateOrderDto : IRequest<int>
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
    }
}
