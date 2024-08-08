using BankingControlPanel.Application.Common.Exceptions;
using BankingControlPanel.Domain.DTOs.Clients;
using BankingControlPanel.Domain.Entities;
using BankingControlPanel.Domain.Repositories;
using MongoDB.Driver;

namespace BankingControlPanel.Infrastructure.Persistence.Mongo.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IMongoCollection<Client> _clients;

        public ClientRepository(IMongoDatabase context)
        {
            _clients = context.GetCollection<Client>("Clients");
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            return await _clients
                                 .Find(client => client.Id == id)
                                 .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Client>> GetClientsAsync(ClientFilterDto filter)
        {
            var filterDefinition = Builders<Client>.Filter.Empty;

            if (!string.IsNullOrEmpty(filter.SearchTerm))
            {
                filterDefinition = Builders<Client>.Filter.Or(
                    Builders<Client>.Filter.Regex(c => c.FirstName, new MongoDB.Bson.BsonRegularExpression(filter.SearchTerm, "i")),
                    Builders<Client>.Filter.Regex(c => c.LastName, new MongoDB.Bson.BsonRegularExpression(filter.SearchTerm, "i")),
                    Builders<Client>.Filter.Regex(c => c.Email, new MongoDB.Bson.BsonRegularExpression(filter.SearchTerm, "i")),
                    Builders<Client>.Filter.Regex(c => c.MobileNumber, new MongoDB.Bson.BsonRegularExpression(filter.SearchTerm, "i"))
                );
            }

            var sortDefinition = filter.IsAscending
                ? Builders<Client>.Sort.Ascending(filter.SortBy)
                : Builders<Client>.Sort.Descending(filter.SortBy);

            return await _clients
                                 .Find(filterDefinition)
                                 .Sort(sortDefinition)
                                 .Skip((filter.PageIndex - 1) * filter.PageSize)
                                 .Limit(filter.PageSize)
                                 .ToListAsync();
        }

        public async Task AddAsync(Client client)
        {
            await _clients.InsertOneAsync(client);
        }

        public async Task UpdateAsync(Client client)
        {
            var result = await _clients.ReplaceOneAsync(c => c.Id == client.Id, client);

            if (result.MatchedCount == 0)
            {
                throw new NotFoundException("Client not found.");
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var result = await _clients.DeleteOneAsync(client => client.Id == id);

            if (result.DeletedCount == 0)
            {
                throw new NotFoundException("Client not found.");
            }
        }

        public async Task<Client> GetClientByEmailAsync(string email)
        {
            var filter = Builders<Client>.Filter.Eq(client => client.Email, email);
            return await _clients.Find(filter).FirstOrDefaultAsync();
        }
    }
}