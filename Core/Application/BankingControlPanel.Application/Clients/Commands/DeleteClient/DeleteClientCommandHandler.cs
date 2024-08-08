using BankingControlPanel.Application.Clients.Exceptions;
using BankingControlPanel.Domain.Repositories;
using MediatR;

namespace BankingControlPanel.Application.Clients.Commands.DeleteClient
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Unit>
    {
        private readonly IClientRepository _clientRepository;

        public DeleteClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);
            if (client == null)
            {
                throw new ClientNotFoundException("Client not found.");
            }

            await _clientRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}