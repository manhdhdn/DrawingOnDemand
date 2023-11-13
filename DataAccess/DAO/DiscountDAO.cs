using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class DiscountDAO
    {
        public static List<Discount> GetDiscounts()
        {
            var listDiscount = new List<Discount>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listDiscount = context.Discounts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listDiscount;
        }

        public static Discount FindDiscount(Guid id)
        {
            Discount discount = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                discount = context.Discounts.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return discount!;
        }

        public static void SaveDiscount(Discount discount)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Discounts.Add(discount);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateDiscount(Discount discount)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(discount).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteDiscount(Discount discount)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Discounts.Remove(discount);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
