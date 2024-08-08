using BankingControlPanel.Domain.Entities;
using BankingControlPanel.Domain.Enums;
using BankingControlPanel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Domain.Aggregates
{

   
        public class ClientAggregate
        {
            public Client Client { get; private set; }

            public ClientAggregate(Client client)
            {
                Client = client ?? throw new ArgumentNullException(nameof(client));
            }

            // Method to update client details
            public void UpdateClientDetails(string email, string firstName, string lastName, string profilePhoto, string mobileNumber, Sex sex, Address address)
            {
                ValidateClientDetails(email, firstName, lastName, mobileNumber, sex);
                Client.SetEmail(email);
                Client.SetFirstName(firstName);
                Client.SetLastName(lastName);
                Client.SetProfilePhoto(profilePhoto);
                Client.SetMobileNumber(mobileNumber);
                Client.SetSex(sex);
                Client.SetAddress(address);
            }

            // Method to add a new account
            public void AddAccount(string accountNumber, string accountType)
            {
                var account = new Account(accountNumber, accountType);
                Client.SetAccounts(Client.Accounts.Append(account).ToList());
            }

            // Method to remove an account
            public void RemoveAccount(Guid accountId)
            {
                var accountToRemove = Client.Accounts.SingleOrDefault(a => a.Id == accountId);
                if (accountToRemove == null)
                    throw new InvalidOperationException("Account not found.");

                var updatedAccounts = Client.Accounts.Where(a => a.Id != accountId).ToList();
                Client.SetAccounts(updatedAccounts);
            }

            // Method to change address
            public void ChangeAddress(Address newAddress)
            {
                Client.SetAddress(newAddress);
            }

            // Method to validate client details
            private void ValidateClientDetails(string email, string firstName, string lastName, string mobileNumber, Sex sex)
            {
                if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
                    throw new InvalidOperationException("Invalid email format.");
                if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > 60)
                    throw new InvalidOperationException("First name is required and must be less than 60 characters.");
                if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > 60)
                    throw new InvalidOperationException("Last name is required and must be less than 60 characters.");
                if (string.IsNullOrWhiteSpace(mobileNumber) || !IsValidMobileNumber(mobileNumber))
                    throw new InvalidOperationException("Invalid mobile number format.");
                if (!Enum.IsDefined(typeof(Sex), sex))
                    throw new InvalidOperationException("Invalid sex value.");
            }

            private bool IsValidEmail(string email) =>
                new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(email);

            private bool IsValidMobileNumber(string mobileNumber) =>
                System.Text.RegularExpressions.Regex.IsMatch(mobileNumber, @"^\+\d{1,3}\d{10}$");
        }
    

}