using BusinessObject.Entities;

namespace DataAccess.IRepository
{
    public interface IInviteRepository
    {
        public List<Invite> GetInvites();
        public Invite GetInvite(Guid id);
        public void PutInvite(Invite invite);
        public void PostInvite(Invite invite);
        public void DeleteInvite(Invite invite);
    }
}
