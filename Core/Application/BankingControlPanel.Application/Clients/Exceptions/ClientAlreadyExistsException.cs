using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Application.Clients.Exceptions
{
    public class ClientAlreadyExistsException : Exception
    {
        public ClientAlreadyExistsException()
        {
        }

        public ClientAlreadyExistsException(string message)
            : base(message)
        {
        }

        public ClientAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
