using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class AccountReview
    {
        public Guid Id { get; set; }
        public int Star { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string Status { get; set; } = null!;
        public Guid CreatedBy { get; set; }
        public Guid AccountId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Account CreatedByNavigation { get; set; } = null!;
    }
}
