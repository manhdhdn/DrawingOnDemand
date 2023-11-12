using BusinessObject.Entities;

namespace DataAccess.IRepository
{
    public interface IAccountRepository
    {
        public List<Account> GetAccounts();
        public Account GetAccount(Guid id);
        public void PutAccount(Account account);
        public void PostAccount(Account account);
        public void DeleteAccount(Account account);
    }
}
