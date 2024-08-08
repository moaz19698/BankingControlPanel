using BankingControlPanel.Domain.DTOs.Clients;
using BankingControlPanel.Domain.Entities;

namespace BankingControlPanel.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(Guid id);

        Task<IEnumerable<Client>> GetClientsAsync(ClientFilterDto filter);

        Task AddAsync(Client client);

        Task UpdateAsync(Client client);

        Task DeleteAsync(Guid id);

        Task<Client> GetClientByEmailAsync(string email);
    }
}