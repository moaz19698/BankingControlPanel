using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Application.Users.Services
{
    public interface IUserService
    {
        Task RegisterAsync(string email, string password, string role);

    }
}
