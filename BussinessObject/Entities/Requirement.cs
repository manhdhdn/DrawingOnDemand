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
            Sizes = new HashSet<Size>();
            Steps = new HashSet<Step>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Image { get; set; }
        public int Quantity { get; set; }
        public int Pieces { get; set; }
        public decimal Budget { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string Status { get; set; } = null!;
        public Guid? CategoryId { get; set; }
        public Guid? SurfaceId { get; set; }
        public Guid? MaterialId { get; set; }
        public Guid? CreatedBy { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Account? CreatedByNavigation { get; set; }
        public virtual Material? Material { get; set; }
        public virtual Surface? Surface { get; set; }
        public virtual ICollection<Invite> Invites { get; set; }
        public virtual ICollection<Proposal> Proposals { get; set; }
        public virtual ICollection<Size> Sizes { get; set; }
        public virtual ICollection<Step> Steps { get; set; }
    }
}
