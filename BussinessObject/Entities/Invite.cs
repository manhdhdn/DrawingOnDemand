using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Invite
    {
        public Guid Id { get; set; }
        public string MeetingLink { get; set; } = null!;
        public string? Record { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; } = null!;
        public Guid RecivedBy { get; set; }
        public Guid RequirementId { get; set; }

        public virtual Account? RecivedByNavigation { get; set; }
        public virtual Requirement? Requirement { get; set; }
    }
}
