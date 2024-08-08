using BankingControlPanel.Application.Clients.Queries.GetClientById;
using BankingControlPanel.Application.Clients.Repositories;
using BankingControlPanel.Application.Common.Interfaces;
using BankingControlPanel.Application.Users.Exceptions;
using MediatR;

namespace BankingControlPanel.Application.Users.Queries.UserLogin
{
    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public UserLoginQueryHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<string> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUserNameAsync(request.UserName);
            if (user == null || !_passwordHasher.VerifyPassword(user.PasswordHash, request.Password))
            {
                throw new InvalidCredentialsException("Invalid username or password.");
            }

            var token = _jwtTokenGenerator.GenerateToken(user.Id.ToString(), user.Email, user.Role.Name);
            return token;
        }
    }
}