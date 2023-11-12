using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class ArtworkReview
    {
        public Guid Id { get; set; }
        public int Star { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string Status { get; set; } = null!;
        public Guid CreatedBy { get; set; }
        public Guid ArtworkId { get; set; }

        public virtual Artwork? Artwork { get; set; }
        public virtual Account? CreatedByNavigation { get; set; } 
    }
}
