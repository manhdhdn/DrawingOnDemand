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
        public decimal IncomeRequire { get; set; }
        public decimal SpendRequire { get; set; }
        public double Fee { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
