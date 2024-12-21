using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OceanaAura.Application.Common.Extensions;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.LookUp.Queries.GetProductCategories;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Queries.GetAllAdditinalProduct
{
    public class AdditionalPaginatedHandler : IRequestHandler<PaginatedAdditionalQuery, (List<AdditionalDto> additionalDtos, int TotalRecords)>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<AdditionalPaginatedHandler> _appLogger;

        public AdditionalPaginatedHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<AdditionalPaginatedHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<(List<AdditionalDto> additionalDtos, int TotalRecords)> Handle(PaginatedAdditionalQuery request, CancellationToken cancellationToken)
        {
            var additionalRepository = _unitOfWork.GenericRepository<AdditionalProduct>();
            var query = additionalRepository.Query();
            query =query.Include(ap => ap.AdditionalProducts);
            // Apply search filter for email, subject, and date
            if (!string.IsNullOrEmpty(request.SearchValue) || !string.IsNullOrEmpty(request.SearchDate))
            {
                if (!string.IsNullOrEmpty(request.SearchValue))
                {
                    query = query.Where(c =>
                        c.AdditionalProducts.NameEn.Contains(request.SearchValue) ||
                        c.AdditionalProducts.NameAr.Contains(request.SearchValue) ||
                        c.PriceJOR.ToString().Contains(request.SearchValue) ||
                        c.PriceUAE.ToString().Contains(request.SearchValue) ||
                        c.PriceUSD.ToString().Contains(request.SearchValue));
                }

                // Handle searchDate filtering
                if (!string.IsNullOrEmpty(request.SearchDate) && DateTime.TryParse(request.SearchDate, out DateTime searchDate))
                {
                    query = query.Where(c => c.CreatedOn.Date == searchDate.Date);
                }
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
                        query = query.OrderBy(x => x.AdditionalProducts.NameEn);
                    }
                    else if (request.SortColumn == "NameAr")
                    {
                        query = query.OrderBy(x => x.AdditionalProducts.NameAr);
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
                        query = query.OrderByDescending(x => x.AdditionalProducts.NameEn);
                    }
                    else if (request.SortColumn == "NameAr")
                    {
                        query = query.OrderByDescending(x => x.AdditionalProducts.NameAr);
                    }
                    else
                    {
                        query = query.OrderByDescendingDynamic(request.SortColumn);
                    }
                }
            }


            query = query.Skip(request.Start).Take(request.Length);

            // Execute query and map results
            var additionalProducts = await query.ToListAsync(cancellationToken);  // Use async version to avoid blocking
            foreach(var additional in additionalProducts)
            {
                additional.AdditionalProducts = await _unitOfWork.lookUpRepository.GetByIdAsync(additional.LookUpId);
            }
            // Map to DTOs
            var data = _mapper.Map<List<AdditionalDto>>(additionalProducts);
            if (data.Any())
            {
                _appLogger.LogInformation("Paginated Additional Products retrieved successfully.");
            }
            else
            {
                _appLogger.LogWarning("No Additional Products found matching the query.");
            }

            return (data, totalRecords);
        }
    }
}
