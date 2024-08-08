using BankingControlPanel.Domain.Enums;
using BankingControlPanel.Domain.Exceptions;
using BankingControlPanel.Domain.ValueObjects;

namespace BankingControlPanel.Domain.Entities
{
    public class Client
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }

        public string FirstName
        {
            get; private set
            ;
        }

        public string LastName { get; private set; }
        public string PersonalId { get; private set; }
        public string ProfilePhoto { get; private set; }
        public string MobileNumber { get; private set; }
        public Sex Sex { get; private set; }
        public Address Address { get; private set; }
        public List<Account> Accounts { get; private set; }

        private Client()
        { } // EF Core constructor

        public Client(string email, string firstName, string lastName, string personalId, string profilePhoto, string mobileNumber, Sex sex, Address address, List<Account> accounts)
        {
            SetEmail(email);
            SetFirstName(firstName);
            SetLastName(lastName);
            SetPersonalId(personalId);
            SetProfilePhoto(profilePhoto);
            SetMobileNumber(mobileNumber);
            SetSex(sex);
            SetAddress(address);
            SetAccounts(accounts);
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
                throw new DomainException("Invalid email format.");
            Email = email;
        }

        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > 60)
                throw new DomainException("First name is required and must be less than 60 characters.");
            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > 60)
                throw new DomainException("Last name is required and must be less than 60 characters.");
            LastName = lastName;
        }

        public void SetPersonalId(string personalId)
        {
            if (string.IsNullOrWhiteSpace(personalId) || personalId.Length != 11)
                throw new DomainException("Personal Id is required and must be exactly 11 characters.");
            PersonalId = personalId;
        }

        public void SetProfilePhoto(string profilePhoto)
        {
            ProfilePhoto = profilePhoto;
        }

        public void SetMobileNumber(string mobileNumber)
        {
            if (string.IsNullOrWhiteSpace(mobileNumber) || !IsValidMobileNumber(mobileNumber))
                throw new DomainException("Invalid mobile number format.");
            MobileNumber = mobileNumber;
        }

        public void SetSex(Sex sex)
        {
            if (!Enum.IsDefined(typeof(Sex), sex))
                throw new DomainException("Invalid sex value.");
            Sex = sex;
        }

        public void SetAddress(Address address)
        {
            Address = address ?? throw new DomainException("Address is required.");
        }

        public void SetAccounts(List<Account> accounts)
        {
            if (accounts == null || accounts.Count == 0)
                throw new DomainException("At least one account is required.");
            Accounts = accounts;
        }

        private bool IsValidEmail(string email) =>
            new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(email);

        private bool IsValidMobileNumber(string mobileNumber) =>
            System.Text.RegularExpressions.Regex.IsMatch(mobileNumber, @"^\+[1-9]\d{1,14}$");
    }
}