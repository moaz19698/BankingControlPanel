using BankingControlPanel.Application.Clients.Commands.UpdateClient;
using FluentValidation;

namespace BankingControlPanel.Application.Clients.Validators
{
    public class UpdateClientValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(60).WithMessage("First name must be less than 60 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(60).WithMessage("Last name must be less than 60 characters.");

            RuleFor(x => x.MobileNumber)
                .NotEmpty().WithMessage("Mobile number is required.")
                .Matches(@"^\+[1-9]\d{1,14}$").WithMessage("Invalid mobile number format.");

            RuleFor(x => x.Sex)
                .IsInEnum().WithMessage("Sex is required.");

            RuleFor(x => x.Address)
                .NotNull().WithMessage("Address is required.")
                .SetValidator(new AddressValidator());

            RuleFor(x => x.Accounts)
                .NotEmpty().WithMessage("At least one account is required.");
        }
    }
}