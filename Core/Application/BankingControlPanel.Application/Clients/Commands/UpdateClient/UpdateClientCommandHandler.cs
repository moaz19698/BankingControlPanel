using BankingControlPanel.Application.Clients.Exceptions;
using BankingControlPanel.Domain.Repositories;
using BankingControlPanel.Domain.ValueObjects;
using MediatR;

namespace BankingControlPanel.Application.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Unit>
    {
        private readonly IClientRepository _clientRepository;

        public UpdateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);
            if (client == null)
            {
                throw new ClientNotFoundException("Client not found.");
            }

            client.SetEmail(request.Email);
            client.SetFirstName(request.FirstName);
            client.SetLastName(request.LastName);
            client.SetProfilePhoto(request.ProfilePhoto);
            client.SetMobileNumber(request.MobileNumber);
            client.SetSex(request.Sex);
            client.SetAddress(new Address(request.Address.Country, request.Address.City, request.Address.Street, request.Address.ZipCode));
            client.SetAccounts(request.Accounts.Select(a => new Account(a.AccountNumber, a.AccountType)).ToList());

            await _clientRepository.UpdateAsync(client);
            return Unit.Value;
        }
    }
}