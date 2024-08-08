using BankingControlPanel.Application.Clients.Commands.CreateClient;
using BankingControlPanel.Application.Clients.Commands.DeleteClient;
using BankingControlPanel.Application.Clients.Commands.UpdateClient;
using BankingControlPanel.Application.Clients.Dtos;
using BankingControlPanel.Application.Clients.Queries.GetClientById;
using BankingControlPanel.Application.Clients.Queries.GetClients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankingControlPanel.Presentation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClientDto), 200)]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            var client = await _mediator.Send(new GetClientByIdQuery(id));
            return Ok(client);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClientDto>), 200)]
        public async Task<IActionResult> GetClients([FromQuery] GetClientsQuery query)
        {
            var clients = await _mediator.Send(query);
            return Ok(clients);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 201)]
        public async Task<IActionResult> CreateClient(CreateClientCommand command)
        {
            var clientId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetClientById), new { id = clientId }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(Guid id, UpdateClientCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            await _mediator.Send(new DeleteClientCommand(id));
            return NoContent();
        }
    }
}