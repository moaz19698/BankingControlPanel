using BankingControlPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Application.Clients.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserNameAsync(string userName);
        Task AddUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
    }
}
