using BankingControlPanel.Application.Clients.Repositories;
using BankingControlPanel.Application.Common.Exceptions;
using BankingControlPanel.Domain.DTOs.Clients;
using BankingControlPanel.Domain.Entities;
using BankingControlPanel.Domain.Repositories;
using BankingControlPanel.Infrastructure.Persistence.Mongo.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
