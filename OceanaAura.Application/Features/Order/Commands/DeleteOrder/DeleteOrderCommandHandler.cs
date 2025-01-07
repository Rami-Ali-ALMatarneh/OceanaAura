using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Features.LookUp.Commands.DeleteCategory;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {

        private readonly IAppLogger<DeleteOrderCommandHandler> _appLogger;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderCommandHandler(IAppLogger<DeleteOrderCommandHandler> appLogger, IUnitOfWork unitOfWork)
        {
            _appLogger = appLogger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            //validation request data
            var order = await _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Order>().GetByIdAsync(request.Id);
            //verify that record exists
            if (order == null)
            {
                _appLogger.LogWarning("Validation errors in Delete request {0} - {1}", nameof(order), request.Id);
                throw new NotFoundException("Invalid to Delete order,Product order is Not Found!");
            }
            // add to database            
            var cart = await _unitOfWork.cartRepository.GetCartWithOrderId(request.Id);
            _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Cart>().Remove(cart);
            _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Order>().Remove(order);

            await _unitOfWork.CompleteSaveAppDbAsync();
            //return record Id
            return Unit.Value;
        }
    }
}
