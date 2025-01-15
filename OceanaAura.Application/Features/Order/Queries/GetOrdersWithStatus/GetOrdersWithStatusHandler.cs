using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.Order.Queries.GetAllOrder;
using OceanaAura.Application.Features.Order.Queries.GetOrders;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Order.Queries.GetOrdersWithStatus
{
    public class GetOrdersWithStatusHandler : IRequestHandler<GetOrdersWithStatusQuery, List<GetOrdersWithStatusDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetOrdersWithStatusHandler> _logger;

        public GetOrdersWithStatusHandler(IMapper mapper,
           IUnitOfWork unitOfWork,
            IAppLogger<GetOrdersWithStatusHandler> logger)
        {
            this._mapper = mapper;
            _unitOfWork = unitOfWork;
            this._logger = logger;
        }

        public async Task<List<GetOrdersWithStatusDto>> Handle(GetOrdersWithStatusQuery request, CancellationToken cancellationToken)
        {
            // Retrieve all orders and statuses from the repositories
            var orders = await _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Order>().GetAllAsync();
            var statuses = await _unitOfWork.lookUpRepository.GetAllStatus();

            // Group orders by StatusId and count the number of orders for each status
            var ordersGroupedByStatus = orders
                .GroupBy(order => order.StatusId)
                .Select(group => new
                {
                    StatusId = group.Key,
                    NumberOfOrders = group.Count()
                })
                .ToList();

            // Map the status IDs to their corresponding status names and create the DTOs
            var result = ordersGroupedByStatus
                .Select(group => new GetOrdersWithStatusDto
                {
                    StatusName = statuses.FirstOrDefault(status => status.LookUpId == group.StatusId)?.NameEn ?? "Unknown",
                    NumberOfOrders = group.NumberOfOrders
                })
                .ToList();

            // Log the result for debugging purposes
            _logger.LogInformation("Retrieved {Count} statuses with orders", result.Count);

            return result;
        }
    }
}
