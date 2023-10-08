using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class HandOverDAO
    {
        public static List<HandOver> GetHandOvers()
        {
            var listHandOver = new List<HandOver>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listHandOver = context.HandOvers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listHandOver;
        }

        public static HandOver FindHandOver(Guid id)
        {
            HandOver handOver = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                handOver = context.HandOvers.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return handOver!;
        }

        public static void SaveHandOver(HandOver handOver)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.HandOvers.Add(handOver);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateHandOver(HandOver handOver)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(handOver).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteHandOver(HandOver handOver)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.HandOvers.Remove(handOver);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
