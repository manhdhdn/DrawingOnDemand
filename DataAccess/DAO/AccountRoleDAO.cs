using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class AccountRoleDAO
    {
        public static List<AccountRole> GetAccountRoles()
        {
            var listAccountRole = new List<AccountRole>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listAccountRole = context.AccountRoles
                    .Include(ar => ar.Account).ThenInclude(a => a!.AccountReviewAccounts)
                    .Include(ar => ar.Account).ThenInclude(a => a!.Rank)
                    .Include(ar => ar.Role)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listAccountRole;
        }

        public static AccountRole FindAccountRole(Guid id)
        {
            AccountRole accountRole = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                accountRole = context.AccountRoles
                    .Include(ar => ar.Account)
                    .Include(ar => ar.Role)
                    .Single(ar => ar.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return accountRole!;
        }

        public static void SaveAccountRole(AccountRole accountRole)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.AccountRoles.Add(accountRole);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateAccountRole(AccountRole accountRole)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(accountRole).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteAccountRole(AccountRole accountRole)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.AccountRoles.Remove(accountRole);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
