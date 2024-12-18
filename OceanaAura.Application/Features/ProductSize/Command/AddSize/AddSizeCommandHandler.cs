using AutoMapper;
using FluentValidation;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Features.ProductColor.Commands.AddColor;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities.LookUp;
using OceanaAura.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ProductSize.Command.AddSize
{
    public class AddSizeCommandHandler : IRequestHandler<AddSizeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<AddSizeCommandHandler> _appLogger;

        public AddSizeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<AddSizeCommandHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<int> Handle(AddSizeCommand request, CancellationToken cancellationToken)
        {
            //validation request data
            var validator = new AddSizeValidator(_unitOfWork);
            var ValidationResult = await validator.ValidateAsync(request);
            if (ValidationResult.Errors.Any())
            {
                var errorMessages = ValidationResult.Errors.Select(e => e.ErrorMessage).ToList();

                _appLogger.LogWarning("Validation errors in Create request {0} - {1}", nameof(AddSizeCommand), request.NameEn);

                // Pass the error messages as a list to the exception
                throw new BadRequestException(errorMessages);
            }


            // convert to domain entity
            var data = _mapper.Map<LookUpEntity>(request);
            data.LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductSize;
            var size = new Domain.Entities.ProductSize
            {
                SizeId = data.LookUpId,
                PriceJOR = request.PriceJOR,
                PriceUAE = request.PriceUAE,
                PriceUSD = request.PriceUSD,
                Size = data
            };
            // add to database
            await _unitOfWork.GenericRepository<LookUpEntity>().AddAsync(data);
            await _unitOfWork.GenericRepository<Domain.Entities.ProductSize>().AddAsync(size);
            await _unitOfWork.CompleteSaveAppDbAsync();

            //return record Id
            return data.Id;
        }
    }
}
