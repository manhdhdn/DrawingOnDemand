using BusinessObject.Entities;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IHandOverRepository
    {
        public List<HandOver> GetHandOvers();
        public HandOver GetHandOver(Guid id);
        public void PutHandOver(HandOver handOver);
        public void PostHandOver(HandOver handOver) => HandOverDAO.SaveHandOver(handOver);
        public void DeleteHandOver(HandOver handOver);
    }
}
