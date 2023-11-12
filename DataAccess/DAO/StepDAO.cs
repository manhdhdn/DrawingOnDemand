using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class StepDAO
    {
        public static List<Step> GetSteps()
        {
            var listStep = new List<Step>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listStep = context.Steps.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listStep;
        }

        public static Step FindStep(Guid id)
        {
            Step step = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                step = context.Steps.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return step!;
        }

        public static void SaveStep(Step step)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Steps.Add(step);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateStep(Step step)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(step).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteStep(Step step)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Steps.Remove(step);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
