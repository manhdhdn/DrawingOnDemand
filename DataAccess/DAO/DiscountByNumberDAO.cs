using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class DiscountByNumberDAO
    {
        public static List<DiscountByNumber> GetDiscountByNumbers()
        {
            var listDiscountByNumber = new List<DiscountByNumber>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listDiscountByNumber = context.DiscountByNumbers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listDiscountByNumber;
        }

        public static DiscountByNumber FindDiscountByNumber(Guid id)
        {
            DiscountByNumber discountByNumber = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                discountByNumber = context.DiscountByNumbers.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return discountByNumber!;
        }

        public static void SaveDiscountByNumber(DiscountByNumber discountByNumber)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.DiscountByNumbers.Add(discountByNumber);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateDiscountByNumber(DiscountByNumber discountByNumber)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(discountByNumber).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteDiscountByNumber(DiscountByNumber discountByNumber)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.DiscountByNumbers.Remove(discountByNumber);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
