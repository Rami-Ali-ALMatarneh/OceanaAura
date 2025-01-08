using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.ProductsEntities;
using OceanaAura.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<OrderDto, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateOrderCommandHandler> _appLogger;

        public CreateOrderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<CreateOrderCommandHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<int> Handle(OrderDto request, CancellationToken cancellationToken)
        {
            // Map the OrderDto to the Order entity
            var order = _mapper.Map<OceanaAura.Domain.Entities.Order>(request);
            order.StatusId = (int)LookUpEnums.OrderStatusCategory.Pending;

            // Add the Order to the database
            await _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Order>().AddAsync(order);
            // Map the cart items from the request
            var carts = request.carts?.Select(cartDto => {
                var cart = _mapper.Map<Cart>(cartDto);
                cart.OrderId = order.OrderId;
                return cart;
            }).ToList();
            await _unitOfWork.CompleteSaveAppDbAsync();
            // Return the created Order ID
            return order.OrderId;
        }
    }
}
