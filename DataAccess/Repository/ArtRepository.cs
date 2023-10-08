﻿using BusinessObject.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ArtRepository : IArtRepository
    {
        public List<Art> GetArts() => ArtDAO.GetArts();
        public Art GetArt(Guid id) => ArtDAO.FindArt(id);
        public void PutArt(Art art) => ArtDAO.UpdateArt(art);
        public void PostArt(Art art) => ArtDAO.SaveArt(art);
        public void DeleteArt(Art art) => ArtDAO.DeleteArt(art);
    }
}
