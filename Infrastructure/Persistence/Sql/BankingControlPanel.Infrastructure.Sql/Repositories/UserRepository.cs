using BankingControlPanel.Application.Clients.Repositories;
using BankingControlPanel.Domain.Entities;
using BankingControlPanel.Infrastructure.Persistence.Sql.Data;
using Microsoft.EntityFrameworkCore;

namespace BankingControlPanel.Infrastructure.Persistence.Sql.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users.Include(user => user.Role).FirstOrDefaultAsync(client => client.UserName == userName);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.Include(user => user.Role).FirstOrDefaultAsync(client => client.Email == email);
        }
    }
}