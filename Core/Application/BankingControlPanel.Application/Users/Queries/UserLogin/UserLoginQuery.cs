using MediatR;

namespace BankingControlPanel.Application.Clients.Queries.GetClientById
{
    public class UserLoginQuery : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}