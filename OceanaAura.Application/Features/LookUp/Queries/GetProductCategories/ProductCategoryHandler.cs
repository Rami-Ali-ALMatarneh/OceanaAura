using AutoMapper;
using MediatR;
using OceanaAura.Application.Common.Extensions;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.ProductSize.Queries.GetAllSize;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Queries.GetProductCategories
{
    public class ProductCategoryHandler : IRequestHandler<PaginatedProductCategoriesQuery, (List<ProductCategoriesDto>  productCategories, int TotalRecords)>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<ProductCategoryHandler> _appLogger;

        public ProductCategoryHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<ProductCategoryHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<(List<ProductCategoriesDto> productCategories, int TotalRecords)> Handle(PaginatedProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            var lookUpRepository = _unitOfWork.lookUpRepository;
            var query = lookUpRepository.GetProductsCategory();

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                query = query.Where(c =>
                    c.NameEn.Contains(request.SearchValue) ||
                    c.NameAr.Contains(request.SearchValue));
            }

            var totalRecords = query.Count();
            // Apply sorting
            if (!string.IsNullOrEmpty(request.SortColumn))
            {
                if (request.SortDirection.ToLower() == "asc")
                {
                    query = query.OrderByDynamic(request.SortColumn);
                }
                else
                {
                    query = query.OrderByDescendingDynamic(request.SortColumn);
                }
            }

            query = query.Skip(request.Start).Take(request.Length);

            var ProductSizes = await Task.Run(() => query.ToList());

            // Map to DTOs
            var data = _mapper.Map<List<ProductCategoriesDto>>(ProductSizes);

            _appLogger.LogInformation("Paginated Product Categories retrieved successfully.");

            return (data, totalRecords);
        }
    }
}
