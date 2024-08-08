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
