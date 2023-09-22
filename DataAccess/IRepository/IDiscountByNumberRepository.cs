using BusinessObject.Entities;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IDiscountByNumberRepository
    {
        public List<DiscountByNumber> GetDiscountByNumbers();
        public DiscountByNumber GetDiscountByNumber(Guid id);
        public void PutDiscountByNumber(DiscountByNumber discountByNumber);
        public void PostDiscountByNumber(DiscountByNumber discountByNumber) => DiscountByNumberDAO.SaveDiscountByNumber(discountByNumber);
        public void DeleteDiscountByNumber(DiscountByNumber discountByNumber);
    }
}
