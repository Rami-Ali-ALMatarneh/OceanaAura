using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Features.ContactUs.Commands.DeleteContactUs;
using OceanaAura.Application.Features.ProductColor.Commands.DeleteColor;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Commands.DeleteCategory
{
    public class DeleteCotagoryCommandHandler : IRequestHandler<DeleteCategoryCommad, Unit>
    {

        private readonly IAppLogger<DeleteCotagoryCommandHandler> _appLogger;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCotagoryCommandHandler(IAppLogger<DeleteCotagoryCommandHandler> appLogger, IUnitOfWork unitOfWork)
        {
            _appLogger = appLogger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCategoryCommad request, CancellationToken cancellationToken)
        {
            //validation request data
            var lookUp = await _unitOfWork.GenericRepository<LookUpEntity>().GetByIdAsync(request.Id);
            //verify that record exists
            if (lookUp == null)
            {
                _appLogger.LogWarning("Validation errors in Delete request {0} - {1}", nameof(lookUp), request.Id);
                throw new NotFoundException("Invalid to Delete Category,Product Category is Not Found!");
            }
            // add to database
            _unitOfWork.GenericRepository<LookUpEntity>().Remove(lookUp);
            await _unitOfWork.CompleteSaveAppDbAsync();
            //return record Id
            return Unit.Value;
        }
    }
}
