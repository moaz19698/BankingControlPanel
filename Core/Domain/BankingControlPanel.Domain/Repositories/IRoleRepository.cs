using BankingControlPanel.Domain.Entities;

namespace BankingControlPanel.Domain.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleByNameAsync(string roleName);
    }
}