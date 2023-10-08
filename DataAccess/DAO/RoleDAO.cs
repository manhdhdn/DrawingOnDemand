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
            Role Role = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                Role = context.Roles.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Role!;
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
