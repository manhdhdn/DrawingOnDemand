using BusinessObject.Entities;

namespace DataAccess.IRepository
{
    public interface IAccountRoleRepository
    {
        public List<AccountRole> GetAccountRoles();
        public AccountRole GetAccountRole(Guid id);
        public void PutAccountRole(AccountRole accountRole);
        public void PostAccountRole(AccountRole accountRole);
        public void DeleteAccountRole(AccountRole accountRole);
    }
}
