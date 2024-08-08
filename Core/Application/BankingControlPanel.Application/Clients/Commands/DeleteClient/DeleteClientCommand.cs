using MediatR;

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