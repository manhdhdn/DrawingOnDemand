using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class AccountRole
    {
        public Guid Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string Status { get; set; } = null!;
        public Guid AccountId { get; set; }
        public Guid RoleId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
