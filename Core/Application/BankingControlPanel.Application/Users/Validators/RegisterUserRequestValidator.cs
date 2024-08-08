using BankingControlPanel.Application.Users.Commands.RegisterUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Application.Users.Validators
{
    public class RegisterUserRequestValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .Length(1, 50).WithMessage("First name must be less than 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .Length(1, 50).WithMessage("Last name must be less than 50 characters.");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Role is required.");
        }
    }
}
