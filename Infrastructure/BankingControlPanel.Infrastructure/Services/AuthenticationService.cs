using BankingControlPanel.Application.Clients.Repositories;
using BankingControlPanel.Application.Common.Exceptions;
using BankingControlPanel.Application.Common.Interfaces;

namespace BankingControlPanel.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(
            IJwtTokenGenerator tokenGenerator,
            IUserRepository userRepository,
            IPasswordHasher passwordHasher)
        {
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> AuthenticateAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null || !_passwordHasher.VerifyPassword(user.PasswordHash, password))
            {
                throw new UnauthorizedException("Invalid credentials.");
            }

            // Generate JWT token
            return _tokenGenerator.GenerateToken(user.Id.ToString(), user.Email, user.Role.Name);
        }
    }
}