
using BankingControlPanel.Application.Common.Interfaces;
using BankingControlPanel.Infrastructure.Persistence.Mongo.Extensions;
using BankingControlPanel.Infrastructure.Persistence.Sql.Extensions;
using BankingControlPanel.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            
            // Conditional Repositories
            if (true)
            {
                services.AddSqlPersistence(configuration);
            }
            else
            {
                services.AddMongoPersistence(configuration);
            }
            //services.AddScoped<JwtTokenGenerator>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IJwtTokenGenerator,JwtTokenGenerator>();
            services.AddScoped<IPasswordHasher,PasswordHasher>();
            
            return services;
        }
    }

}
