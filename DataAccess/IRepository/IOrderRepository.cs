using BusinessObject.Entities;

namespace DataAccess.IRepository
{
    public interface IOrderRepository
    {
        public List<Order> GetOrders();
        public Order GetOrder(Guid id);
        public void PutOrder(Order order);
        public void PostOrder(Order order);
        public void DeleteOrder(Order order);
    }
}
