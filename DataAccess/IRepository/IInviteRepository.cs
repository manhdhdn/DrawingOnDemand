using BusinessObject.Entities;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IInviteRepository
    {
        public List<Invite> GetInvites();
        public Invite GetInvite(Guid id);
        public void PutInvite(Invite invite);
        public void PostInvite(Invite invite) => InviteDAO.SaveInvite(invite);
        public void DeleteInvite(Invite invite);
    }
}
