using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class InviteDAO
    {
        public static List<Invite> GetInvites()
        {
            var listInvite = new List<Invite>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listInvite = context.Invites
                    .Include(i => i.Requirement).ThenInclude(r => r!.Category)
                    .Include(i => i.Requirement).ThenInclude(r => r!.CreatedByNavigation)
                    .Include(i => i.Requirement).ThenInclude(r => r!.Proposals)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listInvite;
        }

        public static Invite FindInvite(Guid id)
        {
            Invite invite = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                invite = context.Invites
                    .Include(i => i.Requirement).ThenInclude(r => r!.Category)
                    .Include(i => i.Requirement).ThenInclude(r => r!.Surface)
                    .Include(i => i.Requirement).ThenInclude(r => r!.Material)
                    .Include(i => i.Requirement).ThenInclude(r => r!.CreatedByNavigation)
                    .Include(i => i.Requirement).ThenInclude(r => r!.Sizes)
                    .SingleOrDefault(i => i.Id == id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return invite!;
        }

        public static void SaveInvite(Invite invite)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Invites.Add(invite);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateInvite(Invite invite)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(invite).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteInvite(Invite invite)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Invites.Remove(invite);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
