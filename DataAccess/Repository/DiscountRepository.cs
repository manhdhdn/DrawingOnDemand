using BusinessObject.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;

namespace DataAccess.Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        public List<Discount> GetDiscounts() => DiscountDAO.GetDiscounts();
        public Discount GetDiscount(Guid id) => DiscountDAO.FindDiscount(id);
        public void PutDiscount(Discount discount) => DiscountDAO.UpdateDiscount(discount);
        public void PostDiscount(Discount discount) => DiscountDAO.SaveDiscount(discount);
        public void DeleteDiscount(Discount discount) => DiscountDAO.DeleteDiscount(discount);
    }
}
