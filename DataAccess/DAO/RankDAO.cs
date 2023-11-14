using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class RankDAO
    {
        public static List<Rank> GetRanks()
        {
            var listRank = new List<Rank>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listRank = context.Ranks.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listRank;
        }

        public static Rank FindRank(Guid id)
        {
            Rank rank = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                rank = context.Ranks.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return rank!;
        }

        public static void SaveRank(Rank rank)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Ranks.Add(rank);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateRank(Rank rank)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(rank).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteRank(Rank rank)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Ranks.Remove(rank);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
