using BankingControlPanel.Domain.Entities;

namespace BankingControlPanel.Application.Clients.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserNameAsync(string userName);

        Task AddUserAsync(User user);

        Task<User> GetUserByEmailAsync(string email);
    }
}