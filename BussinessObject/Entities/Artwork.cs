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
            OrderDetails = new HashSet<OrderDetail>();
            Sizes = new HashSet<Size>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Pieces { get; set; }
        public int InStock { get; set; }
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
        public virtual Proposal? Proposal { get; set; }
        public virtual ICollection<Art> Arts { get; set; }
        public virtual ICollection<ArtworkReview> ArtworkReviews { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Size> Sizes { get; set; }
    }
}
