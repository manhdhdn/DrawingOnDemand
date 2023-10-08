using BusinessObject.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class DiscountByNumberRepository : IDiscountByNumberRepository
    {
        public List<DiscountByNumber> GetDiscountByNumbers() => DiscountByNumberDAO.GetDiscountByNumbers();
        public DiscountByNumber GetDiscountByNumber(Guid id) => DiscountByNumberDAO.FindDiscountByNumber(id);
        public void PutDiscountByNumber(DiscountByNumber discountByNumber) => DiscountByNumberDAO.UpdateDiscountByNumber(discountByNumber);
        public void PostDiscountByNumber(DiscountByNumber discountByNumber) => DiscountByNumberDAO.SaveDiscountByNumber(discountByNumber);
        public void DeleteDiscountByNumber(DiscountByNumber discountByNumber) => DiscountByNumberDAO.DeleteDiscountByNumber(discountByNumber);
    }
}
