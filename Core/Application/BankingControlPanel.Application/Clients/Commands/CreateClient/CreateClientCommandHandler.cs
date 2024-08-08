using BankingControlPanel.Application.Clients.Exceptions;
using BankingControlPanel.Domain.Entities;
using BankingControlPanel.Domain.Repositories;
using BankingControlPanel.Domain.ValueObjects;
using MediatR;

namespace BankingControlPanel.Application.Clients.Commands.CreateClient
{
    public class RegisterUserCommandHandler : IRequestHandler<CreateClientCommand, Guid>
    {
        private readonly IClientRepository _clientRepository;

        public RegisterUserCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var existingClient = await _clientRepository.GetClientByEmailAsync(request.Email);
            if (existingClient != null)
            {
                throw new ClientAlreadyExistsException("A client with this email already exists.");
            }
            var address = new Address(request.Address.Country, request.Address.City, request.Address.Street, request.Address.ZipCode);
            var accounts = request.Accounts.Select(a => new Account(a.AccountNumber, a.AccountType)).ToList();
            var client = new Client(request.Email, request.FirstName, request.LastName, request.PersonalId, request.ProfilePhoto, request.MobileNumber, request.Sex, address, accounts);

            await _clientRepository.AddAsync(client);
            return client.Id;
        }
    }
}