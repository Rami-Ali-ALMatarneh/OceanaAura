using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            // Retrieve all ProductSize records from the database
            var SizeRepository = _unitOfWork.GenericRepository<Domain.Entities.ProductSize>();
            var query = SizeRepository.Query();
            query = query.Include(ap => ap.Size);

            // Apply search filter for multiple fields
            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                query = query.Where(c =>
                    c.Size.NameEn.Contains(request.SearchValue) ||
                    c.Size.NameAr.Contains(request.SearchValue) ||
                    c.PriceJOR.ToString().Contains(request.SearchValue) ||
                    c.PriceUAE.ToString().Contains(request.SearchValue) ||
                    c.PriceUSD.ToString().Contains(request.SearchValue)
                );
            }

            // Get total records for pagination
            var totalRecords = await query.CountAsync();

            // Sorting
            // Apply sorting if there is a valid SortColumn
            if (!string.IsNullOrEmpty(request.SortColumn))
            {
                // Check the sort direction and apply sorting accordingly
                if (request.SortDirection.ToLower() == "asc")
                {
                    query = ApplySorting(query, request.SortColumn, true);
                }
                else
                {
                    query = ApplySorting(query, request.SortColumn, false);
                }
            }

            // Apply pagination
            query = query.Skip(request.Start).Take(request.Length);

            // Retrieve the paginated data
            var ProductSizes = await query.ToListAsync();

            // Map to DTOs
            var data = _mapper.Map<List<ProductSizeDto>>(ProductSizes);

            _appLogger.LogInformation("Paginated Product Sizes retrieved successfully.");

            // Return the data and total record count
            return (data, totalRecords);
        }

        // Helper method for dynamic sorting
        private IQueryable<Domain.Entities.ProductSize> ApplySorting(IQueryable<Domain.Entities.ProductSize> query, string sortColumn, bool ascending)
        {
            switch (sortColumn.ToLower())
            {
                case "nameen":
                    return ascending ? query.OrderBy(x => x.Size.NameEn) : query.OrderByDescending(x => x.Size.NameEn);
                case "namear":
                    return ascending ? query.OrderBy(x => x.Size.NameAr) : query.OrderByDescending(x => x.Size.NameAr);
                case "pricejor":
                    return ascending ? query.OrderBy(x => x.PriceJOR) : query.OrderByDescending(x => x.PriceJOR);
                case "priceuae":
                    return ascending ? query.OrderBy(x => x.PriceUAE) : query.OrderByDescending(x => x.PriceUAE);
                case "priceusd":
                    return ascending ? query.OrderBy(x => x.PriceUSD) : query.OrderByDescending(x => x.PriceUSD);
                default:
                    return query; // No sorting applied if the sort column is not recognized
            }
        }

    }
}
