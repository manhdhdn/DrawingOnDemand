using BusinessObject.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;

namespace DataAccess.Repository
{
    public class SurfaceRepository : ISurfaceRepository
    {
        public List<Surface> GetSurfaces() => SurfaceDAO.GetSurfaces();
        public Surface GetSurface(Guid id) => SurfaceDAO.FindSurface(id);
        public void PutSurface(Surface surface) => SurfaceDAO.UpdateSurface(surface);
        public void PostSurface(Surface surface) => SurfaceDAO.SaveSurface(surface);
        public void DeleteSurface(Surface surface) => SurfaceDAO.DeleteSurface(surface);
    }
}
