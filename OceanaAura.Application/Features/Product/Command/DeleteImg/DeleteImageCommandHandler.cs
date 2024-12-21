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

namespace OceanaAura.Application.Features.Product.Command.DeleteImg
{
    public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand, Unit>
    {
        private readonly IAppLogger<DeleteImageCommandHandler> _appLogger;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteImageCommandHandler(IAppLogger<DeleteImageCommandHandler> appLogger, IUnitOfWork unitOfWork)
        {
            _appLogger = appLogger;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            // Build the query with filtering
            var query = _unitOfWork.GenericRepository<Domain.Entities.Image>().Query()
                                    .Where(x => x.ImageUrl == request.Url);

            // Retrieve the first matching image or null if not found
            var image = query.FirstOrDefault();
            //verify that record exists
            if (image == null)
            {
                _appLogger.LogWarning("Validation errors in Delete request {0} - {1}", nameof(image), request.Url);
                throw new NotFoundException("Invalid to  Delete image Product Message, Delete image Product is Not Found!");
            }
            // add to database
            _unitOfWork.GenericRepository<Domain.Entities.Image>().Remove(image);
            await _unitOfWork.CompleteSaveAppDbAsync();
            //return record Id
            return Unit.Value;
        }
    }
}
