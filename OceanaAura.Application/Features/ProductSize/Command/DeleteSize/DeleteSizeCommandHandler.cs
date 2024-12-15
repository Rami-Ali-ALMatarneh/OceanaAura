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

namespace OceanaAura.Application.Features.ProductSize.Command.DeleteSize
{
    public class DeleteSizeCommandHandler : IRequestHandler<DeleteSizeCommand, Unit>
    {
        private readonly IAppLogger<DeleteSizeCommandHandler> _appLogger;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSizeCommandHandler(IAppLogger<DeleteSizeCommandHandler> appLogger, IUnitOfWork unitOfWork)
        {
            _appLogger = appLogger;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteSizeCommand request, CancellationToken cancellationToken)
        {
            //validation request data
            var Color = await _unitOfWork.GenericRepository<LookUpEntity>().GetByIdAsync(request.Id);
            //verify that record exists
            if (Color == null)
            {
                _appLogger.LogWarning("Validation errors in Delete request {0} - {1}", nameof(Color), request.Id);
                throw new NotFoundException("Invalid to Delete Size Product Message,Size Product is Not Found!");
            }
            // add to database
            _unitOfWork.GenericRepository<LookUpEntity>().Remove(Color);
            await _unitOfWork.CompleteSaveAppDbAsync();
            return Unit.Value;
        }
    }
}
