using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class MaterialDAO
    {
        public static List<Material> GetMaterials()
        {
            var listMaterial = new List<Material>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listMaterial = context.Materials.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listMaterial;
        }

        public static Material FindMaterial(Guid id)
        {
            Material material = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                material = context.Materials.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return material!;
        }

        public static void SaveMaterial(Material material)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Materials.Add(material);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateMaterial(Material material)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(material).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteMaterial(Material material)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Materials.Remove(material);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
