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

namespace OceanaAura.Application.Features.Product.Queries.GetProduct
{
    public class ProductHandler : IRequestHandler<ProductQuery, List<ProductHomeDto>>
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
        public async Task<List<ProductHomeDto>> Handle(ProductQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var products = await _unitOfWork.productRepository.GetAllProducts();
            // convert data objects to DTO objects
            var data = _mapper.Map<List<ProductHomeDto>>(products);

            // return list of DTO object
            _logger.LogInformation("Products is retrieved successfully");
            return data;
        }
    }
}
