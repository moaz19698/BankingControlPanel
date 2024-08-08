using BankingControlPanel.Application.Clients.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
