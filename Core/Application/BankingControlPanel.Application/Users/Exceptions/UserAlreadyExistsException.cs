using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Application.Users.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException()
        {
        }

        public UserAlreadyExistsException(string message)
            : base(message)
        {
        }

        public UserAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
