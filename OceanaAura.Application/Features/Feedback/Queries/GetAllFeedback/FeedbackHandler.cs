using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.Feedback.Queries.GetAllFeedback;
using OceanaAura.Application.Persistence;


namespace OceanaAura.Application.Features.Feedback.Queries.GetAllFeedback
{
    public class FeedbackHandler : IRequestHandler<PaginatedFeedback, (List<FeedbackDto> feedbacks, int TotalRecords)>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<FeedbackHandler> _appLogger;

        public FeedbackHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<FeedbackHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<(List<FeedbackDto> feedbacks, int TotalRecords)> Handle(PaginatedFeedback request, CancellationToken cancellationToken)
        {
            var feedbackRepository = _unitOfWork.GenericRepository<Domain.Entities.Feedback>();
            var query = feedbackRepository.Query();
            query = query.Include(x => x.Product);

            // Apply search filter
            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                query = query.Where(f =>
                    f.FeedbackId.ToString().Contains(request.SearchValue) ||
                    f.ProductId.ToString().Contains(request.SearchValue) ||
                    f.Email.Contains(request.SearchValue) ||
                    f.SubmittedOn.ToString().Contains(request.SearchValue) ||
                    f.Rating.ToString().Contains(request.SearchValue));
            }

            // Apply date filter if provided
            if (!string.IsNullOrEmpty(request.SearchDate) && DateTime.TryParse(request.SearchDate, out var searchDate))
            {
                query = query.Where(f => f.SubmittedOn.Date == searchDate.Date);
            }

            // Apply sorting
            if (!string.IsNullOrEmpty(request.SortColumn) && !string.IsNullOrEmpty(request.SortDirection))
            {
                switch (request.SortColumn.ToLower())
                {
                    case "feedbackid":
                        query = request.SortDirection.ToLower() == "asc"
                            ? query.OrderBy(f => f.FeedbackId)
                            : query.OrderByDescending(f => f.FeedbackId);
                        break;
                    case "productid":
                        query = request.SortDirection.ToLower() == "asc"
                            ? query.OrderBy(f => f.ProductId)
                            : query.OrderByDescending(f => f.ProductId);
                        break;
                    case "email":
                        query = request.SortDirection.ToLower() == "asc"
                            ? query.OrderBy(f => f.Email)
                            : query.OrderByDescending(f => f.Email);
                        break;
                    case "submittedon":
                        query = request.SortDirection.ToLower() == "asc"
                            ? query.OrderBy(f => f.SubmittedOn)
                            : query.OrderByDescending(f => f.SubmittedOn);
                        break;
                    case "rating":
                        query = request.SortDirection.ToLower() == "asc"
                            ? query.OrderBy(f => f.Rating)
                            : query.OrderByDescending(f => f.Rating);
                        break;
                    default:
                        query = query.OrderBy(f => f.FeedbackId);
                        break;
                }
            }

            // Get total records count before pagination
            var totalRecords = await query.CountAsync(cancellationToken);

            // Apply pagination
            var feedbacks = await query
                .Skip(request.Start)
                .Take(request.Length)
                .ToListAsync(cancellationToken);

            // Map entities to DTOs
            var feedbackDtos = _mapper.Map<List<FeedbackDto>>(feedbacks);

            return (feedbackDtos, totalRecords);
        }
    }
}