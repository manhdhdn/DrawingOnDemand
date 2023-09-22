using BusinessObject.Entities;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IOrderRepository
    {
        public List<Order> GetOrders();
        public Order GetOrder(Guid id);
        public void PutOrder(Order order);
        public void PostOrder(Order order) => OrderDAO.SaveOrder(order);
        public void DeleteOrder(Order order);
    }
}
