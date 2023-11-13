using BusinessObject.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;

namespace DataAccess.Repository
{
    public class RankRepository : IRankRepository
    {
        public List<Rank> GetRanks() => RankDAO.GetRanks();
        public Rank GetRank(Guid id) => RankDAO.FindRank(id);
        public void PutRank(Rank rank) => RankDAO.UpdateRank(rank);
        public void PostRank(Rank rank) => RankDAO.SaveRank(rank);
        public void DeleteRank(Rank rank) => RankDAO.DeleteRank(rank);
    }
}
