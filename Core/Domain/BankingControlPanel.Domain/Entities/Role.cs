using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Domain.Entities
{
    public class Role
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        // Navigation property for related users
        public virtual ICollection<User> Users { get; private set; }

        // Constructor
        public Role(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Users = new List<User>();
        }
        public Role(Guid id,string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            Users = new List<User>();
        }

        // Methods to update properties
        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }
    }
}
