using Ecomly.Core.DTOs;
using FluentValidation;

namespace Ecomly.Core.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(temp => temp.Email).NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid Email Address format");
        RuleFor(x=>x.Password).NotEmpty().WithMessage("Password is required");
    }
}

