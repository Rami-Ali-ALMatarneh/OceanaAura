using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Features.ProductColor.Commands.DeleteColor;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Order.Commands.UpdateOrder
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderDto, int>
    {
        private readonly IAppLogger<UpdateOrderHandler> _appLogger;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderHandler(IAppLogger<UpdateOrderHandler> appLogger, IUnitOfWork unitOfWork)
        {
            _appLogger = appLogger;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(UpdateOrderDto request, CancellationToken cancellationToken)
        {
            //validation request data
            var order = await _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Order>().GetByIdAsync(request.Id);
            //verify that record exists
            if (order == null)
            {
                _appLogger.LogWarning("Validation errors in Delete request {0} - {1}", nameof(order), request.Id);
                throw new NotFoundException("Invalid to  Delete Size Product Message, Delete Size Product is Not Found!");
            }
            order.StatusId = request.StatusId;
            // add to database
            _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Order>().Update(order);
            await _unitOfWork.CompleteSaveAppDbAsync();
            //return record Id
            return order.OrderId;
        }

        
    }
}
