using BusinessObject.Entities;

namespace DataAccess.IRepository
{
    public interface IDiscountRepository
    {
        public List<Discount> GetDiscounts();
        public Discount GetDiscount(Guid id);
        public void PutDiscount(Discount discount);
        public void PostDiscount(Discount discount);
        public void DeleteDiscount(Discount discount);
    }
}
