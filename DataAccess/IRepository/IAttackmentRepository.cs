using BusinessObject.Entities;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IAttackmentRepository
    {
        public List<Attackment> GetAttackments();
        public Attackment GetAttackment(Guid id);
        public void PutAttackment(Attackment attackment);
        public void PostAttackment(Attackment attackment);
        public void DeleteAttackment(Attackment attackment);
    }
}
