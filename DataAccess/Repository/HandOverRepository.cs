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
    public class HandOverRepository : IHandOverRepository
    {
        public List<HandOver> GetHandOvers() => HandOverDAO.GetHandOvers();
        public HandOver GetHandOver(Guid id) => HandOverDAO.FindHandOver(id);
        public void PutHandOver(HandOver handOver) => HandOverDAO.UpdateHandOver(handOver);
        public void PostHandOver(HandOver handOver) => HandOverDAO.SaveHandOver(handOver);
        public void DeleteHandOver(HandOver handOver) => HandOverDAO.DeleteHandOver(handOver);
    }
}
