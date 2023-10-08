using BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
