using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Features.Order.Commands.UpdateOrder;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Feedback.Command.UpdateVisabilityFeedback
{
    public class VisibilityFeedbackHandler : IRequestHandler<VisibilityFeedback, int>
    {
        private readonly IAppLogger<VisibilityFeedbackHandler> _appLogger;
        private readonly IUnitOfWork _unitOfWork;

        public VisibilityFeedbackHandler(IAppLogger<VisibilityFeedbackHandler> appLogger, IUnitOfWork unitOfWork)
        {
            _appLogger = appLogger;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(VisibilityFeedback request, CancellationToken cancellationToken)
        {
            //validation request data
            var Feedback = await _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Feedback>().GetByIdAsync(request.FeedbackId);
            //verify that record exists
            if (Feedback == null)
            {
                _appLogger.LogWarning("Validation errors in Delete request {0} - {1}", nameof(Feedback), request.FeedbackId);
                throw new NotFoundException("Invalid to  Delete Feedback Product Message, Delete Feedback Product is Not Found!");
            }
            Feedback.IsShow = request.IsShow;
            // add to database
            _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Feedback>().Update(Feedback);
            await _unitOfWork.CompleteSaveAppDbAsync();
            //return record Id
            return Feedback.FeedbackId;
        }
    }
}
