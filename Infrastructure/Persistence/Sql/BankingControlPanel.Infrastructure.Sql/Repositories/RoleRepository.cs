using BankingControlPanel.Application.Clients.Repositories;
using BankingControlPanel.Application.Common.Exceptions;
using BankingControlPanel.Domain.DTOs.Clients;
using BankingControlPanel.Domain.Entities;
using BankingControlPanel.Domain.Repositories;
using BankingControlPanel.Infrastructure.Persistence.Sql.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Infrastructure.Persistence.Sql.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(role => role.Name == roleName);
        }
    }


}
