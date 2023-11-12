using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class SizeDAO
    {
        public static List<Size> GetSizes()
        {
            var listSize = new List<Size>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listSize = context.Sizes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listSize;
        }

        public static Size FindSize(Guid id)
        {
            Size size = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                size = context.Sizes.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return size!;
        }

        public static void SaveSize(Size size)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Sizes.Add(size);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateSize(Size size)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(size).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteSize(Size size)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Sizes.Remove(size);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
