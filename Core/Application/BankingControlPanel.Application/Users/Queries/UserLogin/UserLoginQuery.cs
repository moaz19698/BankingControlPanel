using BankingControlPanel.Application.Clients.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Application.Clients.Queries.GetClientById
{
    public class UserLoginQuery : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
