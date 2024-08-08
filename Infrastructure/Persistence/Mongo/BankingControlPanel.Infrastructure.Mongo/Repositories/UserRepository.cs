using BankingControlPanel.Application.Clients.Repositories;
using BankingControlPanel.Domain.Entities;
using MongoDB.Driver;

namespace BankingControlPanel.Infrastructure.Persistence.Mongo.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IMongoDatabase context)
        {
            _users = context.GetCollection<User>("Users");
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            var filter = Builders<User>.Filter.Eq(user => user.UserName, userName);
            return await _users.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _users.InsertOneAsync(user);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var filter = Builders<User>.Filter.Eq(user => user.Email, email);
            return await _users.Find(filter).FirstOrDefaultAsync();
        }
    }
}