using FluentValidation;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ContactUs.Commands.AddContactUs
{
    public class CraeteContactUsCommandValidator : AbstractValidator<AddContactUsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CraeteContactUsCommandValidator(IUnitOfWork unitOfWork) : base()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull()
               .MinimumLength(2).WithMessage("{PropertyName} the Maximum Length of Characters is 2")
               .MaximumLength(50).WithMessage("{PropertyName} the Maximum Length of Characters is 50");
            RuleFor(p => p.Email)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .Matches(@"^[a-zA-Z0-9._%+-]+@gmail\.com$").WithMessage("Only Gmail addresses are allowed.");

            RuleFor(p => p.Subject)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MinimumLength(1).WithMessage("{PropertyName} must have at least {MinLength} characters")
                .MaximumLength(200).WithMessage("{PropertyName} can have a maximum of {MaxLength} characters");

            RuleFor(p => p.Message)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MinimumLength(1).WithMessage("{PropertyName} must have at least {MinLength} characters")
                .MaximumLength(1000).WithMessage("{PropertyName} can have a maximum of {MaxLength} characters");
            _unitOfWork = unitOfWork;

        }
    }
}
