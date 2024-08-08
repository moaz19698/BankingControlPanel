using BankingControlPanel.Application.Common.Exceptions;
using BankingControlPanel.Domain.DTOs.Clients;
using BankingControlPanel.Domain.Entities;
using BankingControlPanel.Domain.Repositories;
using BankingControlPanel.Infrastructure.Persistence.Sql.Data;
using Microsoft.EntityFrameworkCore;

namespace BankingControlPanel.Infrastructure.Persistence.Sql.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            return await _context.Clients
                                 .Include(c => c.Accounts)  // Eager load related Accounts
                                 .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Client>> GetClientsAsync(ClientFilterDto filter)
        {
            var query = _context.Clients.AsQueryable();

            // Apply search filter if provided
            if (!string.IsNullOrEmpty(filter.SearchTerm))
            {
                query = query.Where(c => c.FirstName.Contains(filter.SearchTerm) ||
                                         c.LastName.Contains(filter.SearchTerm) ||
                                         c.Email.Contains(filter.SearchTerm) ||
                                         c.MobileNumber.Contains(filter.SearchTerm));
            }

            // Apply sorting
            if (!string.IsNullOrEmpty(filter.SortBy))
            {
                query = filter.IsAscending ? query.OrderByProperty(filter.SortBy) : query.OrderByPropertyDescending(filter.SortBy);
            }

            // Apply pagination
            if (filter.PageIndex > 0 && filter.PageSize > 0)
            {
                query = query.Skip((filter.PageIndex - 1) * filter.PageSize).Take(filter.PageSize);
            }

            return await query.Include(c => c.Accounts).ToListAsync();
        }

        public async Task AddAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Client client)
        {
            var existingClient = await _context.Clients.Include(c => c.Accounts).FirstOrDefaultAsync(c => c.Id == client.Id);
            if (existingClient == null)
            {
                throw new NotFoundException("Client not found.");
            }

            // Update the fields of the existing client
            existingClient.SetEmail(client.Email);
            existingClient.SetFirstName(client.FirstName);
            existingClient.SetLastName(client.LastName);
            existingClient.SetProfilePhoto(client.ProfilePhoto);
            existingClient.SetMobileNumber(client.MobileNumber);
            existingClient.SetSex(client.Sex);
            existingClient.SetAddress(client.Address);
            existingClient.SetAccounts(client.Accounts);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                throw new NotFoundException("Client not found.");
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> GetClientByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return Enumerable.Empty<Client>();
            }

            return await _context.Clients
                .Where(client => client.Email == email)
                .ToListAsync();
        }
    }

    // Helper method for dynamic sorting
    public static class IQueryableExtensions
    {
        public static IQueryable<T> OrderByProperty<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderBy(GetPropertyLambda<T>(propertyName));
        }

        public static IQueryable<T> OrderByPropertyDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderByDescending(GetPropertyLambda<T>(propertyName));
        }

        private static System.Linq.Expressions.Expression<System.Func<T, object>> GetPropertyLambda<T>(string propertyName)
        {
            var parameter = System.Linq.Expressions.Expression.Parameter(typeof(T), "p");
            var property = System.Linq.Expressions.Expression.Property(parameter, propertyName);
            var convert = System.Linq.Expressions.Expression.Convert(property, typeof(object));

            return System.Linq.Expressions.Expression.Lambda<System.Func<T, object>>(convert, parameter);
        }
    }
}