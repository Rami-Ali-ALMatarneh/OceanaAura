using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Features.ProductColor.Commands.AddColor;
using OceanaAura.Application.Features.ProductColor.Commands.DeleteColor;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities.LookUp;
using OceanaAura.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ProductColor.Commands.UpdateColor
{
    public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IAppLogger<UpdateColorCommandHandler> _appLogger;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateColorCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<UpdateColorCommandHandler> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = logger;
        }

        public async Task<Unit> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
        {
            //validation request data
            var validator = new UpdatColorValidator(_unitOfWork);
            var ValidationResult = await validator.ValidateAsync(request);
            if (ValidationResult.Errors.Any())
            {
                var errorMessages = ValidationResult.Errors.Select(e => e.ErrorMessage).ToList();

                _appLogger.LogWarning("Validation errors in Create request {0} - {1}", nameof(UpdateColorCommand), request.NameEn);
                throw new BadRequestException(errorMessages);
            }
            // convert to domain entity
            var data = _mapper.Map<LookUpEntity>(request);
            data.LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductColor;
            // add to database
            _unitOfWork.GenericRepository<LookUpEntity>().Update(data);
            await _unitOfWork.CompleteSaveAppDbAsync();
            //return record Id
            return Unit.Value;
        }

    }
}
