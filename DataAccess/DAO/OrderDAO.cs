using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class OrderDAO
    {
        public static List<Order> GetOrders()
        {
            var listOrder = new List<Order>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listOrder = context.Orders
                    .Include(o => o.OrderDetails).ThenInclude(od => od.Artwork).ThenInclude(aw => aw!.Arts)
                    .Include(o => o.OrderDetails).ThenInclude(od => od.Artwork).ThenInclude(aw => aw!.Sizes)
                    .Include(o => o.OrderDetails).ThenInclude(od => od.Artwork).ThenInclude(aw => aw!.CreatedByNavigation)
                    .Include(o => o.Discount)
                    .Include(o => o.OrderedByNavigation)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listOrder;
        }

        public static Order FindOrder(Guid id)
        {
            Order order = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                order = context.Orders
                    .Include(o => o.OrderDetails).ThenInclude(od => od.Artwork).ThenInclude(aw => aw!.Arts)
                    .Include(o => o.OrderDetails).ThenInclude(od => od.Artwork).ThenInclude(aw => aw!.Sizes)
                    .Include(o => o.OrderDetails).ThenInclude(od => od.Artwork).ThenInclude(aw => aw!.CreatedByNavigation)
                    .Include(o => o.OrderDetails).ThenInclude(od => od.Artwork).ThenInclude(aw => aw!.Proposal).ThenInclude(p => p!.Requirement).ThenInclude(r => r!.Steps)
                    .Include(o => o.Discount)
                    .Include(o => o.OrderedByNavigation)
                    .Include(o => o.HandOvers).ThenInclude(ho => ho.HandOverItems).ThenInclude(hoi => hoi.OrderDetail).ThenInclude(od => od!.Artwork).ThenInclude(aw => aw!.Arts)
                    .SingleOrDefault(o => o.Id == id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return order!;
        }

        public static void SaveOrder(Order order)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Orders.Add(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateOrder(Order order)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteOrder(Order order)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Orders.Remove(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
