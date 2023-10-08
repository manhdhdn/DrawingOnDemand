using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class PaymentDAO
    {
        public static List<Payment> GetPayments()
        {
            var listPayment = new List<Payment>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listPayment = context.Payments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listPayment;
        }

        public static Payment FindPayment(Guid id)
        {
            Payment payment = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                payment = context.Payments.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return payment!;
        }

        public static void SavePayment(Payment payment)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Payments.Add(payment);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdatePayment(Payment payment)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(payment).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeletePayment(Payment payment)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Payments.Remove(payment);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
