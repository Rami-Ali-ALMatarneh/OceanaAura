using AutoMapper;
using MediatR;
using OceanaAura.Application.Common.Extensions;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.ContactUs.Queries.GetAllContactUs;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ProductColor.Queries.GetAllProductColors
{
    public class ProductColorQueryHandler : IRequestHandler<PaginatedProductColorQuery, (List<ProductColorDto> productColorDtos, int TotalRecords)>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<ProductColorQueryHandler> _appLogger;

        public ProductColorQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<ProductColorQueryHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<(List<ProductColorDto> productColorDtos, int TotalRecords)> Handle(PaginatedProductColorQuery request, CancellationToken cancellationToken)
        {
            // Retrieve all ProductColor records from the database
            var lookUpRepository = _unitOfWork.productColorRepository;
            var query = lookUpRepository.GetAllColor();

            // Apply search filter for name
            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                query = query.Where(c =>
                    c.Details.Contains(request.SearchValue) ||
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
            var productColors = await Task.Run(() => query.ToList());

            // Map to DTOs
            var data = _mapper.Map<List<ProductColorDto>>(productColors);

            _appLogger.LogInformation("Paginated Product Colors retrieved successfully.");

            // Return the data and total record count
            return (data, totalRecords);
        }
    }
}
