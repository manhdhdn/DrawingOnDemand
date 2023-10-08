using BusinessObject.Entities.Context;
using BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AccountReviewDAO
    {
        public static List<AccountReview> GetAccountReviews()
        {
            var listAccountReview = new List<AccountReview>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listAccountReview = context.AccountReviews.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listAccountReview;
        }

        public static AccountReview FindAccountReview(Guid id)
        {
            AccountReview accountReview = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                accountReview = context.AccountReviews.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return accountReview!;
        }

        public static void SaveAccountReview(AccountReview accountReview)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.AccountReviews.Add(accountReview);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateAccountReview(AccountReview accountReview)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(accountReview).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteAccountReview(AccountReview accountReview)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.AccountReviews.Remove(accountReview);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
