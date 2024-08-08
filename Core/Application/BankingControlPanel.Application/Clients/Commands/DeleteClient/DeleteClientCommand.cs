using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Application.Clients.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest<Unit>
    {
        public DeleteClientCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
