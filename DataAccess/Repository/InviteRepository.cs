using BusinessObject.Entities;
using DataAccess.DAO;
using DataAccess.IRepository;

namespace DataAccess.Repository
{
    public class InviteRepository : IInviteRepository
    {
        public List<Invite> GetInvites() => InviteDAO.GetInvites();
        public Invite GetInvite(Guid id) => InviteDAO.FindInvite(id);
        public void PutInvite(Invite invite) => InviteDAO.UpdateInvite(invite);
        public void PostInvite(Invite invite) => InviteDAO.SaveInvite(invite);
        public void DeleteInvite(Invite invite) => InviteDAO.DeleteInvite(invite);
    }
}
