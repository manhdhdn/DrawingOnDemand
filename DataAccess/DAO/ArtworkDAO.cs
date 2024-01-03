using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class ArtworkDAO
    {
        public static List<Artwork> GetArtworks()
        {
            var listArtwork = new List<Artwork>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listArtwork = context.Artworks
                    .Include(aw => aw.Arts)
                    .Include(aw => aw.CreatedByNavigation).ThenInclude(a => a!.Rank)
                    .Include(aw => aw.ArtworkReviews)
                    .Include(aw => aw.Category)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listArtwork;
        }

        public static Artwork FindArtwork(Guid id)
        {
            Artwork artwork = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                artwork = context.Artworks
                    .Include(aw => aw.Arts)
                    .Include(aw => aw.CreatedByNavigation).ThenInclude(a => a!.Rank)
                    .Include(aw => aw.ArtworkReviews).ThenInclude(ar => ar.CreatedByNavigation)
                    .Include(aw => aw.Category)
                    .Include(aw => aw.Surface)
                    .Include(aw => aw.Material)
                    .SingleOrDefault(aw => aw.Id == id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return artwork!;
        }

        public static void SaveArtwork(Artwork artwork)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Artworks.Add(artwork);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateArtwork(Artwork artwork)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(artwork).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteArtwork(Artwork artwork)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Artworks.Remove(artwork);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
