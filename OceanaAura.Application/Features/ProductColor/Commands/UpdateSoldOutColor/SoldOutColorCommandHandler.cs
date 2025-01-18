using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.Order.Commands.UpdateOrder;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OceanaAura.Application.Features.ProductColor.Commands.UpdateSoldOutColor
{
    public class SoldOutColorCommandHandler : IRequestHandler<SoldOutColorCommand, int>
    {
        private readonly IAppLogger<SoldOutColorCommandHandler> _appLogger;
        private readonly IUnitOfWork _unitOfWork;

        public SoldOutColorCommandHandler(IAppLogger<SoldOutColorCommandHandler> appLogger, IUnitOfWork unitOfWork)
        {
            _appLogger = appLogger;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(SoldOutColorCommand request, CancellationToken cancellationToken)
        {
            //validation request data
            var Color = await _unitOfWork.GenericRepository<LookUpEntity>().GetByIdAsync(request.Id);
            Color.IsSoldOut = request.IsSoldOut;
            _unitOfWork.GenericRepository<LookUpEntity>().Update(Color);
            await _unitOfWork.CompleteSaveAppDbAsync();
            //return record Id
            return Color.LookUpId;
        }
    }
}
