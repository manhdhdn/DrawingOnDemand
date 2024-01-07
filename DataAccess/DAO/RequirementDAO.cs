using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class RequirementDAO
    {
        public static List<Requirement> GetRequirements()
        {
            var listRequirement = new List<Requirement>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listRequirement = context.Requirements
                    .Include(r => r.Category)
                    .Include(r => r.CreatedByNavigation)
                    .Include(r => r.Proposals)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listRequirement;
        }

        public static Requirement FindRequirement(Guid id)
        {
            Requirement requirement = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                requirement = context.Requirements
                    .Include(r => r.Category)
                    .Include(r => r.Surface)
                    .Include(r => r.Material)
                    .Include(r => r.CreatedByNavigation)
                    .Include(r => r.Proposals).ThenInclude(p => p.CreatedByNavigation)
                    .Include(r => r.Proposals).ThenInclude(p => p.Artwork).ThenInclude(aw => aw!.Arts)
                    .Include(r => r.Sizes)
                    .Include(r => r.Steps)
                    .SingleOrDefault(r => r.Id == id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return requirement!;
        }

        public static void SaveRequirement(Requirement requirement)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Requirements.Add(requirement);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateRequirement(Requirement requirement)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(requirement).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteRequirement(Requirement requirement)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Requirements.Remove(requirement);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
