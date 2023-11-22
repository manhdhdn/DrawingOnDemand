using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class ArtworkReviewDAO
    {
        public static List<ArtworkReview> GetArtworkReviews()
        {
            var listArtworkReview = new List<ArtworkReview>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listArtworkReview = context.ArtworkReviews
                    .Include(ar => ar.Artwork)
                    .Include(ar => ar.CreatedByNavigation)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listArtworkReview;
        }

        public static ArtworkReview FindArtworkReview(Guid id)
        {
            ArtworkReview artworkReview = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                artworkReview = context.ArtworkReviews
                    .Include(ar => ar.Artwork)
                    .Include(ar => ar.CreatedByNavigation)
                    .Single(ar => ar.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return artworkReview!;
        }

        public static void SaveArtworkReview(ArtworkReview artworkReview)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.ArtworkReviews.Add(artworkReview);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateArtworkReview(ArtworkReview artworkReview)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(artworkReview).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteArtworkReview(ArtworkReview artworkReview)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.ArtworkReviews.Remove(artworkReview);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
