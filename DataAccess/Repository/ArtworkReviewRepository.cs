using BusinessObject.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;

namespace DataAccess.Repository
{
    public class ArtworkReviewRepository : IArtworkReviewRepository
    {
        public List<ArtworkReview> GetArtworkReviews() => ArtworkReviewDAO.GetArtworkReviews();
        public ArtworkReview GetArtworkReview(Guid id) => ArtworkReviewDAO.FindArtworkReview(id);
        public void PutArtworkReview(ArtworkReview artworkReview) => ArtworkReviewDAO.UpdateArtworkReview(artworkReview);
        public void PostArtworkReview(ArtworkReview artworkReview) => ArtworkReviewDAO.SaveArtworkReview(artworkReview);
        public void DeleteArtworkReview(ArtworkReview artworkReview) => ArtworkReviewDAO.DeleteArtworkReview(artworkReview);
    }
}
