using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Domain.Events
{
    public class ClientCreatedEvent
    {
        public Guid ClientId { get; }
        public DateTime CreatedAt { get; }

        public ClientCreatedEvent(Guid clientId, DateTime createdAt)
        {
            ClientId = clientId;
            CreatedAt = createdAt;
        }
    }
}
