using BusinessObject.Entities;

namespace DataAccess.IRepository
{
    public interface IArtworkRepository
    {
        public List<Artwork> GetArtworks();
        public Artwork GetArtwork(Guid id);
        public void PutArtwork(Artwork artwork);
        public void PostArtwork(Artwork artwork);
        public void DeleteArtwork(Artwork artwork);
    }
}
