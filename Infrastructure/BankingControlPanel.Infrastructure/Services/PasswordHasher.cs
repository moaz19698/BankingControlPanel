using BankingControlPanel.Application.Common.Interfaces;

namespace BankingControlPanel.Infrastructure.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            // Hash the password using a strong hashing algorithm (e.g., BCrypt)
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            // Verify the provided password against the stored hashed password
            return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
        }
    }
}