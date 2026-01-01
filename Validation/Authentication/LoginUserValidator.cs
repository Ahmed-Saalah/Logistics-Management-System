using FluentValidation;
using LogisticsManagementSystem.DTOs.IdentityDTOs;

namespace LogisticsManagementSystem.Validation.Authentication
{
    public class LoginUserValidator : AbstractValidator<LoginDTO>
    {
        public LoginUserValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("Enail is required")
                .EmailAddress()
                .WithMessage("Invalid email format");

            RuleFor(c => c.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
