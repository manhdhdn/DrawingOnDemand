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
    public class ProposalRepository : IProposalRepository
    {
        public List<Proposal> GetProposals() => ProposalDAO.GetProposals();
        public Proposal GetProposal(Guid id) => ProposalDAO.FindProposal(id);
        public void PutProposal(Proposal proposal) => ProposalDAO.UpdateProposal(proposal);
        public void PostProposal(Proposal proposal) => ProposalDAO.SaveProposal(proposal);
        public void DeleteProposal(Proposal proposal) => ProposalDAO.DeleteProposal(proposal);
    }
}
