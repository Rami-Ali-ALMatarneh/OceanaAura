using FluentValidation;
using MediatR;
using OceanaAura.Application.Features.LookUp.Common;
using OceanaAura.Application.Features.ProductColor.Commands.AddColor;
using OceanaAura.Application.Features.ProductColor.Commands.Common;
using OceanaAura.Application.Features.ProductSize.Command.AddSize;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Commands.Additional
{
    public class AddAdditionalValidator : AbstractValidator<AddAdditionalCommad>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddAdditionalValidator(IUnitOfWork unitOfWork) 
        {
            RuleFor(p => p.NameEn)
                .NotNull().WithMessage("{PropertyName} is required")
                .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters long")
                .MaximumLength(50).WithMessage("{PropertyName} can have a maximum of 50 characters");

            RuleFor(p => p.NameAr)
                .NotNull().WithMessage("{PropertyName} is required")
                .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters long")
                .MaximumLength(50).WithMessage("{PropertyName} can have a maximum of 50 characters");

            // Validate PriceJOR, PriceUAE, and PriceUSD
            RuleFor(p => p.PriceJOR)
                .NotNull().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

            RuleFor(p => p.PriceUAE)
                 .NotNull().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

            RuleFor(p => p.PriceUSD)
                .NotNull().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

            _unitOfWork = unitOfWork;
        }
    }
}
