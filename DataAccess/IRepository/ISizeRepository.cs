using BusinessObject.Entities;

namespace DataAccess.IRepository
{
    public interface ISizeRepository
    {
        public List<Size> GetSizes();
        public Size GetSize(Guid id);
        public void PutSize(Size size);
        public void PostSize(Size size);
        public void DeleteSize(Size size);
    }
}
