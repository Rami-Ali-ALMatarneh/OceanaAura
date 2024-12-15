using FluentValidation;

namespace OceanaAura.Web.Models.Auth
{
    public class ChangePasswordVM
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; } 

    }
    public class ChangePasswordVMValidator : AbstractValidator<ChangePasswordVM>
    {
        public ChangePasswordVMValidator()
        {
            RuleFor(user => user.CurrentPassword)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
            .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{6,}$")
            .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.");

            RuleFor(user => user.NewPassword)
           .NotEmpty().WithMessage("Password is required")
           .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
           .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{6,}$")
           .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.");

            RuleFor(user => user.ConfirmNewPassword)
           .NotEmpty().WithMessage("Confirm NewPassword is required")
           .Equal(user => user.NewPassword).WithMessage("Confirm New Password must match");

        }
    }
}
