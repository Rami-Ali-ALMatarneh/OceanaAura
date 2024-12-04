using FluentValidation;

namespace OceanaAura.Web.Models.Auth
{
    public class UpdateInfo
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? ModifyOn { get; set; } 
        public DateTime? CreatedOn { get; set; }
    }
    public class UpdateInfoValidator : AbstractValidator<UpdateInfo>
    {
        public UpdateInfoValidator()
        {
            RuleFor(x => x.Email)
           .NotEmpty().WithMessage("Email is required.")
           .Matches(@"^[a-zA-Z0-9._%+-]+@gmail\.com$").WithMessage("Only Gmail addresses are allowed.");
            RuleFor(user => user.UserName)
                .NotEmpty().WithMessage("UserName is required.") 
                .MinimumLength(5).WithMessage("UserName must be at least 5 characters long.") 
                .MaximumLength(20).WithMessage("UserName must not exceed 20 characters.") 
                .Matches(@"^[a-zA-Z0-9]+$").WithMessage("UserName can only contain letters and numbers.");
            RuleFor(x => x.PhoneNumber)
               .Matches(@"^\+9627[789]\d{7}$|^\+9715[024568]\d{7}$")
               .WithMessage("PhoneNumber must be a valid JOR or UAE number.")
               .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber)); // Only validate if provided

        }
    }
}
