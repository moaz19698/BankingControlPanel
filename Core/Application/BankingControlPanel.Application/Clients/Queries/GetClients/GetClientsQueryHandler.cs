using AutoMapper;
using BankingControlPanel.Application.Clients.Dtos;
using BankingControlPanel.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Application.Clients.Queries.GetClients
{

    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, IEnumerable<ClientDto>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetClientsQueryHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientDto>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            var filter = request.Filter;
            var clients = await _clientRepository.GetClientsAsync(filter);
            return _mapper.Map<IEnumerable<ClientDto>>(clients);
        }
    }
}
