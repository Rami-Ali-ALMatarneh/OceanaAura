using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.Feedback.Command.AddFeedback;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.BottleImg.Command.AddBottleImg
{
    public class BottleImgHandler : IRequestHandler<AddBottleImgDto, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<BottleImgHandler> _appLogger;

        public BottleImgHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<BottleImgHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<int> Handle(AddBottleImgDto request, CancellationToken cancellationToken)
        {
            var BottleImg = _mapper.Map<OceanaAura.Domain.Entities.BottleImg>(request);
         await _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.BottleImg>().AddAsync(BottleImg);
           await _unitOfWork.CompleteSaveAppDbAsync();
            return BottleImg.Id;
        }
    }
}
