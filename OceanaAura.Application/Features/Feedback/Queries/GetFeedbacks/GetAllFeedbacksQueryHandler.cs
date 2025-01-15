using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.Feedback.Queries.GetAllFeedback;
using OceanaAura.Application.Features.Feedback.Queries.GetIsShowFeedback;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Feedback.Queries.GetFeedbacks
{
    public class GetAllFeedbacksQueryHandler : IRequestHandler<GetAllFeedbacksQuery, List<FeedbackDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllFeedbacksQueryHandler> _logger;

        public GetAllFeedbacksQueryHandler(IMapper mapper,
           IUnitOfWork unitOfWork,
            IAppLogger<GetAllFeedbacksQueryHandler> logger)
        {
            this._mapper = mapper;
            _unitOfWork = unitOfWork;
            this._logger = logger;
        }

        public async Task<List<FeedbackDto>> Handle(GetAllFeedbacksQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var Feedbacks = await _unitOfWork.feedbackRepository.GetAllAsync();

            // convert data objects to DTO objects
            var FeedbackDto = _mapper.Map<List<FeedbackDto>>(Feedbacks);

            // return list of DTO object
            _logger.LogInformation("Feedback are retrieved successfully");
            return FeedbackDto;
        }
    }
}
