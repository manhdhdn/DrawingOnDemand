using BusinessObject.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetCategories() => CategoryDAO.GetCategories();
        public Category GetCategory(Guid id) => CategoryDAO.FindCategory(id);
        public void PutCategory(Category category) => CategoryDAO.UpdateCategory(category);
        public void PostCategory(Category category) => CategoryDAO.SaveCategory(category);
        public void DeleteCategory(Category category) => CategoryDAO.DeleteCategory(category);
    }
}
