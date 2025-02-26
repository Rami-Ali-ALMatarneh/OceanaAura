using FluentValidation;

namespace OceanaAura.Web.Models.Auth
{
    public class LoginVM
    {

        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginVMValidator : AbstractValidator<LoginVM>
    {
        public LoginVMValidator()
        {
            RuleFor(x => x.Email)
                .Matches(@"^[a-zA-Z0-9._%+-]+@(gmail\.com|outlook\.com|yahoo\.com|hotmail\.com)$")
                .WithMessage("Please provide a valid Gmail, Outlook, Yahoo, or Hotmail address.");

            RuleFor(user => user.Password)
              .NotEmpty().WithMessage("Password is required")
              .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
              .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{6,}$")
              .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.");
        }
    }
}
