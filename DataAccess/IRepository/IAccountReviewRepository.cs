using BusinessObject.Entities;

namespace DataAccess.IRepository
{
    public interface IAccountReviewRepository
    {
        public List<AccountReview> GetAccountReviews();
        public AccountReview GetAccountReview(Guid id);
        public void PutAccountReview(AccountReview accountReview);
        public void PostAccountReview(AccountReview accountReview);
        public void DeleteAccountReview(AccountReview accountReview);
    }
}
