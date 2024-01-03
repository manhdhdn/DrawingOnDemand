using System;
using System.Collections.Generic;

namespace BusinessObject.Entities
{
    public partial class Account
    {
        public Account()
        {
            AccountReviewAccounts = new HashSet<AccountReview>();
            AccountReviewCreatedByNavigations = new HashSet<AccountReview>();
            AccountRoles = new HashSet<AccountRole>();
            ArtworkReviews = new HashSet<ArtworkReview>();
            Artworks = new HashSet<Artwork>();
            Certificates = new HashSet<Certificate>();
            Invites = new HashSet<Invite>();
            Orders = new HashSet<Order>();
            Proposals = new HashSet<Proposal>();
            Requirements = new HashSet<Requirement>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string? Avatar { get; set; }
        public string Address { get; set; }
        public string? Bio { get; set; }
        public int? AvailableConnect { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string Status { get; set; } = null!;
        public Guid? RankId { get; set; }

        public virtual Rank? Rank { get; set; }
        public virtual ICollection<AccountReview> AccountReviewAccounts { get; set; }
        public virtual ICollection<AccountReview> AccountReviewCreatedByNavigations { get; set; }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }
        public virtual ICollection<ArtworkReview> ArtworkReviews { get; set; }
        public virtual ICollection<Artwork> Artworks { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<Invite> Invites { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Proposal> Proposals { get; set; }
        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}
