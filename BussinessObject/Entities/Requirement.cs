using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Requirement
    {
        public Requirement()
        {
            Invites = new HashSet<Invite>();
            Proposals = new HashSet<Proposal>();
            Timelines = new HashSet<Timeline>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Image { get; set; }
        public int Pieces { get; set; }
        public decimal Budget { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string Status { get; set; } = null!;
        public Guid SizeId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid CreatedBy { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Account? CreatedByNavigation { get; set; }
        public virtual Size? Size { get; set; }
        public virtual ICollection<Invite> Invites { get; set; }
        public virtual ICollection<Proposal> Proposals { get; set; }
        public virtual ICollection<Timeline> Timelines { get; set; }
    }
}
