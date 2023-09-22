using BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IRoleRepository
    {
        public List<Role> GetRoles();
        public Role GetRole(Guid id);
        public void PutRole(Role role);
        public void PostRole(Role role);
        public void DeleteRole(Role role);
    }
}
