using BusinessObject.Entities;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IArtRepository
    {
        public List<Art> GetArts();
        public Art GetArt(Guid id);
        public void PutArt(Art art);
        public void PostArt(Art art);
        public void DeleteArt(Art art);
    }
}
