using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class OrderDetailDAO
    {
        public static List<OrderDetail> GetOrderDetails()
        {
            var listOrderDetail = new List<OrderDetail>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listOrderDetail = context.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listOrderDetail;
        }

        public static OrderDetail FindOrderDetail(Guid id)
        {
            OrderDetail orderDetail = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                orderDetail = context.OrderDetails.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return orderDetail!;
        }

        public static void SaveOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(orderDetail).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.OrderDetails.Remove(orderDetail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
