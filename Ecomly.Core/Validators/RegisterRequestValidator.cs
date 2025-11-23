using Ecomly.Core.DTOs;
using FluentValidation;


namespace Ecomly.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            //Email
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Invalid email address format");
            // Password
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            // PersonName
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("PersonName is required").Length(1,50).WithMessage("Person Name should be 1 to 50 characters long");
            RuleFor(x => x.Gender).IsInEnum().WithMessage("Invalid Gender option");

        }
    }
}
