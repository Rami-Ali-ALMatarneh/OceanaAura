using FluentValidation;
using OceanaAura.Web.Models.Colors;
using System.Text.RegularExpressions;

namespace OceanaAura.Web.Models.Size
{
    public class SizeVM
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }

        public string PriceJOR { get; set; }
        public string PriceUAE { get; set; }
        public string PriceUSD { get; set; }
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
            // Pricing validation when the category is not "Bottle"
            RuleFor(p => p.PriceJOR)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(BeValidPrice).WithMessage("Price JOR must be a valid number greater than zero.");

            RuleFor(p => p.PriceUAE)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(BeValidPrice).WithMessage("Price UAE must be a valid number greater than zero.");

            RuleFor(p => p.PriceUSD)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(BeValidPrice).WithMessage("Price USD must be a valid number greater than zero.");
        }
        private bool BeValidPrice(string price)
        {
            if (string.IsNullOrWhiteSpace(price)) return true; // Allow null or empty
            return decimal.TryParse(price, out var result) && result > 0;
        }
    }
}
