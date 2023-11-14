using BusinessObject.Entities;

namespace DataAccess.IRepository
{
    public interface ICategoryRepository
    {
        public List<Category> GetCategories();
        public Category GetCategory(Guid id);
        public void PutCategory(Category category);
        public void PostCategory(Category category);
        public void DeleteCategory(Category category);
    }
}
