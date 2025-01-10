using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.LookUp.Queries.GetAllProductCategories;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Queries.GetAllRegions
{
    public class RegionHandler : IRequestHandler<RegionQuery, List<RegionDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<RegionHandler> _logger;

        public RegionHandler(IMapper mapper,
           IUnitOfWork unitOfWork,
            IAppLogger<RegionHandler> logger)
        {
            this._mapper = mapper;
            _unitOfWork = unitOfWork;
            this._logger = logger;
        }
        public async Task<List<RegionDto>> Handle(RegionQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var Regions = await _unitOfWork.lookUpRepository.GetAllRegions();

            // convert data objects to DTO objects
            var data = _mapper.Map<List<RegionDto>>(Regions);

            // return list of DTO object
            _logger.LogInformation("Regions are retrieved successfully");
            return data;
        }
    }
}
