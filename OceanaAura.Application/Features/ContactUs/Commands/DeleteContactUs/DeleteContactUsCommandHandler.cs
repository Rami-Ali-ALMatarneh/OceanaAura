using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ContactUs.Commands.DeleteContactUs
{
    public class DeleteContactUsCommandHandler : IRequestHandler<DeleteContactUsCommand, Unit>
    {

        private readonly IAppLogger<DeleteContactUsCommandHandler> _appLogger;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteContactUsCommandHandler(IAppLogger<DeleteContactUsCommandHandler> appLogger, IUnitOfWork unitOfWork)
        {
            _appLogger = appLogger;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteContactUsCommand request, CancellationToken cancellationToken)
        {

            //validation request data
            var ConatctUs = await _unitOfWork.GenericRepository<Domain.Entities.ContactUs>().GetByIdAsync(request.Id);
            //verify that record exists
            if (ConatctUs == null)
            {
                _appLogger.LogWarning("Validation errors in Delete request {0} - {1}", nameof(ConatctUs), request.Id);
                throw new NotFoundException("Invalid to Delete Contact Us Message,Contact Us is Not Found!");
            }
            // add to database
             _unitOfWork.GenericRepository<Domain.Entities.ContactUs>().Remove(ConatctUs);
            await _unitOfWork.CompleteSaveAppDbAsync();
            //return record Id
            return Unit.Value;
        }
    }
}
