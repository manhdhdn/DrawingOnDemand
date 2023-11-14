using BusinessObject.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public List<OrderDetail> GetOrderDetails() => OrderDetailDAO.GetOrderDetails();
        public OrderDetail GetOrderDetail(Guid id) => OrderDetailDAO.FindOrderDetail(id);
        public void PutOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.UpdateOrderDetail(orderDetail);
        public void PostOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.SaveOrderDetail(orderDetail);
        public void DeleteOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.DeleteOrderDetail(orderDetail);
    }
}
