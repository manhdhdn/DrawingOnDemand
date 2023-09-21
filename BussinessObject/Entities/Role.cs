using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Role
    {
        public Role()
        {
            AccountRoles = new HashSet<AccountRole>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<AccountRole> AccountRoles { get; set; }
    }
}
