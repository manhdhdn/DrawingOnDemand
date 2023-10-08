using BusinessObject.Entities;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IHandOverItemRepository
    {
        public List<HandOverItem> GetHandOverItems();
        public HandOverItem GetHandOverItem(Guid id);
        public void PutHandOverItem(HandOverItem handOverItem);
        public void PostHandOverItem(HandOverItem handOverItem) => HandOverItemDAO.SaveHandOverItem(handOverItem);
        public void DeleteHandOverItem(HandOverItem handOverItem);
    }
}
