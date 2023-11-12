using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Invite
    {
        public Guid Id { get; set; }
        public decimal Cost { get; set; }
        public string MeetingLink { get; set; } = null!;
        public DateTime MeetingDate { get; set; }
        public string? Record { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; } = null!;
        public Guid ReceivedBy { get; set; }
        public Guid RequirementId { get; set; }

        public virtual Account? ReceivedByNavigation { get; set; } 
        public virtual Requirement? Requirement { get; set; }
    }
}
