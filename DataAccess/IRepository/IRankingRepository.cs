using BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IRankingRepository
    {
        public List<Ranking> GetRankings();
        public Ranking GetRanking(Guid id);
        public void PutRanking(Ranking ranking);
        public void PostRanking(Ranking ranking);
        public void DeleteRanking(Ranking ranking);
    }
}
