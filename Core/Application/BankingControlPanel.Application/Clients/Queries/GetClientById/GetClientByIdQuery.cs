using BankingControlPanel.Application.Clients.Dtos;
using MediatR;

namespace BankingControlPanel.Application.Clients.Queries.GetClientById
{
    public class GetClientByIdQuery : IRequest<ClientDto>
    {
        public GetClientByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}