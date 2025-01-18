using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.BottleImg.Queries.filteredBottleImg
{
    public class GetFilteredBottleImagesHandler : IRequestHandler<GetFilteredBottleImagesQuery, List<BottleImgDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFilteredBottleImagesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<BottleImgDto>> Handle(GetFilteredBottleImagesQuery request, CancellationToken cancellationToken)
        {
            var BottleImgRepository = _unitOfWork.GenericRepository<Domain.Entities.BottleImg>();
            var query = BottleImgRepository.Query();
            // Apply filters step-by-step
            if (request.SizeId > 0)
            {
                query = query.Where(img => img.SizeId == request.SizeId);
            }

            if (request.LidId.HasValue && request.LidId > 0)
            {
                query = query.Where(img => img.LidId == request.LidId);
            }

            if (request.ColorId.HasValue && request.ColorId > 0)
            {
                query = query.Where(img => img.ColorId == request.ColorId);
            }

            // Execute the query and map to DTO
            var filteredImages = await query.ToListAsync(cancellationToken);
           var BottleImgsDto = _mapper.Map<List<BottleImgDto>>(filteredImages);
            return BottleImgsDto;
        }
    }
}
