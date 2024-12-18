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

namespace OceanaAura.Application.Features.Product.Queries.GetProductByName
{
    public class ProductHandler : IRequestHandler<ProductQuery,ProductDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<ProductHandler> _logger;

        public ProductHandler(IMapper mapper,
           IUnitOfWork unitOfWork,
            IAppLogger<ProductHandler> logger)
        {
            this._mapper = mapper;
            _unitOfWork = unitOfWork;
            this._logger = logger;
        }
        public async Task<ProductDto> Handle(ProductQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var Product = await _unitOfWork.productRepository.GetProductByName(request.Name);

            // convert data objects to DTO objects
            var data = _mapper.Map<ProductDto>(Product);

            // return list of DTO object
            _logger.LogInformation("Products Categories were retrieved successfully");
            return data;
        }
    }
}
