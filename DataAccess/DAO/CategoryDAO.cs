using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            var listCategory = new List<Category>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listCategory = context.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listCategory;
        }

        public static Category FindCategory(Guid id)
        {
            Category category = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                category = context.Categories.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return category!;
        }

        public static void SaveCategory(Category category)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Categories.Add(category);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateCategory(Category category)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteCategory(Category category)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Categories.Remove(category);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
