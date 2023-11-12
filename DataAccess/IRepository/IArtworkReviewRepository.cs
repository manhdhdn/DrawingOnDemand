using BusinessObject.Entities;

namespace DataAccess.IRepository
{
    public interface IArtworkReviewRepository
    {
        public List<ArtworkReview> GetArtworkReviews();
        public ArtworkReview GetArtworkReview(Guid id);
        public void PutArtworkReview(ArtworkReview artworkReview);
        public void PostArtworkReview(ArtworkReview artworkReview);
        public void DeleteArtworkReview(ArtworkReview artworkReview);
    }
}
