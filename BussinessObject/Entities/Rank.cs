using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Rank
    {
        public Rank()
        {
            Accounts = new HashSet<Account>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Income { get; set; }
        public decimal Spend { get; set; }
        public double Fee { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
