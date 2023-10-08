using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class DiscountBySpecialDAO
    {
        public static List<DiscountBySpecial> GetDiscountBySpecials()
        {
            var listDiscountBySpecial = new List<DiscountBySpecial>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listDiscountBySpecial = context.DiscountBySpecials.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listDiscountBySpecial;
        }

        public static DiscountBySpecial FindDiscountBySpecial(Guid id)
        {
            DiscountBySpecial discountBySpecial = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                discountBySpecial = context.DiscountBySpecials.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return discountBySpecial!;
        }

        public static void SaveDiscountBySpecial(DiscountBySpecial discountBySpecial)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.DiscountBySpecials.Add(discountBySpecial);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateDiscountBySpecial(DiscountBySpecial discountBySpecial)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(discountBySpecial).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteDiscountBySpecial(DiscountBySpecial discountBySpecial)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.DiscountBySpecials.Remove(discountBySpecial);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
