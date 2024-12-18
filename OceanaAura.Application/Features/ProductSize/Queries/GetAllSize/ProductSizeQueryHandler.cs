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
            // Retrieve all ProductColor records from the database
            var SizeRepository = _unitOfWork.GenericRepository<Domain.Entities.ProductSize>();
            var query = SizeRepository.Query();
            query = query.Include(ap => ap.Size);

            // Apply search filter for name
            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                query = query.Where(c =>
                    c.Size.NameEn.Contains(request.SearchValue) ||
                    c.Size.NameAr.Contains(request.SearchValue) ||
                     c.PriceJOR.ToString().Contains(request.SearchValue) ||
                    c.PriceUAE.ToString().Contains(request.SearchValue) ||
                    c.PriceUSD.ToString().Contains(request.SearchValue));
            }
            var totalRecords = await query.CountAsync();  // Use async for counting records

            // Sorting
            // Only apply sorting if there are records
            if (!string.IsNullOrEmpty(request.SortColumn))
            {
                if (request.SortDirection.ToLower() == "asc")
                {
                    if (request.SortColumn == "NameEn")
                    {
                        query = query.OrderBy(x => x.Size.NameEn);
                    }
                    else if (request.SortColumn == "NameAr")
                    {
                        query = query.OrderBy(x => x.Size.NameAr);
                    }
                    else
                    {
                        query = query.OrderByDynamic(request.SortColumn);
                    }
                }
                else
                {
                    if (request.SortColumn == "NameEn")
                    {
                        query = query.OrderByDescending(x => x.Size.NameEn);
                    }
                    else if (request.SortColumn == "NameAr")
                    {
                        query = query.OrderByDescending(x => x.Size.NameAr);
                    }
                    else
                    {
                        query = query.OrderByDescendingDynamic(request.SortColumn);
                    }
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
