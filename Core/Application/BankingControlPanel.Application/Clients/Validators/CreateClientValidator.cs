using BankingControlPanel.Application.Clients.Commands.CreateClient;
using BankingControlPanel.Application.Clients.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Application.Clients.Validators
{
    public class CreateClientValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientValidator()
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

            RuleFor(x => x.PersonalId)
                .NotEmpty().WithMessage("Personal ID is required.")
                .Length(11).WithMessage("Personal ID must be exactly 11 characters.");

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

    public class AddressValidator : AbstractValidator<AddressDto>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required.");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Street is required.");
            RuleFor(x => x.ZipCode).NotEmpty().WithMessage("Zip code is required.");
        }
    }
}
