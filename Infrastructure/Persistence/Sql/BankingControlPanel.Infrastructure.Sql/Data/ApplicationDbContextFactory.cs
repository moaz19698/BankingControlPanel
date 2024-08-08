using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Infrastructure.Persistence.Sql.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=.\\SQLSERVER;Database=BankingControlPanel;Persist Security Info=True;User Id=sa;Password=1qaz!QAZ;TrustServerCertificate=True;MultipleActiveResultSets=True;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
