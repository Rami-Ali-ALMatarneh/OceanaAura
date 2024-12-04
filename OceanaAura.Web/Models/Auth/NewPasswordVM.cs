using FluentValidation;

namespace OceanaAura.Web.Models.Auth
{
    public class NewPasswordVM
    {
        public string OTP { get; set; } 
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class NewPasswordVMValidator : AbstractValidator<NewPasswordVM>
    {
        public NewPasswordVMValidator()
        {
            RuleFor(user => user.NewPassword)
              .NotEmpty().WithMessage("Password is required")
              .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
              .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{6,}$")
              .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.");
            // Validation for ConfirmPassword
            RuleFor(user => user.ConfirmPassword)
                .NotEmpty().WithMessage("Please confirm your password.")
                .Equal(user => user.NewPassword).WithMessage("The confirmation password does not match the new password.");
        }
    }
}
