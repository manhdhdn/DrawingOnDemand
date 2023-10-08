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
    public class DiscountBySpecialRepository : IDiscountBySpecialRepository
    {
        public List<DiscountBySpecial> GetDiscountBySpecials() => DiscountBySpecialDAO.GetDiscountBySpecials();
        public DiscountBySpecial GetDiscountBySpecial(Guid id) => DiscountBySpecialDAO.FindDiscountBySpecial(id);
        public void PutDiscountBySpecial(DiscountBySpecial discountBySpecial) => DiscountBySpecialDAO.UpdateDiscountBySpecial(discountBySpecial);
        public void PostDiscountBySpecial(DiscountBySpecial discountBySpecial) => DiscountBySpecialDAO.SaveDiscountBySpecial(discountBySpecial);
        public void DeleteDiscountBySpecial(DiscountBySpecial discountBySpecial) => DiscountBySpecialDAO.DeleteDiscountBySpecial(discountBySpecial);
    }
}
