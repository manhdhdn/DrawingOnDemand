using BusinessObject.Entities;

namespace DataAccess.IRepository
{
    public interface IHandOverRepository
    {
        public List<HandOver> GetHandOvers();
        public HandOver GetHandOver(Guid id);
        public void PutHandOver(HandOver handOver);
        public void PostHandOver(HandOver handOver);
        public void DeleteHandOver(HandOver handOver);
    }
}
