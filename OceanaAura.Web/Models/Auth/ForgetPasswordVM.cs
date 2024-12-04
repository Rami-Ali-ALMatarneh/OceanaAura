using FluentValidation;

namespace OceanaAura.Web.Models.Auth
{
    public class ForgetPasswordVM
    {
        public string Email { get; set; }
    }
    public class ForgetPasswordVMValidator : AbstractValidator<ForgetPasswordVM>
    {
        public ForgetPasswordVMValidator()
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .Matches(@"^[a-zA-Z0-9._%+-]+@gmail\.com$").WithMessage("Only Gmail addresses are allowed.");
        }
    }
}
