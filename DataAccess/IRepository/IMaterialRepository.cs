using BusinessObject.Entities;

namespace DataAccess.IRepository
{
    public interface IMaterialRepository
    {
        public List<Material> GetMaterials();
        public Material GetMaterial(Guid id);
        public void PutMaterial(Material material);
        public void PostMaterial(Material material);
        public void DeleteMaterial(Material material);
    }
}
