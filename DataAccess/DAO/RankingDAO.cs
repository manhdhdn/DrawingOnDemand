using BusinessObject.Entities.Context;
using BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class RankingDAO
    {
        public static List<Ranking> GetRankings()
        {
            var listRanking = new List<Ranking>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listRanking = context.Rankings.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listRanking;
        }

        public static Ranking FindRanking(Guid id)
        {
            Ranking Ranking = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                Ranking = context.Rankings.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Ranking!;
        }

        public static void SaveRanking(Ranking ranking)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Rankings.Add(ranking);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateRanking(Ranking ranking)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(ranking).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteRanking(Ranking ranking)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Rankings.Remove(ranking);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
