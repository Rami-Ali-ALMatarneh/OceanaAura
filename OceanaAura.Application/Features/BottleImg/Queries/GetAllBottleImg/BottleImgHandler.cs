using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.BottleImg.Queries.GetAllBottleImg;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.BottleImg.Queries.GetAllBottleImg
{
    public class BottleImgHandler : IRequestHandler<PaginatedBottleImg, (List<GetBottleImg> getBottleImgs, int TotalRecords)>
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

        public async Task<(List<GetBottleImg> getBottleImgs, int TotalRecords)> Handle(PaginatedBottleImg request, CancellationToken cancellationToken)
        {
            var BottleImgRepository = _unitOfWork.GenericRepository<Domain.Entities.BottleImg>();
            var query = BottleImgRepository.Query();

            // Get total record count (before pagination)
            int totalRecords = await query.CountAsync(cancellationToken);

            // Apply pagination
            query = query.Skip(request.Start).Take(request.Length);

            // Execute the query and project to DTO
            var bottleImgs = await query.ToListAsync(cancellationToken);
            var getBottleImgs = _mapper.Map<List<GetBottleImg>>(bottleImgs);
            return (getBottleImgs, totalRecords);
        }
    }
}