using BankingControlPanel.Application.Clients.Queries.GetClientById;
using FluentValidation;

namespace BankingControlPanel.Application.Users.Validators
{
    public class LoginUserRequestValidator : AbstractValidator<UserLoginQuery>
    {
        public LoginUserRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}