using BusinessObject.Entities;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IDiscountBySpecialRepository
    {
        public List<DiscountBySpecial> GetDiscountBySpecials();
        public DiscountBySpecial GetDiscountBySpecial(Guid id);
        public void PutDiscountBySpecial(DiscountBySpecial discountBySpecial);
        public void PostDiscountBySpecial(DiscountBySpecial discountBySpecial);
        public void DeleteDiscountBySpecial(DiscountBySpecial discountBySpecial);
    }
}
