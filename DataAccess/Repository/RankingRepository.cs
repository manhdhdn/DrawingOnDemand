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
    public class RankingRepository : IRankingRepository
    {
        public List<Ranking> GetRankings() => RankingDAO.GetRankings();
        public Ranking GetRanking(Guid id) => RankingDAO.FindRanking(id);
        public void PutRanking(Ranking ranking) => RankingDAO.UpdateRanking(ranking);
        public void PostRanking(Ranking ranking) => RankingDAO.SaveRanking(ranking);
        public void DeleteRanking(Ranking ranking) => RankingDAO.DeleteRanking(ranking);
    }
}
