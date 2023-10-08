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
    public class TimelineDAO
    {
        public static List<Timeline> GetTimelines()
        {
            var listTimeline = new List<Timeline>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listTimeline = context.Timelines.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listTimeline;
        }

        public static Timeline FindTimeline(Guid id)
        {
            Timeline Timeline = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                Timeline = context.Timelines.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Timeline!;
        }

        public static void SaveTimeline(Timeline timeline)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Timelines.Add(timeline);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateTimeline(Timeline timeline)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(timeline).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteTimeline(Timeline timeline)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Timelines.Remove(timeline);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
