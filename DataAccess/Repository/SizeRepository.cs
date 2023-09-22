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
    public class SizeRepository : ISizeRepository
    {
        public List<Size> GetSizes() => SizeDAO.GetSizes();
        public Size GetSize(Guid id) => SizeDAO.FindSize(id);
        public void PutSize(Size size) => SizeDAO.UpdateSize(size);
        public void PostSize(Size size) => SizeDAO.SaveSize(size);
        public void DeleteSize(Size size) => SizeDAO.DeleteSize(size);
    }
}
