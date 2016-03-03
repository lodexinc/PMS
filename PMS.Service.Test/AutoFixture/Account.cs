using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Service.Test
{
    public class Account : IEntity
    {
        public Account(Guid ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }

        public Guid ID { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public AccountType Type { get; set; }
        public Roles Roles { get; set; }
    }

    [Flags]
    public enum Roles
    {
        Guest = 1,
        User = 2,
        Editor = 4,
        Administrator = 8
    }

    public enum AccountType
    {
        Private,
        Public,
        Current,
        Saving
    }
}
