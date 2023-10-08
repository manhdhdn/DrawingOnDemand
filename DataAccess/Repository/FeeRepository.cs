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
    public class FeeRepository : IFeeRepository
    {
        public List<Fee> GetFees() => FeeDAO.GetFees();
        public Fee GetFee(Guid id) => FeeDAO.FindFee(id);
        public void PutFee(Fee fee) => FeeDAO.UpdateFee(fee);
        public void PostFee(Fee fee) => FeeDAO.SaveFee(fee);
        public void DeleteFee(Fee fee) => FeeDAO.DeleteFee(fee);
    }
}
