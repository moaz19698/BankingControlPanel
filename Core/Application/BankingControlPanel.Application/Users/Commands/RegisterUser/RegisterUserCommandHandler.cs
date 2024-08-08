using BankingControlPanel.Application.Clients.Repositories;
using BankingControlPanel.Application.Common.Exceptions;
using BankingControlPanel.Application.Common.Interfaces;
using BankingControlPanel.Application.Users.Exceptions;
using BankingControlPanel.Domain.Entities;
using BankingControlPanel.Domain.Repositories;
using MediatR;

namespace BankingControlPanel.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // Check if a user with the same username or email already exists
            var existingUser = await _userRepository.GetUserByUserNameAsync(request.UserName);
            if (existingUser != null)
            {
                throw new UserAlreadyExistsException("A user with this username already exists.");
            }

            var existingEmailUser = await _userRepository.GetUserByEmailAsync(request.Email);
            if (existingEmailUser != null)
            {
                throw new UserAlreadyExistsException("A user with this email already exists.");
            }
            var role = await _roleRepository.GetRoleByNameAsync(request.Role);
            if (role == null)
            {
                throw new NotFoundException("Role not found.");
            }

            var user = new User(
                request.UserName,
                request.Email,
                _passwordHasher.HashPassword(request.Password),
                request.FirstName,
                request.LastName,
                role.Id
            );

            await _userRepository.AddUserAsync(user);
            return user.Id;
        }
    }
}