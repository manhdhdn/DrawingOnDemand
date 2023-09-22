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
    public class RequirementRepository : IRequirementRepository
    {
        public List<Requirement> GetRequirements() => RequirementDAO.GetRequirements();
        public Requirement GetRequirement(Guid id) => RequirementDAO.FindRequirement(id);
        public void PutRequirement(Requirement requirement) => RequirementDAO.UpdateRequirement(requirement);
        public void PostRequirement(Requirement requirement) => RequirementDAO.SaveRequirement(requirement);
        public void DeleteRequirement(Requirement requirement) => RequirementDAO.DeleteRequirement(requirement);
    }
}
