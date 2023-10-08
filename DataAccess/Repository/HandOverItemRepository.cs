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
    public class HandOverItemRepository : IHandOverItemRepository
    {
        public List<HandOverItem> GetHandOverItems() => HandOverItemDAO.GetHandOverItems();
        public HandOverItem GetHandOverItem(Guid id) => HandOverItemDAO.FindHandOverItem(id);
        public void PutHandOverItem(HandOverItem handOverItem) => HandOverItemDAO.UpdateHandOverItem(handOverItem);
        public void PostHandOverItem(HandOverItem handOverItem) => HandOverItemDAO.SaveHandOverItem(handOverItem);
        public void DeleteHandOverItem(HandOverItem handOverItem) => HandOverItemDAO.DeleteHandOverItem(handOverItem);
    }
}
