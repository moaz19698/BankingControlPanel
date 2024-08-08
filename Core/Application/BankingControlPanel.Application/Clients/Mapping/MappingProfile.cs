using AutoMapper;
using BankingControlPanel.Application.Clients.Dtos;
using BankingControlPanel.Domain.Entities;
using BankingControlPanel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Application.Clients.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to DTO
            CreateMap<Client, ClientDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Account, AccountDto>();

            // DTO to Domain
            CreateMap<ClientDto, Client>()
                .ConstructUsing(c => new Client(
                    c.Email,
                    c.FirstName,
                    c.LastName,
                    c.PersonalId,
                    c.ProfilePhoto,
                    c.MobileNumber,
                    c.Sex,
                    new Address(c.Address.Country, c.Address.City, c.Address.Street, c.Address.ZipCode),
                    c.Accounts.Select(a => new Account(a.AccountNumber, a.AccountType)).ToList()
                ));
            CreateMap<AddressDto, Address>();
            CreateMap<AccountDto, Account>();
        }
    }
}
