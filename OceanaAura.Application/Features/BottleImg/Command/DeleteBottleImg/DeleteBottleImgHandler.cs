using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Features.Feedback.Command.DeleteFeedback;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.BottleImg.Command.DeleteBottleImg
{
    public class DeleteBottleImgHandler : IRequestHandler<DeleteBottleImg, Unit>
    {

        private readonly IAppLogger<DeleteBottleImgHandler> _appLogger;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBottleImgHandler(IAppLogger<DeleteBottleImgHandler> appLogger, IUnitOfWork unitOfWork)
        {
            _appLogger = appLogger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteBottleImg request, CancellationToken cancellationToken)
        {
            var BottleImg = await _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.BottleImg>().GetByIdAsync(request.BottleImgId);
            //verify that record exists
            if (BottleImg == null)
            {
                _appLogger.LogWarning("Validation errors in Delete BottleImg {0} - {1}", nameof(Feedback), request.BottleImgId);
                throw new NotFoundException("Invalid to Delete order,BottleImg is Not Found!");
            }
            // add to database            
            _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.BottleImg>().Remove(BottleImg);
            await _unitOfWork.CompleteSaveAppDbAsync();
            //return record Id
            return Unit.Value;
        }
    }
}
