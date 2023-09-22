using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Fee
    {
        public Guid Id { get; set; }
        public double Fee1 { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public Guid RankId { get; set; }

        public virtual Ranking? Rank { get; set; }
    }
}
