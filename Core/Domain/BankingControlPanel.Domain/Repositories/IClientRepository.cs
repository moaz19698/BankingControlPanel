using BankingControlPanel.Domain.DTOs.Clients;
using BankingControlPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(Guid id);
        Task<IEnumerable<Client>> GetClientsAsync(ClientFilterDto filter);
        Task AddAsync(Client client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Client>> GetClientByEmailAsync(string email);
    }
}
