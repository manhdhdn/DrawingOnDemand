using BusinessObject.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;

namespace DataAccess.Repository
{
    public class AccountReviewRepository : IAccountReviewRepository
    {
        public List<AccountReview> GetAccountReviews() => AccountReviewDAO.GetAccountReviews();
        public AccountReview GetAccountReview(Guid id) => AccountReviewDAO.FindAccountReview(id);
        public void PutAccountReview(AccountReview accountReview) => AccountReviewDAO.UpdateAccountReview(accountReview);
        public void PostAccountReview(AccountReview accountReview) => AccountReviewDAO.SaveAccountReview(accountReview);
        public void DeleteAccountReview(AccountReview accountReview) => AccountReviewDAO.DeleteAccountReview(accountReview);
    }
}
