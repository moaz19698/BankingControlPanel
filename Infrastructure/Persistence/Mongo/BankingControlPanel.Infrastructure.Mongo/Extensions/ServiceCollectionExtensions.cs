using BankingControlPanel.Application.Clients.Repositories;
using BankingControlPanel.Domain.Repositories;
using BankingControlPanel.Infrastructure.Persistence.Mongo.Data;
using BankingControlPanel.Infrastructure.Persistence.Mongo.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Infrastructure.Persistence.Mongo.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
            services.AddSingleton(settings);

            services.AddSingleton<MongoDbContext>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            return services;
        }
    }
}
