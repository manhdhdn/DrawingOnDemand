using BusinessObject.Entities;
using BusinessObject.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class ProposalDAO
    {
        public static List<Proposal> GetProposals()
        {
            var listProposal = new List<Proposal>();

            try
            {
                using var context = new DrawingOnDemandContext();

                listProposal = context.Proposals.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listProposal;
        }

        public static Proposal FindProposal(Guid id)
        {
            Proposal proposal = new();

            try
            {
                using var context = new DrawingOnDemandContext();

                proposal = context.Proposals.Find(id)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return proposal!;
        }

        public static void SaveProposal(Proposal proposal)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Proposals.Add(proposal);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateProposal(Proposal proposal)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Entry(proposal).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteProposal(Proposal proposal)
        {
            try
            {
                using var context = new DrawingOnDemandContext();

                context.Proposals.Remove(proposal);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
