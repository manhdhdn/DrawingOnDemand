using BusinessObject.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public List<Order> GetOrders() => OrderDAO.GetOrders();
        public Order GetOrder(Guid id) => OrderDAO.FindOrder(id);
        public void PutOrder(Order order) => OrderDAO.UpdateOrder(order);
        public void PostOrder(Order order) => OrderDAO.SaveOrder(order);
        public void DeleteOrder(Order order) => OrderDAO.DeleteOrder(order);
    }
}
