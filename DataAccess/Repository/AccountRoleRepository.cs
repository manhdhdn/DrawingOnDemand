using BusinessObject.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;

namespace DataAccess.Repository
{
    public class AccountRoleRepository : IAccountRoleRepository
    {
        public List<AccountRole> GetAccountRoles() => AccountRoleDAO.GetAccountRoles();
        public AccountRole GetAccountRole(Guid id) => AccountRoleDAO.FindAccountRole(id);
        public void PutAccountRole(AccountRole accountRole) => AccountRoleDAO.UpdateAccountRole(accountRole);
        public void PostAccountRole(AccountRole accountRole) => AccountRoleDAO.SaveAccountRole(accountRole);
        public void DeleteAccountRole(AccountRole accountRole) => AccountRoleDAO.DeleteAccountRole(accountRole);
    }
}
