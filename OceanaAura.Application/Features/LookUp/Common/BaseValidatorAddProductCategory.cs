using FluentValidation;
using OceanaAura.Application.Features.LookUp.Commands.AddCagegory;
using OceanaAura.Application.Features.ProductColor.Commands.Common;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Common
{
    public class BaseValidatorAddProductCategory<T> : AbstractValidator<T> where T : AddProductCategoryCommad
    {
        private readonly IUnitOfWork _unitOfWork;

        protected BaseValidatorAddProductCategory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(p => p.NameEn)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters long")
            .MaximumLength(50).WithMessage("{PropertyName} can have a maximum of 50 characters");

            RuleFor(p => p.NameAr)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters long")
               .MaximumLength(50).WithMessage("{PropertyName} can have a maximum of 50 characters");
            _unitOfWork = unitOfWork;
        }
    }
}
