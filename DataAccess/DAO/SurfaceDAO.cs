using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class SurfaceDAO
    {
        public static List<Surface> GetSurfaces()
        {
            var listSurface = new List<Surface>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listSurface = context.Surfaces.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listSurface;
        }

        public static Surface FindSurface(Guid id)
        {
            Surface surface = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                surface = context.Surfaces.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return surface!;
        }

        public static void SaveSurface(Surface surface)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Surfaces.Add(surface);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateSurface(Surface surface)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(surface).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteSurface(Surface surface)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Surfaces.Remove(surface);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
