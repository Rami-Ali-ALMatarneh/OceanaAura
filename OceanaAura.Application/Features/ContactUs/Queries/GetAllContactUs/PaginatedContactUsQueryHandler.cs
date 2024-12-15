using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MediatR;
using OceanaAura.Application.Common.Extensions;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ContactUs.Queries.GetAllContactUs
{
    public class PaginatedContactUsQueryHandler : IRequestHandler<PaginatedContactUsQuery, (List<ContactUsDto> ContactsUs, int TotalRecords)>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<PaginatedContactUsQueryHandler> _appLogger;

        public PaginatedContactUsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<PaginatedContactUsQueryHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<(List<ContactUsDto> ContactsUs, int TotalRecords)> Handle(PaginatedContactUsQuery request, CancellationToken cancellationToken)
        {
            // Retrieve all ContactUs records from the database
            var contactUsRepository = _unitOfWork.GenericRepository<Domain.Entities.ContactUs>();
            var query = contactUsRepository.Query();

            // Apply search filter for email, subject, and date
            if (!string.IsNullOrEmpty(request.SearchValue) || !string.IsNullOrEmpty(request.SearchDate))
            {
                // Filter by email, subject, and date if search value is present
                if (!string.IsNullOrEmpty(request.SearchValue))
                {
                    query = query.Where(c =>
                        c.Email.Contains(request.SearchValue) ||
                        c.Subject.Contains(request.SearchValue));
                }

                // Handle searchDate filtering
                if (!string.IsNullOrEmpty(request.SearchDate) && DateTime.TryParse(request.SearchDate, out DateTime searchDate))
                {
                    query = query.Where(c => c.SubmittedAt.Date == searchDate.Date);
                }
            }

            // Get the total record count
            var totalRecords = await contactUsRepository.CountAsync(query);

            // Apply sorting
            if (!string.IsNullOrEmpty(request.SortColumn))
            {
                if (request.SortColumn.Equals("SubmittedAt", StringComparison.OrdinalIgnoreCase))
                {
                    query = request.SortDirection.ToLower() == "asc"
                        ? query.OrderBy(c => c.SubmittedAt)
                        : query.OrderByDescending(c => c.SubmittedAt);
                }
                else
                {
                    query = request.SortDirection.ToLower() == "asc"
                        ? query.OrderByDynamic(request.SortColumn)
                        : query.OrderByDescendingDynamic(request.SortColumn);
                }
            }

            // Apply pagination
            query = query.Skip(request.Start).Take(request.Length);

            // Retrieve the paginated data
            var contactsUs = await contactUsRepository.ToListAsync(query);

            // Map to DTOs
            var data = _mapper.Map<List<ContactUsDto>>(contactsUs);

            _appLogger.LogInformation("Paginated Contact Us records retrieved successfully.");

            // Return the data and total record count
            return (data, totalRecords);
        }
    }
}
