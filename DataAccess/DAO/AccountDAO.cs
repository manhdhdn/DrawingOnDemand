using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class AccountDAO
    {
        public static List<Account> GetAccounts()
        {
            var listAccount = new List<Account>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listAccount = context.Accounts
                    .Include(a => a.AccountRoles).ThenInclude(ar => ar.Role)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listAccount;
        }

        public static Account FindAccount(Guid id)
        {
            Account account = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                account = context.Accounts
                    .Include(a => a.Rank)
                    .Include(a => a.AccountReviewAccounts).ThenInclude(ar => ar.CreatedByNavigation)
                    .Include(a => a.Artworks)
                    .Include(a => a.Certificates)
                    .Single(a => a.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return account!;
        }

        public static void SaveAccount(Account account)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Accounts.Add(account);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateAccount(Account account)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(account).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteAccount(Account account)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Accounts.Remove(account);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
