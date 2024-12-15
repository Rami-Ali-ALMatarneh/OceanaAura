using FluentValidation;
using System.Text.RegularExpressions;

namespace OceanaAura.Web.Models.Home
{
    public class ContactUsVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }

    public class ContactUsVMValidator : AbstractValidator<ContactUsVM>
    {
        public ContactUsVMValidator()
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .Matches(@"^[a-zA-Z0-9._%+-]+@gmail\.com$").WithMessage("Only Gmail addresses are allowed.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .Must(HasValidDomain).WithMessage("Invalid email domain."); // Ensuring valid domain

            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Subject is required.")
                .Length(2, 100).WithMessage("Subject must be between 2 and 100 characters.")
                .Matches(@"^[a-zA-Z0-9\s]+$").WithMessage("Subject must contain only alphanumeric characters and spaces.");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message is required.")
                .MaximumLength(1000).WithMessage("Message cannot exceed 1000 characters.")
                .Must(BeSafe).WithMessage("Message contains unsafe characters."); // Prevent XSS-like input
        }
        private bool HasValidDomain(string email)
        {
            var validDomains = new[] { "example.com" };
            var emailDomain = email.Split('@')[1];
            return validDomains.Contains(emailDomain);
        }

        private bool BeSafe(string message)
        {
            if (string.IsNullOrEmpty(message)) return true;

            var regex = new Regex(@"<.*?>|javascript:", RegexOptions.IgnoreCase);
            return !regex.IsMatch(message); 
        }
    }
}
