using BusinessObject.Entities;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
