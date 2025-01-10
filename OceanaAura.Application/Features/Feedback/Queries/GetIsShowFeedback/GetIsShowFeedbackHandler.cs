using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.Feedback.Queries.GetAllFeedback;
using OceanaAura.Application.Features.LookUp.Queries.GetAllRegions;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Feedback.Queries.GetIsShowFeedback
{
    public class GetIsShowFeedbackHandler : IRequestHandler<GetIsShowFeedbackQuery, List<FeedbackDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetIsShowFeedbackHandler> _logger;

        public GetIsShowFeedbackHandler(IMapper mapper,
           IUnitOfWork unitOfWork,
            IAppLogger<GetIsShowFeedbackHandler> logger)
        {
            this._mapper = mapper;
            _unitOfWork = unitOfWork;
            this._logger = logger;
        }

        public async Task<List<FeedbackDto>> Handle(GetIsShowFeedbackQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var VisibilityFeedback = await _unitOfWork.feedbackRepository.GetVisibilityFeedback();

            // convert data objects to DTO objects
            var VisibilityFeedbackDto = _mapper.Map<List<FeedbackDto>>(VisibilityFeedback);

            // return list of DTO object
            _logger.LogInformation("Visibility Feedback are retrieved successfully");
            return VisibilityFeedbackDto;
        }
    }
}
