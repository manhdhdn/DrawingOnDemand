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
    public class AccountRepository : IAccountRepository
    {
        public List<Account> GetAccounts() => AccountDAO.GetAccounts();
        public Account GetAccount(Guid id) => AccountDAO.FindAccount(id);
        public void PutAccount(Account account) => AccountDAO.UpdateAccount(account);
        public void PostAccount(Account account) => AccountDAO.SaveAccount(account);
        public void DeleteAccount(Account account) => AccountDAO.DeleteAccount(account);
    }
}
