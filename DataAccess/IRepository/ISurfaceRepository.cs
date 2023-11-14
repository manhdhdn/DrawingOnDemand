using BusinessObject.Entities;

namespace DataAccess.IRepository
{
    public interface ISurfaceRepository
    {
        public List<Surface> GetSurfaces();
        public Surface GetSurface(Guid id);
        public void PutSurface(Surface surface);
        public void PostSurface(Surface surface);
        public void DeleteSurface(Surface surface);
    }
}
