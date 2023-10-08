using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class ArtDAO
    {
        public static List<Art> GetArts()
        {
            var listArt = new List<Art>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listArt = context.Arts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listArt;
        }

        public static Art FindArt(Guid id)
        {
            Art art = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                art = context.Arts.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return art!;
        }

        public static void SaveArt(Art art)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Arts.Add(art);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateArt(Art art)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(art).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteArt(Art art)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Arts.Remove(art);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
