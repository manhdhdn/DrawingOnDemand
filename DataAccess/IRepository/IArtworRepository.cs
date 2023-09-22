using BusinessObject.Entities;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IArtworkRepository
    {
        public List<Artwork> GetArtworks();
        public Artwork GetArtwork(Guid id);
        public void PutArtwork(Artwork artwork);
        public void PostArtwork(Artwork artwork) => ArtworkDAO.SaveArtwork(artwork);
        public void DeleteArtwork(Artwork artwork);
    }
}
