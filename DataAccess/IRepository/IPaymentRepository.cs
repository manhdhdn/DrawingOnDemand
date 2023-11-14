using BusinessObject.Entities;

namespace DataAccess.IRepository
{
    public interface IPaymentRepository
    {
        public List<Payment> GetPayments();
        public Payment GetPayment(Guid id);
        public void PutPayment(Payment payment);
        public void PostPayment(Payment payment);
        public void DeletePayment(Payment payment);
    }
}
