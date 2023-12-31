﻿using BusinessObject.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;

namespace DataAccess.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        public List<Payment> GetPayments() => PaymentDAO.GetPayments();
        public Payment GetPayment(Guid id) => PaymentDAO.FindPayment(id);
        public void PutPayment(Payment payment) => PaymentDAO.UpdatePayment(payment);
        public void PostPayment(Payment payment) => PaymentDAO.SavePayment(payment);
        public void DeletePayment(Payment payment) => PaymentDAO.DeletePayment(payment);
    }
}
