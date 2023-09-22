using BusinessObject.Entities;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IFeeRepository
    {
        public List<Fee> GetFees();
        public Fee GetFee(Guid id);
        public void PutFee(Fee fee);
        public void PostFee(Fee fee);
        public void DeleteFee(Fee fee);
    }
}
