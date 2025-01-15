using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.Product.Queries.GetProduct;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Queries.GetCategoryWithNumberProduct
{
    public class GetCategoryWithNumberProductHandler : IRequestHandler<GetCategoryWithNumberProductQuery, List<CategoryWithNumberProductDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetCategoryWithNumberProductHandler> _logger;

        public GetCategoryWithNumberProductHandler(IMapper mapper,
           IUnitOfWork unitOfWork,
            IAppLogger<GetCategoryWithNumberProductHandler> logger)
        {
            this._mapper = mapper;
            _unitOfWork = unitOfWork;
            this._logger = logger;
        }

        public async Task<List<CategoryWithNumberProductDto>> Handle(GetCategoryWithNumberProductQuery request, CancellationToken cancellationToken)
        {
            // Retrieve all products and categories from the repositories
            var products = await _unitOfWork.productRepository.GetAllProducts();
            var categories = await _unitOfWork.lookUpRepository.GetAllProductsCategory();

            // Group products by CategoryId and count the number of products in each category
            var productsGroupedByCategory = products
                .GroupBy(product => product.CategoryId)
                .Select(group => new
                {
                    CategoryId = group.Key,
                    NumberOfProducts = group.Count()
                })
                .ToList();

            // Map the category IDs to their corresponding category names and create the DTOs
            var result = productsGroupedByCategory
                .Select(group => new CategoryWithNumberProductDto
                {
                    CategoryName = categories.FirstOrDefault(category => category.LookUpId == group.CategoryId)?.NameEn ?? "Unknown",
                    NumberOfProductInCategory = group.NumberOfProducts
                })
                .ToList();

            // Log the result for debugging purposes
            _logger.LogInformation("Retrieved {Count} categories with products", result.Count);

            return result;
        }
    }
}
