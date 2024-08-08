using BankingControlPanel.Application.Clients.Queries.GetClientById;
using BankingControlPanel.Application.Common.Interfaces;
using BankingControlPanel.Application.Users.Commands.RegisterUser;
using BankingControlPanel.Presentation.API.DTOs.Authentication;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingControlPanel.Presentation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
       

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand model)
        {
            // Call service to register user

            var user = await _mediator.Send( model);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginQuery model)
        {
            // Call service to authenticate user

            var user = await _mediator.Send(model);
            return Ok(user);
        }
    }
}
