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
    public class RequirementDAO
    {
        public static List<Requirement> GetRequirements()
        {
            var listRequirement = new List<Requirement>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listRequirement = context.Requirements.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listRequirement;
        }

        public static Requirement FindRequirement(Guid id)
        {
            Requirement Requirement = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                Requirement = context.Requirements.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Requirement!;
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
