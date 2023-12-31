﻿using BusinessObject.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;

namespace DataAccess.Repository
{
    public class ArtworkRepository : IArtworkRepository
    {
        public List<Artwork> GetArtworks() => ArtworkDAO.GetArtworks();
        public Artwork GetArtwork(Guid id) => ArtworkDAO.FindArtwork(id);
        public void PutArtwork(Artwork artwork) => ArtworkDAO.UpdateArtwork(artwork);
        public void PostArtwork(Artwork artwork) => ArtworkDAO.SaveArtwork(artwork);
        public void DeleteArtwork(Artwork artwork) => ArtworkDAO.DeleteArtwork(artwork);
    }
}
