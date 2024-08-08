﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Application.Clients.Exceptions
{
    public class InvalidClientDataException : Exception
    {
        public InvalidClientDataException()
        {
        }

        public InvalidClientDataException(string message)
            : base(message)
        {
        }

        public InvalidClientDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
