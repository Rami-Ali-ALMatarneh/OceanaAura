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

namespace OceanaAura.Application.Features.LookUp.Commands.DeleteAdditional
{
    public class DeleteAdditionalCommandHandler : IRequestHandler<DeleteAdditionalCommand, Unit>
    {

        private readonly IAppLogger<DeleteAdditionalCommandHandler> _appLogger;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAdditionalCommandHandler(IAppLogger<DeleteAdditionalCommandHandler> appLogger, IUnitOfWork unitOfWork)
        {
            _appLogger = appLogger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteAdditionalCommand request, CancellationToken cancellationToken)
        {
            //validation request data
            var lookUp = await _unitOfWork.GenericRepository<LookUpEntity>().GetByIdAsync(request.LookUpId);
            var AdditionalProduct = await _unitOfWork.GenericRepository<AdditionalProduct>().GetByIdAsync(request.Id);
            //verify that record exists
            if (lookUp == null && AdditionalProduct == null)
            {
                _appLogger.LogWarning("Validation errors in Delete request {0} - {1}", nameof(lookUp), request.Id);
                throw new NotFoundException("Invalid to Delete Additional ProductsAdditional Products is Not Found!");
            }
            // add to database
            _unitOfWork.GenericRepository<AdditionalProduct>().Remove(AdditionalProduct);
            _unitOfWork.GenericRepository<LookUpEntity>().Remove(lookUp);
            await _unitOfWork.CompleteSaveAppDbAsync();
            //return record Id
            return Unit.Value;
        }
    }
}
