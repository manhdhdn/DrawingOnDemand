using BusinessObject.Entities;

namespace DataAccess.IRepository
{
    public interface IRankRepository
    {
        public List<Rank> GetRanks();
        public Rank GetRank(Guid id);
        public void PutRank(Rank rank);
        public void PostRank(Rank rank);
        public void DeleteRank(Rank rank);
    }
}
