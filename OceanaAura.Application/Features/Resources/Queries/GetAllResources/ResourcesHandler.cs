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

namespace OceanaAura.Application.Features.Resources.GetAllResources
{
    public class ResourcesHandler : IRequestHandler<ResourcesQuery, List<ResourcesDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<ResourcesHandler> _logger;

        public ResourcesHandler(IMapper mapper,
           IUnitOfWork unitOfWork,
            IAppLogger<ResourcesHandler> logger)
        {
            this._mapper = mapper;
            _unitOfWork = unitOfWork;
            this._logger = logger;
        }
        public async Task<List<ResourcesDto>> Handle(ResourcesQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var Resources = await _unitOfWork.productRepository.GetAllProducts();

            // convert data objects to DTO objects
            var data = _mapper.Map<List<ResourcesDto>>(Resources);

            // return list of DTO object
            _logger.LogInformation("Resources is retrieved successfully");
            return data;
        }
    }
}
