using BusinessObject.Entities;

namespace DataAccess.IRepository
{
    public interface IOrderDetailRepository
    {
        public List<OrderDetail> GetOrderDetails();
        public OrderDetail GetOrderDetail(Guid id);
        public void PutOrderDetail(OrderDetail orderDetail);
        public void PostOrderDetail(OrderDetail orderDetail);
        public void DeleteOrderDetail(OrderDetail orderDetail);
    }
}
