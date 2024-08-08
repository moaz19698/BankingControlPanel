using BankingControlPanel.Domain.Entities;
using MongoDB.Driver;

namespace BankingControlPanel.Infrastructure.Persistence.Mongo.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(MongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<Client> Clients => _database.GetCollection<Client>("Clients");
    }
}