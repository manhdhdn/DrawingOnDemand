using BusinessObject.Entities;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IOrderDetailRepository
    {
        public List<OrderDetail> GetOrderDetails();
        public OrderDetail GetOrderDetail(Guid id);
        public void PutOrderDetail(OrderDetail orderDetail);
        public void PostOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.SaveOrderDetail(orderDetail);
        public void DeleteOrderDetail(OrderDetail orderDetail);
    }
}
