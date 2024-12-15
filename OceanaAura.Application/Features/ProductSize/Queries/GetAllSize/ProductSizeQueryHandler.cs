using AutoMapper;
using MediatR;
using OceanaAura.Application.Common.Extensions;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.ProductColor.Queries.GetAllProductColors;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ProductSize.Queries.GetAllSize
{
    public class ProductSizeQueryHandler : IRequestHandler<PaginatedProductSizeQuery, (List<ProductSizeDto> productSizeDtos, int TotalRecords)>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<ProductSizeQueryHandler> _appLogger;

        public ProductSizeQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<ProductSizeQueryHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<(List<ProductSizeDto> productSizeDtos, int TotalRecords)> Handle(PaginatedProductSizeQuery request, CancellationToken cancellationToken)
        {
            // Retrieve all ProductColor records from the database
            var lookUpRepository = _unitOfWork.productSizeRepository;
            var query = lookUpRepository.GetAllSize();

            // Apply search filter for name
            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                query = query.Where(c =>
                    c.NameEn.Contains(request.SearchValue) ||
                    c.NameAr.Contains(request.SearchValue));
            }

            // Get the total record count
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

            // Apply pagination
            query = query.Skip(request.Start).Take(request.Length);

            // Retrieve the paginated data
            var ProductSizes = await Task.Run(() => query.ToList());

            // Map to DTOs
            var data = _mapper.Map<List<ProductSizeDto>>(ProductSizes);

            _appLogger.LogInformation("Paginated Product Colors retrieved successfully.");

            // Return the data and total record count
            return (data, totalRecords);
        }
    }
}
