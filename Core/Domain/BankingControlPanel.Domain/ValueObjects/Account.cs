using BankingControlPanel.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Domain.ValueObjects
{
  
        public class Account
        {
            public Guid Id { get; private set; }
            public string AccountNumber { get; private set; }
            public string AccountType { get; private set; }
        public Guid ClientId { get; set; }

        public Account(string accountNumber, string accountType)
            {
                SetAccountNumber(accountNumber);
                SetAccountType(accountType);
            }

            public void SetAccountNumber(string accountNumber)
            {
                if (string.IsNullOrWhiteSpace(accountNumber))
                    throw new DomainException("Account number is required.");
                AccountNumber = accountNumber;
            }

            public void SetAccountType(string accountType)
            {
                if (string.IsNullOrWhiteSpace(accountType))
                    throw new DomainException("Account type is required.");
                AccountType = accountType;
            }
        }
    

}
