using FluentValidation;

namespace OceanaAura.Web.Models.Auth
{
    public class ResetPasswordVM
    {
        public string OTP { get; set; }
    }
    public class ResetPasswordVMValidator : AbstractValidator<ResetPasswordVM>
    {
        public ResetPasswordVMValidator()
        {
            RuleFor(user => user.OTP)
              .NotEmpty().WithMessage("OTP is required")
              .Length(10).WithMessage("OTP must be exactly 10 characters.");
        }
    }
}
