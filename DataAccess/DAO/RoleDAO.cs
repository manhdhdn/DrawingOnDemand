using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class RoleDAO
    {
        public static List<Role> GetRoles()
        {
            var listRole = new List<Role>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listRole = context.Roles.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listRole;
        }

        public static Role FindRole(Guid id)
        {
            Role role = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                role = context.Roles.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return role!;
        }

        public static void SaveRole(Role role)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Roles.Add(role);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateRole(Role role)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(role).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteRole(Role role)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Roles.Remove(role);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
