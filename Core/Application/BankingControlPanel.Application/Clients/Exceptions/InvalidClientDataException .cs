﻿namespace BankingControlPanel.Application.Clients.Exceptions
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