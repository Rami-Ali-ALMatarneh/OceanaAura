using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.ContactUs.Queries.GetAllContactUs;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.ProductsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Queries.GetAllProduct
{
    public class PaginatedProductQueryHandler : IRequestHandler<PaginatedProductQuery, (List<GetProductDto> productDtos, int TotalRecords)>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<PaginatedProductQueryHandler> _appLogger;

        public PaginatedProductQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<PaginatedProductQueryHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<(List<GetProductDto> productDtos, int TotalRecords)> Handle(PaginatedProductQuery request, CancellationToken cancellationToken)
        {
            var ProductRepository = _unitOfWork.GenericRepository<Domain.Entities.ProductsEntities.Product>();
            var query = ProductRepository.Query();
            query = query.Include(ap => ap.ProductImages)
                .Include(p => p.Category);

            // Apply search filtering
            if (!string.IsNullOrWhiteSpace(request.SearchValue))
            {
                query = query.Where(p => p.Name.Contains(request.SearchValue) ||
                                         p.Description.Contains(request.SearchValue) ||
                                         p.Category.NameEn.Contains(request.SearchValue) ||
                                         p.Category.NameAr.Contains(request.SearchValue) ||
                             p.Discount.ToString().Contains(request.SearchValue) ||
                             (p.PriceJOR.HasValue && p.PriceJOR.ToString().Contains(request.SearchValue)) ||
                             (p.PriceUAE.HasValue && p.PriceUAE.ToString().Contains(request.SearchValue)) ||
                             (p.PriceUSD.HasValue && p.PriceUSD.ToString().Contains(request.SearchValue)) ||
                             (p.PriceUSD.HasValue && p.PriceUSD.ToString().Contains(request.SearchValue)));
            }

            // Apply sorting
            if (!string.IsNullOrWhiteSpace(request.SortColumn))
            {
                var sortDirection = request.SortDirection.ToLower();
                switch (request.SortColumn.ToLower())
                {
                    case "name":
                        query = sortDirection == "asc" ? query.OrderBy(p => p.Name) : query.OrderByDescending(p => p.Name);
                        break;
                    case "description":
                        query = sortDirection == "asc" ? query.OrderBy(p => p.Description) : query.OrderByDescending(p => p.Description);
                        break;
                    case "nameencategory":
                        query = sortDirection == "asc" ? query.OrderBy(p => p.Category.NameEn) : query.OrderByDescending(p => p.Category.NameEn);
                        break;
                    case "namearcategory":
                        query = sortDirection == "asc" ? query.OrderBy(p => p.Category.NameAr) : query.OrderByDescending(p => p.Category.NameAr);
                        break;
                    case "pricejor":
                        query = sortDirection == "asc" ? query.OrderBy(p => p.PriceJOR) : query.OrderByDescending(p => p.PriceJOR);
                        break;
                    case "priceuae":
                        query = sortDirection == "asc" ? query.OrderBy(p => p.PriceUAE) : query.OrderByDescending(p => p.PriceUAE);
                        break;
                    case "priceusd":
                        query = sortDirection == "asc" ? query.OrderBy(p => p.PriceUSD) : query.OrderByDescending(p => p.PriceUSD);
                        break;
                    case "discount":
                        query = sortDirection == "asc" ? query.OrderBy(p => p.Discount) : query.OrderByDescending(p => p.Discount);
                        break;
                    default:
                        query = query.OrderBy(p => p.Name); // Default sorting (you can choose a different field)
                        break;
                }
            }


            // Get total record count (before pagination)
            int totalRecords = await query.CountAsync(cancellationToken);

            // Apply pagination
            query = query.Skip(request.Start).Take(request.Length);

            // Execute the query and project to DTO
            var products = await query.ToListAsync(cancellationToken);
            var productDtos = _mapper.Map<List<GetProductDto>>(products);

            return (productDtos, totalRecords);
        }
    }
}
