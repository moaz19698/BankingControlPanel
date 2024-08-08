using BankingControlPanel.Application.Clients.Dtos;
using BankingControlPanel.Domain.DTOs.Clients;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Application.Clients.Queries.GetClients
{
    public class GetClientsQuery : IRequest<IEnumerable<ClientDto>>
    {
        public GetClientsQuery()
        {
            Filter=new ClientFilterDto();
        }
        public ClientFilterDto Filter { get; set; }
    }
}
