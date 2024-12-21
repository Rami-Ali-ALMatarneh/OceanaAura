using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.Product.Queries.GetProductByName;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Queries.GetProductUnique
{
    public class UniqueProductHandler : IRequestHandler<UniqueProductQuery, UniqueProductDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<UniqueProductHandler> _logger;

        public UniqueProductHandler(IMapper mapper,
           IUnitOfWork unitOfWork,
            IAppLogger<UniqueProductHandler> logger)
        {
            this._mapper = mapper;
            _unitOfWork = unitOfWork;
            this._logger = logger;
        }

        public async Task<UniqueProductDto> Handle(UniqueProductQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var Product = await _unitOfWork.productRepository.GetProduct(request.Name, request.Id);

            // convert data objects to DTO objects
            var data = _mapper.Map<UniqueProductDto>(Product);

            // return list of DTO object
            _logger.LogInformation("Products were retrieved successfully");
            return data;
        }
    }
}
