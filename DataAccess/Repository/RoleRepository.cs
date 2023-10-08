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
    public class RoleRepository : IRoleRepository
    {
        public List<Role> GetRoles() => RoleDAO.GetRoles();
        public Role GetRole(Guid id) => RoleDAO.FindRole(id);
        public void PutRole(Role role) => RoleDAO.UpdateRole(role);
        public void PostRole(Role role) => RoleDAO.SaveRole(role);
        public void DeleteRole(Role role) => RoleDAO.DeleteRole(role);
    }
}
