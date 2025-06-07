using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Features.BottleImg.Command.DeleteBottleImg;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.BottleImg.Command.DeleteAllBottleImg
{
    public class DeleteAllBottleHandler : IRequestHandler<DeleteAllBottleImg, Unit>
    {
        private readonly IAppLogger<DeleteAllBottleHandler> _appLogger;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteAllBottleHandler(IAppLogger<DeleteAllBottleHandler> appLogger, IUnitOfWork unitOfWork)
        {
            _appLogger = appLogger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteAllBottleImg request, CancellationToken cancellationToken)
        {
            var BottleImgs = await _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.BottleImg>().GetAllAsync();
            //verify that record exists
            if (BottleImgs == null)
            {
                _appLogger.LogWarning("Validation errors in Delete BottleImgs");
                throw new NotFoundException("Invalid to Delete order,BottleImgs is Not Found!");
            }
            // add to database            
            _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.BottleImg>().ReomveRange(BottleImgs.ToList());
            await _unitOfWork.CompleteSaveAppDbAsync();
            //return record Id
            return Unit.Value;
        }
    }
}
