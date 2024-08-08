using BankingControlPanel.Application.Clients.Queries.GetClientById;
using BankingControlPanel.Application.Users.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankingControlPanel.Presentation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        public async Task<IActionResult> Register(RegisterUserCommand model)
        {
            var user = await _mediator.Send(model);
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> Login(UserLoginQuery model)
        {
            var user = await _mediator.Send(model);
            return Ok(user);
        }
    }
}