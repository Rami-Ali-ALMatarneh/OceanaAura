using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Features.Order.Commands.DeleteOrder;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Feedback.Command.DeleteFeedback
{
    public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand, Unit>
    {

        private readonly IAppLogger<DeleteFeedbackCommandHandler> _appLogger;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFeedbackCommandHandler(IAppLogger<DeleteFeedbackCommandHandler> appLogger, IUnitOfWork unitOfWork)
        {
            _appLogger = appLogger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
        {
            //validation request data
            var Feedback = await _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Feedback>().GetByIdAsync(request.FeedbackId);
            //verify that record exists
            if (Feedback == null)
            {
                _appLogger.LogWarning("Validation errors in Delete Feedback {0} - {1}", nameof(Feedback), request.FeedbackId);
                throw new NotFoundException("Invalid to Delete order,Feedback is Not Found!");
            }
            // add to database            
            _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Feedback>().Remove(Feedback);
            await _unitOfWork.CompleteSaveAppDbAsync();
            //return record Id
            return Unit.Value;
        }
    }
}
