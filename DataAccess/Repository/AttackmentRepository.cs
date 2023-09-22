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
    public class AttackmentRepository : IAttackmentRepository
    {
        public List<Attackment> GetAttackments() => AttackmentDAO.GetAttackments();
        public Attackment GetAttackment(Guid id) => AttackmentDAO.FindAttackment(id);
        public void PutAttackment(Attackment attackment) => AttackmentDAO.UpdateAttackment(attackment);
        public void PostAttackment(Attackment attackment) => AttackmentDAO.SaveAttackment(attackment);
        public void DeleteAttackment(Attackment attackment) => AttackmentDAO.DeleteAttackment(attackment);
    }
}
