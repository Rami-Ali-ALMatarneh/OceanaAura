using MediatR;
using Microsoft.EntityFrameworkCore;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.BottleImg.Queries.filteredBottleImg;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.BottleImg.Queries.GetAllBottleImgs
{
    public class GetAllBottleHandler : IRequestHandler<GetAllBottleImgQuery, List<GetAllBottleImg>>
    {
        private readonly IAppLogger<GetAllBottleHandler> _appLogger;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBottleHandler(IAppLogger<GetAllBottleHandler> appLogger, IUnitOfWork unitOfWork)
        {
            _appLogger = appLogger;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllBottleImg>> Handle(GetAllBottleImgQuery request, CancellationToken cancellationToken)
        {
            _appLogger.LogInformation("Getting all bottle images");

            var bottleImgs = await _unitOfWork.GenericRepository<Domain.Entities.BottleImg>()
                .Query()
                .Select(b => new GetAllBottleImg
                {
                    Id = b.Id,
                    ImgUrlFront = b.ImgUrlFront,
                    ImgUrlBack = b.ImgUrlBack,
                    SizeId = b.SizeId,
                    ColorId = b.ColorId,
                    LidId = b.LidId
                })
                .ToListAsync(cancellationToken);

            _appLogger.LogInformation($"Retrieved {bottleImgs.Count} bottle images");

            return bottleImgs;
        }
    }
}
