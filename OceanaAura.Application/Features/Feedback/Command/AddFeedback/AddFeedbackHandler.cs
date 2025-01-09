using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.Order.Commands.CreateOrder;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Feedback.Command.AddFeedback
{
    public class AddFeedbackHandler : IRequestHandler<AddFeedbackCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<AddFeedbackHandler> _appLogger;

        public AddFeedbackHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<AddFeedbackHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<int> Handle(AddFeedbackCommand request, CancellationToken cancellationToken)
        {
            // Map the OrderDto to the Order entity
            var Feedback = _mapper.Map<OceanaAura.Domain.Entities.Feedback>(request);
            var Product = await _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.ProductsEntities.Product>().GetByIdAsync(request.ProductId);
            // Add the Order to the database
            Feedback.Product = Product;
            await _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Feedback>().AddAsync(Feedback);

            await _unitOfWork.CompleteSaveAppDbAsync();
            // Return the created Order ID
            return Feedback.FeedbackId;
        }
    }
}
