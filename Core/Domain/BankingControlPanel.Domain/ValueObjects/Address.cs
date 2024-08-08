using BankingControlPanel.Domain.Exceptions;

namespace BankingControlPanel.Domain.ValueObjects
{
    public class Address
    {
        public string Country { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string ZipCode { get; private set; }

        public Address(string country, string city, string street, string zipCode)
        {
            SetCountry(country);
            SetCity(city);
            SetStreet(street);
            SetZipCode(zipCode);
        }

        public void SetCountry(string country)
        {
            if (string.IsNullOrWhiteSpace(country))
                throw new DomainException("Country is required.");
            Country = country;
        }

        public void SetCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new DomainException("City is required.");
            City = city;
        }

        public void SetStreet(string street)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new DomainException("Street is required.");
            Street = street;
        }

        public void SetZipCode(string zipCode)
        {
            if (string.IsNullOrWhiteSpace(zipCode))
                throw new DomainException("Zip code is required.");
            ZipCode = zipCode;
        }
    }
}