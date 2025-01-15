using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.Order.Queries.GetAllOrder;
using OceanaAura.Application.Features.Product.Queries.GetProduct;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Order.Queries.GetOrders
{
    public class OrdersHandler : IRequestHandler<OrdersQuery, List<GetOrdersDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<OrdersHandler> _logger;

        public OrdersHandler(IMapper mapper,
           IUnitOfWork unitOfWork,
            IAppLogger<OrdersHandler> logger)
        {
            this._mapper = mapper;
            _unitOfWork = unitOfWork;
            this._logger = logger;
        }

        public async  Task<List<GetOrdersDto>> Handle(OrdersQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var orders = await _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Order>().GetAllAsync();

            // convert data objects to DTO objects
            var data = _mapper.Map<List<GetOrdersDto>>(orders);

            // return list of DTO object
            _logger.LogInformation("orders is retrieved successfully");
            return data;
        }
    }
}
