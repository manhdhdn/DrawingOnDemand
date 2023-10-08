using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class AttackmentDAO
    {
        public static List<Attackment> GetAttackments()
        {
            var listAttackment = new List<Attackment>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listAttackment = context.Attackments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listAttackment;
        }

        public static Attackment FindAttackment(Guid id)
        {
            Attackment attackment = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                attackment = context.Attackments.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return attackment!;
        }

        public static void SaveAttackment(Attackment attackment)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Attackments.Add(attackment);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateAttackment(Attackment attackment)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(attackment).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteAttackment(Attackment attackment)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Attackments.Remove(attackment);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
