namespace BankingControlPanel.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        // Foreign key and navigation property for role
        public Guid RoleId { get; private set; }

        public virtual Role Role { get; private set; }

        // Constructor
        public User()
        {
        }

        public User(string userName, string email, string passwordHash, string firstName, string lastName, Guid roleId)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
            RoleId = roleId;
        }

        // Methods to update properties
        public void UpdateUserName(string userName)
        {
            UserName = userName;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }

        public void UpdatePasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
        }

        public void UpdateFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public void UpdateLastName(string lastName)
        {
            LastName = lastName;
        }

        public void UpdateRole(Role role)
        {
            Role = role;
            RoleId = role.Id;
        }
    }
}