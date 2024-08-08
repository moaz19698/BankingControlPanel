using BankingControlPanel.Application.Clients.Dtos;
using BankingControlPanel.Domain.Enums;
using MediatR;

namespace BankingControlPanel.Application.Clients.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<Guid>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public string ProfilePhoto { get; set; }
        public string MobileNumber { get; set; }
        public Sex Sex { get; set; }
        public AddressDto Address { get; set; }
        public List<AccountDto> Accounts { get; set; }
    }
}