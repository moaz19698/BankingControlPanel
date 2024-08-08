using BankingControlPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Domain.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleByNameAsync(string roleName);
    }
}
