using BusinessObject.Entities;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IAccountRepository
    {
        public List<Account> GetAccounts();
        public Account GetAccount(Guid id);
        public void PutAccount(Account account);
        public void PostAccount(Account account) => AccountDAO.SaveAccount(account);
        public void DeleteAccount(Account account);
    }
}
