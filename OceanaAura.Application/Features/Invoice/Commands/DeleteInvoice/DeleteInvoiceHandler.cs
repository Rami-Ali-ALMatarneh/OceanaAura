using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Features.Order.Commands.DeleteOrder;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Invoice.Commands.DeleteInvoice
{
    public class DeleteInvoiceHandler : IRequestHandler<DeleteInvoiceCommand, Unit>
    {

        private readonly IAppLogger<DeleteInvoiceHandler> _appLogger;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteInvoiceHandler(IAppLogger<DeleteInvoiceHandler> appLogger, IUnitOfWork unitOfWork)
        {
            _appLogger = appLogger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            //validation request data
            var Invoice = await _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Invoice>().GetByIdAsync(request.Id);
            //verify that record exists
            if (Invoice == null)
            {
                _appLogger.LogWarning("Validation errors in Delete request {0} - {1}", nameof(Invoice), request.Id);
                throw new NotFoundException("Invalid to Delete Invoice and Order,Product order is Not Found!");
            }
            
            // add to database            
            var cart = await _unitOfWork.cartRepository.GetCartWithOrderId(Invoice.OrderId);
            var order = await _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Order>().GetByIdAsync(Invoice.OrderId);
            _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Cart>().Remove(cart);
            _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Order>().Remove(order);
            _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Invoice>().Remove(Invoice);
            await _unitOfWork.CompleteSaveAppDbAsync();
            //return record Id
            return Unit.Value;
        }
    }
}
