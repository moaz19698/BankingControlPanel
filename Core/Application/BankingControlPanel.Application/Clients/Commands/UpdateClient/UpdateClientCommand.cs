using BankingControlPanel.Application.Clients.Dtos;
using BankingControlPanel.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Application.Clients.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePhoto { get; set; }
        public string MobileNumber { get; set; }
        public Sex Sex { get; set; }
        public AddressDto Address { get; set; }
        public List<AccountDto> Accounts { get; set; }
    }
}
