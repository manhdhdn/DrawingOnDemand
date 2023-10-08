using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Artwork
    {
        public Artwork()
        {
            Arts = new HashSet<Art>();
            ArtworkReviews = new HashSet<ArtworkReview>();
            HandOverItems = new HashSet<HandOverItem>();
            OrderDetails = new HashSet<OrderDetail>();
            Proposals = new HashSet<Proposal>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Pieces { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string Status { get; set; } = null!;
        public Guid CreatedBy { get; set; }
        public Guid CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Account? CreatedByNavigation { get; set; }
        public virtual ICollection<Art> Arts { get; set; }
        public virtual ICollection<ArtworkReview> ArtworkReviews { get; set; }
        public virtual ICollection<HandOverItem> HandOverItems { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Proposal> Proposals { get; set; }
    }
}
