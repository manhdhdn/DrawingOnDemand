using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Proposal
    {
        public Guid Id { get; set; }
        public string Introduction { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string Status { get; set; } = null!;
        public Guid? RequirementId { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? ArtwordId { get; set; }

        public virtual Artwork? Artword { get; set; }
        public virtual Account? CreatedByNavigation { get; set; }
        public virtual Requirement? Requirement { get; set; };
    }
}
