using BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IProposalRepository
    {
        public List<Proposal> GetProposals();
        public Proposal GetProposal(Guid id);
        public void PutProposal(Proposal proposal);
        public void PostProposal(Proposal proposal);
        public void DeleteProposal(Proposal proposal);
    }
}
