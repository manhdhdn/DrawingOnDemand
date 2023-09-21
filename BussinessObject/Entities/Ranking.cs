using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Ranking
    {
        public Ranking()
        {
            Accounts = new HashSet<Account>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal TotaIncome { get; set; }
        public decimal TotalSpend { get; set; }

        public virtual Fee? Fee { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
