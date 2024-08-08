using AutoMapper;
using BankingControlPanel.Application.Clients.Dtos;
using BankingControlPanel.Application.Clients.Exceptions;
using BankingControlPanel.Application.Clients.Queries.GetClients;
using BankingControlPanel.Application.Common.Exceptions;
using BankingControlPanel.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Application.Clients.Queries.GetClientById
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ClientDto>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetClientByIdQueryHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ClientDto> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);
            if (client == null)
            {
                throw new ClientNotFoundException("Client not found.");
            }

            return _mapper.Map<ClientDto>(client);
        }
    }
}
