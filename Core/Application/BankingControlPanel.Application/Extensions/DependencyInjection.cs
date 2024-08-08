using BankingControlPanel.Application.Clients.Commands.CreateClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // Conditional Repositories
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateClientCommand).Assembly));
            return services;
        }
    }

}
