using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.Product.Queries.GetProduct;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Queries.Lids
{
    public class LidsHandler : IRequestHandler<LidsQuery, List<LidsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<LidsHandler> _logger;

        public LidsHandler(IMapper mapper,
           IUnitOfWork unitOfWork,
            IAppLogger<LidsHandler> logger)
        {
            this._mapper = mapper;
            _unitOfWork = unitOfWork;
            this._logger = logger;
        }
        public async Task<List<LidsDto>> Handle(LidsQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var products = await _unitOfWork.productRepository.GetAllProducts();
            products = products.Where(x => x.CategoryId == (int)LookUpEnums.ProductCategory.Lids).ToList();
            // convert data objects to DTO objects
            var data = _mapper.Map<List<LidsDto>>(products);

            // return list of DTO object
            _logger.LogInformation("Lids is retrieved successfully");
            return data;
        }
    }
}
