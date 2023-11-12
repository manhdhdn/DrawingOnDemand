using BusinessObject.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;

namespace DataAccess.Repository
{
    public class MaterialRepository : IMaterialRepository
    {
        public List<Material> GetMaterials() => MaterialDAO.GetMaterials();
        public Material GetMaterial(Guid id) => MaterialDAO.FindMaterial(id);
        public void PutMaterial(Material material) => MaterialDAO.UpdateMaterial(material);
        public void PostMaterial(Material material) => MaterialDAO.SaveMaterial(material);
        public void DeleteMaterial(Material material) => MaterialDAO.DeleteMaterial(material);
    }
}
