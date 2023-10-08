using BusinessObject.Entities;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IPaymentRepository
    {
        public List<Payment> GetPayments();
        public Payment GetPayment(Guid id);
        public void PutPayment(Payment payment);
        public void PostPayment(Payment payment) => PaymentDAO.SavePayment(payment);
        public void DeletePayment(Payment payment);
    }
}
