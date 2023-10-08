using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class FeeDAO
    {
        public static List<Fee> GetFees()
        {
            var listFee = new List<Fee>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listFee = context.Fees.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listFee;
        }

        public static Fee FindFee(Guid id)
        {
            Fee fee = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                fee = context.Fees.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return fee!;
        }

        public static void SaveFee(Fee fee)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Fees.Add(fee);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateFee(Fee fee)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(fee).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteFee(Fee fee)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Fees.Remove(fee);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
