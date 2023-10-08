using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class HandOverItemDAO
    {
        public static List<HandOverItem> GetHandOverItems()
        {
            var listHandOverItem = new List<HandOverItem>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listHandOverItem = context.HandOverItems.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listHandOverItem;
        }

        public static HandOverItem FindHandOverItem(Guid id)
        {
            HandOverItem handOverItem = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                handOverItem = context.HandOverItems.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return handOverItem!;
        }

        public static void SaveHandOverItem(HandOverItem handOverItem)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.HandOverItems.Add(handOverItem);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateHandOverItem(HandOverItem handOverItem)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(handOverItem).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteHandOverItem(HandOverItem handOverItem)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.HandOverItems.Remove(handOverItem);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
