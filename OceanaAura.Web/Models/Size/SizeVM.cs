using FluentValidation;
using OceanaAura.Web.Models.Colors;
using System.Text.RegularExpressions;

namespace OceanaAura.Web.Models.Size
{
    public class SizeVM
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
    }
    public class SizeVMValidator : AbstractValidator<SizeVM>
    {
        public SizeVMValidator()
        {
            RuleFor(p => p.NameEn)
           .NotEmpty().WithMessage("NameEn is required")
           .MinimumLength(2).WithMessage("NameEn  must be at least 2 characters long")
           .MaximumLength(50).WithMessage("{PropertyName} can have a maximum of 50 characters");

            RuleFor(p => p.NameAr)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters long")
               .MaximumLength(50).WithMessage("{PropertyName} can have a maximum of 50 characters");

          
        }
    }
}
