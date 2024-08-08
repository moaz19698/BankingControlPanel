using BankingControlPanel.Domain.Entities;
using BankingControlPanel.Domain.Repositories;
using MongoDB.Driver;

namespace BankingControlPanel.Infrastructure.Persistence.Mongo.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IMongoCollection<Role> _roles;

        public RoleRepository(IMongoDatabase context)
        {
            _roles = context.GetCollection<Role>("Roles");
        }

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            var filter = Builders<Role>.Filter.Eq(role => role.Name.ToLower(), roleName);
            return await _roles.Find(filter).FirstOrDefaultAsync();
        }
    }
}