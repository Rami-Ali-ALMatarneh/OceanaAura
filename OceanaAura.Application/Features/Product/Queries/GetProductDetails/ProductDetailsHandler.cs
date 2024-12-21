using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Queries.GetProductDetails
{
    public class ProductDetailsHandler : IRequestHandler<ProductDetailsQuery, ProductDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<ProductDetailsHandler> _appLogger;

        public ProductDetailsHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<ProductDetailsHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<ProductDetailsDto> Handle(ProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var ProductRepository = _unitOfWork.GenericRepository<Domain.Entities.ProductsEntities.Product>();

            // Start building the query
            var query = ProductRepository.Query();

            // Include related data
            query = query.Include(ap => ap.ProductImages)
                         .Include(p => p.Category);

            // Use FirstOrDefaultAsync to asynchronously fetch the product by its Id
            var product = await query
                                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken); // Fetch the product by its Id


            var ProductDetailsDto = _mapper.Map<ProductDetailsDto>(product);
           
            _appLogger.LogInformation("Leave type has been retrieved successfully.");
            //reyurn data
            return ProductDetailsDto;
        }
    }
}
