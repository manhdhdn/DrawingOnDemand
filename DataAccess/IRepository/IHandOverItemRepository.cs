using BusinessObject.Entities;

namespace DataAccess.IRepository
{
    public interface IHandOverItemRepository
    {
        public List<HandOverItem> GetHandOverItems();
        public HandOverItem GetHandOverItem(Guid id);
        public void PutHandOverItem(HandOverItem handOverItem);
        public void PostHandOverItem(HandOverItem handOverItem);
        public void DeleteHandOverItem(HandOverItem handOverItem);
    }
}
